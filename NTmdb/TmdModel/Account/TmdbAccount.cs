using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb account object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#account
    /// </remarks>
    public class TmdbAccount : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the account.
        /// </summary>
        /// <value>The ID of the account.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether adult content is enabled for the account or not.
        /// </summary>
        /// <value>A value indicating whether adult content is enabled for the account or not.</value>
        [JsonProperty( PropertyName = "includeAdult" )]
        public Boolean IncludeAdult { get; set; }

        /// <summary>
        ///     Gets or sets the ISO 3166-1 country code of the account.
        /// </summary>
        /// <value>The ISO 3166-1 country code of the account.</value>
        [JsonProperty( PropertyName = "iso_3166_1" )]
        public String Iso3166_1 { get; set; }

        /// <summary>
        ///     Gets or sets the ISO 639-1 language code of the account.
        /// </summary>
        /// <value>The ISO 639-1 language code of the account.</value>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public String Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the username of the account.
        /// </summary>
        /// <value>The username of the account.</value>
        [JsonProperty( PropertyName = "username" )]
        public String Username { get; set; }
    }
}