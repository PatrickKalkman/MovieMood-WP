using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's collection part object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D
    /// </remarks>
    public class TmdbMovieCollectionPart : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie.
        /// </summary>
        /// <value>The ID of the movie.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the title of the movie.
        /// </summary>
        /// <value>The title of the movie.</value>
        [JsonProperty( PropertyName = "title" )]
        public String Title { get; set; }

        /// <summary>
        ///     Gets or sets the release date of the movie.
        /// </summary>
        /// <value>The release date of the movie.</value>
        [JsonProperty( PropertyName = "release_date" )]
        public String ReleaseDateString { get; set; }

        /// <summary>
        ///     Gets or sets the path to the poster of the movie.
        /// </summary>
        /// <value>The path to the poster of the movie.</value>
        [JsonProperty( PropertyName = "poster_path" )]
        public String PosterPath { get; set; }

        /// <summary>
        ///     Gets or sets the path to the backdrop of the movie.
        /// </summary>
        /// <value>The path to the backdrop of the movie.</value>
        [JsonProperty( PropertyName = "backdrop_path" )]
        public String BackdropPath { get; set; }
    }
}