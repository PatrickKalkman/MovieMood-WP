using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb release object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbRelease : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ISO 3166-1 country code of the country where the release comes from.
        /// </summary>
        /// <value>The ISO 3166-1 country code of the country where the release comes from.</value>
        [JsonProperty( PropertyName = "iso_3166_1" )]
        public String Iso3166_1 { get; set; }

        /// <summary>
        ///     Gets or sets the certification of the release.
        /// </summary>
        /// <value>The certification of the release.</value>
        [JsonProperty( PropertyName = "certification" )]
        public String Certification { get; set; }

        /// <summary>
        ///     Gets or sets the release data.
        /// </summary>
        /// <value>The release data.</value>
        [JsonProperty( PropertyName = "release_date" )]
        public String ReleaseDate { get; set; }
    }
}