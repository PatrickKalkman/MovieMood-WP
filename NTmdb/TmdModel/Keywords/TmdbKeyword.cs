using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb keyword object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbKeyword : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the keyword.
        /// </summary>
        /// <value>The ID of the keyword.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the keyword.
        /// </summary>
        /// <value>The name of the keyword.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }
    }
}