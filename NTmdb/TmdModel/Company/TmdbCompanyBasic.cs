using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb production company object used in the movie object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbCompanyBasic : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the production company.
        /// </summary>
        /// <value>The ID of the production company.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the production company.
        /// </summary>
        /// <value>The name of the production company.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }
    }
}