using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb movie lists object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbListBase : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the number of the page.
        /// </summary>
        /// <value>The number of the page.</value>
        [JsonProperty( PropertyName = "page" )]
        public Int32 PageNumber { get; set; }

        /// <summary>
        ///     Gets or sets the total amount of pages.
        /// </summary>
        /// <value>The total amount of pages.</value>
        [JsonProperty( PropertyName = "total_pages" )]
        public Int32 TotalPages { get; set; }

        /// <summary>
        ///     Gets or sets the total amount of ChangedEntries.
        /// </summary>
        /// <value>The total amount of ChangedEntries.</value>
        [JsonProperty( PropertyName = "total_results" )]
        public Int32 TotalResults { get; set; }
    }
}