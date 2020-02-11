// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ImoutoRebirth.Lilin.WebApi.Client.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class FileInfoResponse
    {
        /// <summary>
        /// Initializes a new instance of the FileInfoResponse class.
        /// </summary>
        public FileInfoResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FileInfoResponse class.
        /// </summary>
        public FileInfoResponse(IList<FileTagResponse> tags = default(IList<FileTagResponse>), IList<FileNoteResponse> notes = default(IList<FileNoteResponse>))
        {
            Tags = tags;
            Notes = notes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<FileTagResponse> Tags { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public IList<FileNoteResponse> Notes { get; private set; }

    }
}
