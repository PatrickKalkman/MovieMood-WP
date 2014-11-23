using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a list of persons.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fpopular
    /// </remarks>
    public class TmdbPersonPreviewList : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets a list of persons.
        /// </summary>
        /// <value>A list of persons.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbPersonPreview> People { get; set; }
    }
}