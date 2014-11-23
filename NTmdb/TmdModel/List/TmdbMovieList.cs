using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's movie list object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Flist%2F%7Bid%7D
    /// </remarks>
    public class TmdbMovieList : TmdbMovieListPreview
    {
        /// <summary>
        ///     Gets ors sets the originator of the movie list.
        /// </summary>
        /// <value>The originator of the movie list.</value>
        [JsonProperty( PropertyName = "created_by" )]
        public String CreatedBy { get; set; }

        /// <summary>
        ///     Gets ors sets the movies which are in the list.
        /// </summary>
        /// <value>The movies which are in the list.</value>
        [JsonProperty( PropertyName = "items" )]
        public List<TmdbMoviePreview> Movies { get; set; }
    }
}