using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the request sent to the TMDb to add a item to a list.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fadd_item
    /// </remarks>
    public class TmdbListItemRequest : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie, which should get added to a list.
        /// </summary>
        /// <value>The ID of the movie, which should get added to a list.</value>
        [JsonProperty( PropertyName = "media_id" )]
        public Int32 MovieId { get; set; }
    }
}