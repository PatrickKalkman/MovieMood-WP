using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb configuration.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#configuration
    /// </remarks>
    public class TmdbConfiguration : TmdbModelBase
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the TMDb's image configuration.
        /// </summary>
        /// <value>The TMDb's image configuration.</value>
        [JsonProperty( PropertyName = "images" )]
        public TmdbImageConfiguration ImageConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets a list of all change keys of the TMDb.
        /// </summary>
        /// <value>A list of all change keys of the TMDb.</value>
        [JsonProperty( PropertyName = "change_keys" )]
        public List<String> ChangeKeys { get; set; }

        #endregion Properties
    }
}