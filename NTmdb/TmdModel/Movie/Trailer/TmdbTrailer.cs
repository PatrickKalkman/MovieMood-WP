using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb video object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbTrailer : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the name of the video.
        /// </summary>
        /// <value>The name of the video.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the size of the video.
        /// </summary>
        /// <value>The size of the video.</value>
        [JsonProperty( PropertyName = "size" )]
        public String Size { get; set; }

        /// <summary>
        ///     Gets or sets the source of the video.
        /// </summary>
        /// <value>The source of the video.</value>
        [JsonProperty( PropertyName = "source" )]
        public String Source { get; set; }
    }
}