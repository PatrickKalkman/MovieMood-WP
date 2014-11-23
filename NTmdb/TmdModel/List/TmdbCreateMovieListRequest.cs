using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the request sent to the TMDb to create a new movie list.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/list =>      http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
    /// </remarks>
    public class TmdbCreateMovieListRequest : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the name of the list to create.
        /// </summary>
        /// <value>The name of the list to create.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the description of the list to create.
        /// </summary>
        /// <value>The description of the list to create.</value>
        [JsonProperty( PropertyName = "description" )]
        public String Description { get; set; }

        /// <summary>
        ///     Gets or sets the description of the list to create.
        /// </summary>
        /// <remarks>
        ///     I think a ISO 639-1 code is required.
        /// </remarks>
        /// <value>The description of the list to create.</value>
        [JsonProperty( PropertyName = "language" )]
        public String Language { get; set; }
    }
}