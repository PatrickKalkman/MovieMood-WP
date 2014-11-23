using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a TMDb status response.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite
    ///     http://docs.themoviedb.apiary.io/#post-%2F3%2Fmovie%2F%7Bid%7D%2Frating
    /// </remarks>
    public class TmdbStatusResponse : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the status code returned by the TMDb.
        /// </summary>
        /// <value>The status code returned by the TMDb.</value>
        [JsonProperty( PropertyName = "status_code" )]
        public Int32 StatusCode { get; set; }

        /// <summary>
        ///     Gets or sets the status message returned by the TMDb.
        /// </summary>
        /// <value>The status message returned by the TMDb.</value>
        [JsonProperty( PropertyName = "status_message" )]
        public String StatusMessage { get; set; }
    }
}