using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb translation object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbTranslation : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ISO 639-1 language code of the language.
        /// </summary>
        /// <value>The ISO 639-1 language code of the language.</value>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public String Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the name of the language.
        /// </summary>
        /// <value>The name of the language.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the name of the English name of the language.
        /// </summary>
        /// <value>The name of the English name of the language.</value>
        [JsonProperty( PropertyName = "english_name" )]
        public String EnglishName { get; set; }
    }
}