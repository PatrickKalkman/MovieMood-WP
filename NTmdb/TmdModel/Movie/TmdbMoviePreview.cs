using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a limited set of information about a movie.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    ///     Used for the similar movie and upcoming methods.
    /// </remarks>
    public class TmdbMoviePreview : TmdbMoviePreviewBase
    {
        /// <summary>
        ///     Gets or sets the path to the movies backdrop.
        /// </summary>
        /// <value>The path to the movies backdrop.</value>
        [JsonProperty( PropertyName = "backdrop_path" )]
        public String BackdropPath { get; set; }

        /// <summary>
        ///     Gets or sets the average vote of the movie.
        /// </summary>
        /// <value>The average vote of the movie.</value>
        [JsonProperty( PropertyName = "vote_average" )]
        public Double VoteAverage { get; set; }

        /// <summary>
        ///     Gets or sets the vote count of the movie.
        /// </summary>
        /// <value>The vote count of the movie.</value>
        [JsonProperty( PropertyName = "vote_count" )]
        public Int32 VoteCount { get; set; }
    }
}