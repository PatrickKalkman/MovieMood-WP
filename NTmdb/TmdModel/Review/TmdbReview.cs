using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's review object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Freview%2F%7Bid%7D
    /// </remarks>
    public class TmdbReview : TmdbReviewPreview
    {
        /// <summary>
        ///     Gets or sets the IDO 639-1 language code of the review.
        /// </summary>
        /// <remarks>The IDO 639-1 language code of the review.</remarks>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public String Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the media ID of the review.
        /// </summary>
        /// <value>The media ID of the review.</value>
        [JsonProperty( PropertyName = "media_id" )]
        public Int32 MediaId { get; set; }

        /// <summary>
        ///     Gets or sets the title of the review.
        /// </summary>
        /// <value>The title of the review.</value>
        [JsonProperty( PropertyName = "media_title" )]
        public String MediaTitle { get; set; }

        /// <summary>
        ///     Gets or sets the type of the media.
        /// </summary>
        /// <value>The type e of the media.</value>
        [JsonProperty( PropertyName = "media_type" )]
        public String MediaType { get; set; }
    }
}