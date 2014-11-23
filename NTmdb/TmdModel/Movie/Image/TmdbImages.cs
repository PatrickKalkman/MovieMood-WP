using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb images object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbImages : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the id of the movie to which the images belongs.
        /// </summary>
        /// <value>The id of the movie to which the images belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the backdrops.
        /// </summary>
        /// <value>The backdrops.</value>
        [JsonProperty( PropertyName = "backdrops" )]
        public List<TmdbImage> Backdrops { get; set; }

        /// <summary>
        ///     Gets or sets the posters.
        /// </summary>
        /// <value>The posters.</value>
        [JsonProperty( PropertyName = "posters" )]
        public List<TmdbImage> Posters { get; set; }
    }
}