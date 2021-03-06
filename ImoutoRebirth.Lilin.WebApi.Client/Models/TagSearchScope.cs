// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ImoutoRebirth.Lilin.WebApi.Client.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for TagSearchScope.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TagSearchScope
    {
        [EnumMember(Value = "Included")]
        Included,
        [EnumMember(Value = "Excluded")]
        Excluded
    }
    internal static class TagSearchScopeEnumExtension
    {
        internal static string ToSerializedValue(this TagSearchScope? value)
        {
            return value == null ? null : ((TagSearchScope)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this TagSearchScope value)
        {
            switch( value )
            {
                case TagSearchScope.Included:
                    return "Included";
                case TagSearchScope.Excluded:
                    return "Excluded";
            }
            return null;
        }

        internal static TagSearchScope? ParseTagSearchScope(this string value)
        {
            switch( value )
            {
                case "Included":
                    return TagSearchScope.Included;
                case "Excluded":
                    return TagSearchScope.Excluded;
            }
            return null;
        }
    }
}
