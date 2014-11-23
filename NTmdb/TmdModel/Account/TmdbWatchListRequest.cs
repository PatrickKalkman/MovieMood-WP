using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the request sent to the TMDb to add/remove a movie to/from the watch list.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
    /// </remarks>
    public class TmdbWatchListRequest : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie which should get added/removed to/from the watch list.
        /// </summary>
        /// <value>The ID of the movie which should get added/removed to/from the watch list.</value>
        [JsonProperty( PropertyName = "movie_id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets whether the movie should get added to the watch list or not.
        /// </summary>
        /// <value>A value determining whether the movie should get added to the watch list or not.</value>
        [JsonProperty( PropertyName = "movie_watchlist" )]
        public Boolean AddToWatchList { get; set; }
    }
}