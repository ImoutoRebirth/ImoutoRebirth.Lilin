using System;
using System.Reflection;
using Reinforced.Typings;
using Xunit;

namespace ImoutoRebirth.Lilin.WebApi.Tests
{
    public class TypescriptGenerationConfigurationTests
    {
        [Fact]
        public void EnsureConfigurationWorks()
        {
            var context = new ExportContext(
                new[] { typeof(TypescriptGenerationConfiguration).Assembly})
            {
                Hierarchical = true, //true if you export to multiple files
                TargetDirectory = @"TestOutput", //substitute your path
                TargetFile = @"TestOutput\project.ts", //substitute your file
                //SourceAssemblies = new Assembly[] { typeof(TypescriptGenerationConfiguration).Assembly}, // specify assemblies (usually by typeof(something).Assembly) containig type that you export and all dependant types
                //DocumentationFilePath = @"C:\MyProject\bin\MyProject.XML", //optional
                ConfigurationMethod = TypescriptGenerationConfiguration.Configure //here is your method

            };

            var exporter = new TsExporter(context);
            exporter.Export();
        }
    }
}
