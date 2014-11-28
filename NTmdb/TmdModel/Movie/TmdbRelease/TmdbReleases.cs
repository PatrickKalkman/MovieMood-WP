using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb releases object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbReleases : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie to which the releases belongs.
        /// </summary>
        /// <value>The ID of the movie to which the releases belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the releases.
        /// </summary>
        /// <value>The  releases.</value>
        [JsonProperty( PropertyName = "countries" )]
        public List<TmdbRelease> Releases { get; set; }
    }
}