using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb alternative title object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbAlternativeTitle : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ISO 3166 1 code of the country where the title comes from.
        /// </summary>
        /// <value>he ISO 3166 1 code of the country where the title comes from.</value>
        [JsonProperty( PropertyName = "iso_3166_1" )]
        public String Iso3166_1 { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty( PropertyName = "title" )]
        public String Title { get; set; }
    }
}