using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb reviews object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbMovieReviews : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie to which the reviews belongs.
        /// </summary>
        /// <value>The ID of the movie to which the reviews belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the reviews.
        /// </summary>
        /// <value>The reviews.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbReviewPreview> Reviews { get; set; }
    }
}