using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Base class for a credit of a person.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
    /// </remarks>
    public class TmdbCreditMovieBase : TmdbMoviePreviewBase
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the movie is an adult movie or not.
        /// </summary>
        /// <value>A value indicating whether the movie is an adult movie or not.</value>
        [JsonProperty( PropertyName = "adult" )]
        public Boolean Adult { get; set; }
    }
}