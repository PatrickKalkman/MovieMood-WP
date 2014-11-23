using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's keyword list object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fkeyword
    /// </remarks>
    public class TmdbKeywords : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets a list of keywords.
        /// </summary>
        /// <value>A list of keywords.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbKeyword> Keywords { get; set; }
    }
}