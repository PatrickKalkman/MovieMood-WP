using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb changes object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbChanges : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the changes.
        /// </summary>
        /// <value>The changes.</value>
        [JsonProperty( PropertyName = "changes" )]
        public List<TmdbChange> Changes { get; set; }
    }
}