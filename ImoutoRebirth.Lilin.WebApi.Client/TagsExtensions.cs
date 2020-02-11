// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ImoutoRebirth.Lilin.WebApi.Client
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Tags.
    /// </summary>
    public static partial class TagsExtensions
    {
            /// <summary>
            /// Search for tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static IList<TagResponse> Search(this ITags operations, TagsSearchRequest body = default(TagsSearchRequest))
            {
                return operations.SearchAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Search for tags.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<TagResponse>> SearchAsync(this ITags operations, TagsSearchRequest body = default(TagsSearchRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SearchWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create a tag.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            public static TagResponse Create(this ITags operations, TagCreateRequest body = default(TagCreateRequest))
            {
                return operations.CreateAsync(body).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create a tag.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TagResponse> CreateAsync(this ITags operations, TagCreateRequest body = default(TagCreateRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
