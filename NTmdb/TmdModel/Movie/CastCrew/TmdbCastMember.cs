using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb cast(person only, no movie) object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
    /// </remarks>
    public class TmdbCastMember : TmdbPersonBase
    {
        /// <summary>
        ///     Gets or sets the character played by the person.
        /// </summary>
        /// <value>The character played by the person.</value>
        [JsonProperty( PropertyName = "character" )]
        public String Character { get; set; }

        /// <summary>
        ///     Gets or sets the order property.
        /// </summary>
        /// <value>The order property.</value>
        [JsonProperty( PropertyName = "order" )]
        public Int32 Order { get; set; }
    }
}