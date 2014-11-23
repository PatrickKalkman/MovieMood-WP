using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's movie collection preview list.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/search/collection =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcollection
    /// </remarks>
    public class TmdbMovieCollectionPreviewList : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets a list of movie collections.
        /// </summary>
        /// <value>A list of movie collections.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbMovieCollectionPreview> MovieCollections { get; set; }
    }
}