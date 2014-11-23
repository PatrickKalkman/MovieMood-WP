using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's collection images object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
    /// </remarks>
    public class TmdbCollectionImages : TmdbModelBase
    {
        /// <summary>
        /// Gets or sets a list of backdrops.
        /// </summary>
        /// <value>A list of backdrops.</value>
        [JsonProperty( PropertyName = "backdrops" )]
        public List<TmdbImageBase> Backdrops { get; set; }
    }
}