using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb trailers object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbTrailers : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie to which the trailers belongs.
        /// </summary>
        /// <value>The ID of the movie to which the trailers belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the quicktime trailers.
        /// </summary>
        /// <returns>
        ///     Looks like the TMDb does not provide any quicktime trailers.
        /// </returns>
        /// <value>The quicktime trailers.</value>
        [JsonProperty( PropertyName = "quicktime" )]
        public List<Object> Quicktime { get; set; }

        /// <summary>
        ///     Gets or sets the YouTube trailers.
        /// </summary>
        /// <value>The YouTube trailers.</value>
        [JsonProperty( PropertyName = "youtube" )]
        public List<TmdbTrailer> Youtube { get; set; }
    }
}