using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb belongs to collection object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbMovieCollectionPreview : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the collection.
        /// </summary>
        /// <value>The ID of the collection.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the collection.
        /// </summary>
        /// <value>The name of the collection.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the path to the poster of the collection.
        /// </summary>
        /// <value>The path to the poster of the collection.</value>
        [JsonProperty( PropertyName = "poster_path" )]
        public String PosterPath { get; set; }

        /// <summary>
        ///     Gets or sets the path to the backdrop of the collection.
        /// </summary>
        /// <value>The path to the backdrop of the collection.</value>
        [JsonProperty( PropertyName = "backdrop_path" )]
        public String BackdropPath { get; set; }
    }
}