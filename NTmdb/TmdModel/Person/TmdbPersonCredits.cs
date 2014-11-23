using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb person credits object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
    /// </remarks>
    public class TmdbPersonCredits : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the roles which the person has played.
        /// </summary>
        /// <value>The roles which the person has played.</value>
        [JsonProperty( PropertyName = "cast" )]
        public List<TmdbCastCredit> Cast { get; set; }

        /// <summary>
        ///     Gets or sets the non-acting jobs which the person has done.
        /// </summary>
        /// <value>The non-acting jobs which the person has done.</value>
        [JsonProperty( PropertyName = "crew" )]
        public List<TmdbCrewCredit> Crew { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the person to which the credits belongs.
        /// </summary>
        /// <value>The ID of the person to which the credits belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }
    }
}