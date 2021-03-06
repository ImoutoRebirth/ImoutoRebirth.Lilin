// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ImoutoRebirth.Lilin.WebApi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class FileNoteResponse
    {
        /// <summary>
        /// Initializes a new instance of the FileNoteResponse class.
        /// </summary>
        public FileNoteResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FileNoteResponse class.
        /// </summary>
        /// <param name="source">Possible values include: 'Yandere',
        /// 'Danbooru', 'Sankaku', 'Manual'</param>
        public FileNoteResponse(System.Guid fileId, MetadataSource source, FileNoteResponseNote note = default(FileNoteResponseNote), int? sourceId = default(int?))
        {
            FileId = fileId;
            Note = note;
            Source = source;
            SourceId = sourceId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fileId")]
        public System.Guid FileId { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "note")]
        public FileNoteResponseNote Note { get; private set; }

        /// <summary>
        /// Gets possible values include: 'Yandere', 'Danbooru', 'Sankaku',
        /// 'Manual'
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public MetadataSource Source { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sourceId")]
        public int? SourceId { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Note != null)
            {
                Note.Validate();
            }
        }
    }
}
