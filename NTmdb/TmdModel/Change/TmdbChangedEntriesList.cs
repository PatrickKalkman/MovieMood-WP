using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's changed entry list object.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/movie/changes =>      http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
    ///     /3/person/changes =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
    /// </remarks>
    public class TmdbChangedEntriesList : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets a list of entries which has changed.
        /// </summary>
        /// <value>A list of entries which has changed.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbChangedEntry> ChangedEntries { get; set; }
    }
}