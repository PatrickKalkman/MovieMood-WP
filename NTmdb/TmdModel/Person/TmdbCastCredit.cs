using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's cast credit object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
    /// </remarks>
    public class TmdbCastCredit : TmdbCreditMovieBase
    {
        /// <summary>
        ///     Gets or sets the character played by the person to witch the credit belongs.
        /// </summary>
        /// <value>The character played by the person to witch the credit belongs.</value>
        [JsonProperty( PropertyName = "character" )]
        public String Character { get; set; }
    }
}