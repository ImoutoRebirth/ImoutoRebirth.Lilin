// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ImoutoRebirth.Lilin.WebApi.Client.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class FilesSearchRequest
    {
        /// <summary>
        /// Initializes a new instance of the FilesSearchRequest class.
        /// </summary>
        public FilesSearchRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FilesSearchRequest class.
        /// </summary>
        public FilesSearchRequest(IList<TagSearchEntryRequest> tagSearchEntries, int? count = default(int?), int? skip = default(int?))
        {
            TagSearchEntries = tagSearchEntries;
            Count = count;
            Skip = skip;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tagSearchEntries")]
        public IList<TagSearchEntryRequest> TagSearchEntries { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "skip")]
        public int? Skip { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (TagSearchEntries == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TagSearchEntries");
            }
            if (TagSearchEntries != null)
            {
                foreach (var element in TagSearchEntries)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
