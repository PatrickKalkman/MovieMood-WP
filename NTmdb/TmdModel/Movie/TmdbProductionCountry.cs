using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb production company object used in the movie object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbProductionCountry : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ISO 3166 1 code of the production country.
        /// </summary>
        /// <value>The ISO 3166 1 code of the production country.</value>
        [JsonProperty( PropertyName = "iso_3166_1" )]
        public String Iso3166_1 { get; set; }

        /// <summary>
        ///     Gets or sets the name of the production country.
        /// </summary>
        /// <value>The name of the production country.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }
    }
}