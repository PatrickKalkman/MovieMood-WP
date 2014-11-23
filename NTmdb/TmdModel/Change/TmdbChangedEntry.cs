using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's changed entry object.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/movie/changes =>      http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
    ///     /3/person/changes =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
    /// </remarks>
    public class TmdbChangedEntry : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the entry which has changed.
        /// </summary>
        /// <value>he ID of the movie entry has changed.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the entry contains adult content or not.
        /// </summary>
        /// <value>A value indicating whether the entry contains adult content or not.</value>
        [JsonProperty( PropertyName = "adult" )]
        public Boolean? IsAdult { get; set; }
    }
}