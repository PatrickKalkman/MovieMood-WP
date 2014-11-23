using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's crew credit object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
    /// </remarks>
    public class TmdbCrewCredit : TmdbCreditMovieBase
    {
        /// <summary>
        ///     Gets or sets the department for which the person has worked.
        /// </summary>
        /// <value>The department for which the person has worked.</value>
        [JsonProperty( PropertyName = "department" )]
        public String Department { get; set; }

        /// <summary>
        ///     Gets or sets the job which the person has done.
        /// </summary>
        /// <value>The job which the person has done.</value>
        [JsonProperty( PropertyName = "job" )]
        public String Job { get; set; }
    }
}