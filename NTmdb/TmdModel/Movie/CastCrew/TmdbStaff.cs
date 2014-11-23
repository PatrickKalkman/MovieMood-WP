using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb cast (cast + crew) object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbStaff : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the id of the movie to which the cast belongs.
        /// </summary>
        /// <value>The id of the movie to which the cast belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the cast.
        /// </summary>
        /// <value>The cast.</value>
        [JsonProperty( PropertyName = "cast" )]
        public List<TmdbCastMember> Cast { get; set; }

        /// <summary>
        ///     Gets or sets the crew.
        /// </summary>
        /// <value>The crew.</value>
        [JsonProperty( PropertyName = "crew" )]
        public List<TmdbCrewMember> Crew { get; set; }
    }
}