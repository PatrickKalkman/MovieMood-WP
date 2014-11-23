using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb session object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#authentication
    /// </remarks>
    public class TmdbSession : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets whether the session was created successfully.
        /// </summary>
        /// <value>A value indicating whether the session was created successfully.</value>
        [JsonProperty( PropertyName = "success" )]
        public Boolean Success { get; set; }

        /// <summary>
        ///     Gets or sets the session ID.
        /// </summary>
        /// <value>The session ID.</value>
        [JsonProperty( PropertyName = "session_id" )]
        public String SessionId { get; set; }
    }
}