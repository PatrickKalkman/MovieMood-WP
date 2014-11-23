using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb movie lists object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbMovieLists : TmdbMovieListPreviewList
    {
        /// <summary>
        ///     Gets or sets the ID of the movie to which the movie lists belongs.
        /// </summary>
        /// <value>The ID of the movie to which the movie lists belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }
    }
}