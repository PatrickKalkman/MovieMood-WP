using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's movie list status.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Flist%2F%7Bid%7D%2Fitem_status
    /// </remarks>
    public class TmdbMovieListStaus : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the list.
        /// </summary>
        /// <value>The ID of the list.</value>
        [JsonProperty( PropertyName = "id" )]
        public String Id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether a movie is present in the list or not.
        /// </summary>
        /// <value>A value indicating whether a movie is present in the list or not.</value>
        [JsonProperty( PropertyName = "item_present" )]
        public Boolean IsItemPresent { get; set; }
    }
}