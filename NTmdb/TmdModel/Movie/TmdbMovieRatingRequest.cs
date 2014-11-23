using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a RatingRequest of a movie.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    ///     Used as request content.
    /// </remarks>
    public class TmdbMovieRatingRequest : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the value of the RatingRequest (1-10).
        /// </summary>
        /// <value>The value of the RatingRequest (1-10).</value>
        [JsonProperty( PropertyName = "value" )]
        public Double Value { get; set; }
    }
}