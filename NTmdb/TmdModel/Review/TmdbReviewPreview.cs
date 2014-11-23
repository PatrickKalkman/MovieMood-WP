using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's review preview object.
    /// </summary>
    public class TmdbReviewPreview : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the review.
        /// </summary>
        /// <value>The ID of the review.</value>
        [JsonProperty( PropertyName = "id" )]
        public String Id { get; set; }

        /// <summary>
        ///     Gets or sets the author of the review.
        /// </summary>
        /// <value>The author of the review.</value>
        [JsonProperty( PropertyName = "author" )]
        public String Author { get; set; }

        /// <summary>
        ///     Gets or sets the content of the review.
        /// </summary>
        /// <value>The content of the review.</value>
        [JsonProperty( PropertyName = "content" )]
        public String Content { get; set; }

        /// <summary>
        ///     Gets or sets the URL of the review.
        /// </summary>
        /// <value>The URL of the review.</value>
        [JsonProperty( PropertyName = "url" )]
        public String Url { get; set; }
    }
}