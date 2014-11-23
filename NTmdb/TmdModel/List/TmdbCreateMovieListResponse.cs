using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the response returned by the TMDb when a new list was created.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/list =>      http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
    /// </remarks>
    public class TmdbCreateMovieListResponse : TmdbStatusResponse
    {
        /// <summary>
        ///     Gets or sets the ID of the new created list.
        /// </summary>
        /// <value>The ID of the new created list.</value>
        [JsonProperty( PropertyName = "list_id" )]
        public String ListId { get; set; }
    }
}