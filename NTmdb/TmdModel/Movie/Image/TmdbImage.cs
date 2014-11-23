using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb image object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbImage : TmdbImageBase
    {
        /// <summary>
        ///     Gets or sets the average vote of the image.
        /// </summary>
        /// <value>The average vote of the image.</value>
        [JsonProperty( PropertyName = "vote_average" )]
        public Double VoteAverage { get; set; }

        /// <summary>
        ///     Gets or sets the vote count of the image.
        /// </summary>
        /// <value>The vote count of the image.</value>
        [JsonProperty( PropertyName = "vote_count" )]
        public Int32 VoteCount { get; set; }
    }
}