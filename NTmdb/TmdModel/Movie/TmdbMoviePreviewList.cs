using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's user lists object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Flists
    ///     http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fupcoming
    ///     http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fnow_playing
    ///     http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D%2Fsimilar_movies
    ///     http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fpopular
    /// </remarks>
    public class TmdbMoviePreviewList : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets the movies.
        /// </summary>
        /// <value>The movie.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdbMoviePreview> Movies { get; set; }
    }
}