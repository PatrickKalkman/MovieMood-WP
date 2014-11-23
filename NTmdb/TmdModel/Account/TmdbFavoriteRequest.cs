using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the request sent to the TMDb to add a movie to the favorites.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite
    /// </remarks>
    public class TmdbFavoriteRequest : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie which should get marked as favorite.
        /// </summary>
        /// <value>The ID of the movie which should get marked as favorite.</value>
        [JsonProperty( PropertyName = "movie_id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets whether the movie should get added to the favorites or not.
        /// </summary>
        /// <value>A value determining whether the movie should get added to the favorites or not.</value>
        [JsonProperty( PropertyName = "favorite" )]
        public Boolean AddToFavorite { get; set; }
    }
}