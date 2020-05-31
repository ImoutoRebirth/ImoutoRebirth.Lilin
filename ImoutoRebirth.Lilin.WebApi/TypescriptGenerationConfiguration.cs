using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Fluent;

namespace ImoutoRebirth.Lilin.WebApi
{
    public class TypescriptGenerationConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            var exportable = GetExportableTypes();

            ExportClasses(builder, exportable);

            ExportEnums(builder, exportable);

            builder.Global(
                x =>
                {
                    x.DontWriteWarningComment();
                    x.CamelCaseForProperties();
                    x.CamelCaseForMethods();
                    x.TabSymbol("    ");
                    x.UseModules();
                });

            builder.Substitute(typeof(Guid), new RtSimpleTypeName("string"));
        }

        private static void ExportEnums(ConfigurationBuilder builder, List<Type> exportable)
        {
            foreach (var type in exportable.Where(x => x.IsEnum))
                builder.ExportAsEnums(
                    new[] {type},
                    exportBuilder =>
                    {
                        exportBuilder.DontIncludeToNamespace();
                        exportBuilder.ExportTo(GetKebabCaseName(type.Name) + ".ts");
                    });
        }

        private static void ExportClasses(ConfigurationBuilder builder, List<Type> exportable)
        {
            foreach (var type in exportable.Where(x => x.IsClass || x.IsInterface))
                builder.ExportAsInterfaces(
                    new[] {type},
                    exportBuilder =>
                    {
                        exportBuilder.WithPublicProperties();
                        exportBuilder.DontIncludeToNamespace();
                        exportBuilder.ExportTo(GetKebabCaseName(type.Name) + ".ts");
                    });
        }

        private static string GetKebabCaseName(string typeName)
        {
            return Regex.Replace(
                    typeName,
                    "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                    "-$1",
                    RegexOptions.Compiled)
                .Trim()
                .ToLower();
        }

        private static List<Type> GetExportableTypes()
        {
            const string requestSuffix = "Request";
            const string responseSuffix = "Response";

            var dto = typeof(TypescriptGenerationConfiguration)
                .Assembly
                .GetExportedTypes()
                .Where(
                    x => x.FullName?.EndsWith(requestSuffix) == true
                         || x.FullName?.EndsWith(responseSuffix) == true)
                .ToList();

            var extraTypes = ExtractAllLocalTypes(dto);
            var exportable = dto.Union(extraTypes).Distinct().ToList();
            return exportable;
        }

        private static IEnumerable<Type> ExtractAllLocalTypes(IEnumerable<Type> roots)
        {
            foreach (var root in roots)
            {
                yield return root;
                var localTypes = ExtractTypeTree(root)
                    .Where(x => x.FullName?.StartsWith("ImoutoRebirth.Lilin") == true);

                foreach (var localType in localTypes) yield return localType;
            }
        }

        private static IEnumerable<Type> ExtractTypeTree(Type type)
        {
            var propertyTypes = type.GetProperties().Select(property => property.PropertyType);

            foreach (var propertyType in propertyTypes)
            {
                yield return propertyType;

                foreach (var innerType in ExtractTypeTree(propertyType)) yield return innerType;
            }
        }
    }
}