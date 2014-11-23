using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb change object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbChange : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the key of the change.
        /// </summary>
        /// <value> The key of the change.</value>
        [JsonProperty( PropertyName = "key" )]
        public String Key { get; set; }

        /// <summary>
        ///     Gets or sets the changed items.
        /// </summary>
        /// <value>The changed items.</value>
        [JsonProperty( PropertyName = "items" )]
        public List<TmdbChangeItem> ChangedItems { get; set; }
    }
}