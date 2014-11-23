using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's person image object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
    /// </remarks>
    public class TmdbPersonImages : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the person to which the images belongs.
        /// </summary>
        /// <value>The ID of the person to which the images belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the images of the person.
        /// </summary>
        /// <value>The image of the person.</value>
        [JsonProperty( PropertyName = "profiles" )]
        public List<TmdbImageBase> Images { get; set; }
    }
}