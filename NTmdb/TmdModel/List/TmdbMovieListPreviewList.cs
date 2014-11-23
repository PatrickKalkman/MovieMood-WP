using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's movie list preview list object.
    /// </summary>
    public class TmdbMovieListPreviewList : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets a list of movie list previews.
        /// </summary>
        /// <value>A list of movie list previews.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbMovieListPreview> MovieListPreviews { get; set; }
    }
}