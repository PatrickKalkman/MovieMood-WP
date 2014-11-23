using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a TMDb movie RatingRequest.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbMovieAccountStates : TmdbModelBase
    {
        #region Fields

        /// <summary>
        ///     Used to cache the result of a JSON deserialization.
        /// </summary>
        private TmdbMovieRatingRequest _ratingRequest;

        #endregion Fields

        /// <summary>
        ///     Gets ors sets the ID of the movie to which the state belongs.
        /// </summary>
        /// <value>The ID of the movie to which the state belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the user has added the movie to the favorite list or not.
        /// </summary>
        /// <value>A value indicating whether the user has added the movie to the favorite list or not.</value>
        [JsonProperty( PropertyName = "favorite" )]
        public Boolean Favorite { get; set; }

        /// <summary>
        ///     Gets or sets the RatingRequest of the movie.
        /// </summary>
        /// <value>The RatingRequest of the movie.</value>
        /// <summary>
        ///     Gets or sets a value indicating whether the user has added the movie to the watch list or not.
        /// </summary>
        /// <value>A value indicating whether the user has added the movie to the watch list or not.</value>
        [JsonProperty( PropertyName = "watchlist" )]
        public Boolean Watchlist { get; set; }

        /// <summary>
        ///     Gets or sets the rated value of the TMDb object.
        /// </summary>
        /// <value>The rated value of the TMDb object.</value>
        [JsonProperty( PropertyName = "rated" )]
        private dynamic RatedValue { get; set; }

        /// <summary>
        ///     Gets a value indicating whether the user has rated the movie with the specified ID or not.
        /// </summary>
        /// <remarks>
        ///     Value parsed based on <see cref="RatedValue" />.
        /// </remarks>
        /// <value>A value indicating whether the user has rated the movie with the specified ID or not.</value>
        public Boolean RatedByUser
        {
            get { return !( RatedValue is Boolean ) || ( Boolean ) RatedValue; }
        }

        /// <summary>
        ///     Gets the user's RatingRequest of the movie with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Value parsed based on <see cref="RatedValue" />.
        /// </remarks>
        /// <value>The user's RatingRequest of the movie with the specified ID, or null if the user has not rated the movie.</value>
        public TmdbMovieRatingRequest RatingRequest
        {
            get
            {
                if ( RatedValue is Boolean )
                    return null;
                return _ratingRequest ?? ( _ratingRequest = JsonConvert.DeserializeObject<TmdbMovieRatingRequest>( RatedValue.ToString() ) );
            }
        }
    }
}