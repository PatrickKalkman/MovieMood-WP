using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing A TMDb collection object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D
    /// </remarks>
    public class TmdbMovieCollection : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the path to the backdrop of the collection.
        /// </summary>
        /// <value>The path to the backdrop of the collection.</value>
        [JsonProperty( PropertyName = "backdrop_path" )]
        public String BackdropPath { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the collection.
        /// </summary>
        /// <value>TheID of the collection.</value>
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
        ///     Gets or sets the movies which are in the collection.
        /// </summary>
        /// <value>The movies which are in the collection.</value>
        [JsonProperty( PropertyName = "parts" )]
        public List<TmdbMovieCollectionPart> Movies { get; set; }

        #region Appended Methods

        /// <summary>
        ///     Gets or sets the images of the person.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the images method was appended to the collection method.
        /// </remarks>
        /// <value>The images of the person.</value>
        [JsonProperty( PropertyName = "images" )]
        public TmdbCollectionImages Images { get; set; }

        #endregion Appended Methods
    }
}