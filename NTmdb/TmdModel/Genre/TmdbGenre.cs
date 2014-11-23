using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb genre object object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#genres
    /// </remarks>
    public class TmdbGenre : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the genre.
        /// </summary>
        /// <value>The ID of the genre.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the genre.
        /// </summary>
        /// <value>The name of the genre.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }
    }
}