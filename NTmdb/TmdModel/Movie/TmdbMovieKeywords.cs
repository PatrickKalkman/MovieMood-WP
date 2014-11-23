using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb keywords object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbMovieKeywords : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie to which the keywords belongs.
        /// </summary>
        /// <value>The ID of the movie to which the keywords belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the keyword.
        /// </summary>
        /// <value>The keyword.</value>
        [JsonProperty( PropertyName = "keywords" )]
        public List<TmdbKeyword> Keywords { get; set; }
    }
}