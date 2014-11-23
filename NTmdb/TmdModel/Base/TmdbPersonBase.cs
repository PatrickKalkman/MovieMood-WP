using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Base class for TMDb persons.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbPersonBase : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the person.
        /// </summary>
        /// <value>The ID of the person.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the person.
        /// </summary>
        /// <value>The name of the person.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the path to the profile of the person.
        /// </summary>
        /// <value>The path to the profile of the person.</value>
        [JsonProperty( PropertyName = "profile_path" )]
        public String ProfilePath { get; set; }
    }
}