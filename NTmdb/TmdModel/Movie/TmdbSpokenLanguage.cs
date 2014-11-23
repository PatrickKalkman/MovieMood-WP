using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb spoken language object used in the movie object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbSpokenLanguage : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ISO 639 1 code of the language.
        /// </summary>
        /// <value>The ISO 639 1 code of the language.</value>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public Int32 Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the name of the language.
        /// </summary>
        /// <value>The name of the language.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }
    }
}