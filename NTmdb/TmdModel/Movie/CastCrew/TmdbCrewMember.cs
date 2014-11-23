using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb crew object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D%2Fcasts
    ///     http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
    /// </remarks>
    public class TmdbCrewMember : TmdbPersonBase
    {
        /// <summary>
        ///     Gets or sets the name of the department for which the person has worked.
        /// </summary>
        /// <value>The name of the department for which the person has worked.</value>
        [JsonProperty( PropertyName = "department" )]
        public String Department { get; set; }

        /// <summary>
        ///     Gets or sets the job of the person.
        /// </summary>
        /// <value>The job of the person.</value>
        [JsonProperty( PropertyName = "job" )]
        public String Job { get; set; }
    }
}