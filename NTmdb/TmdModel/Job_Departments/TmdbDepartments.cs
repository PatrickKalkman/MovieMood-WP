using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's department array.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/job/list =>      http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
    /// </remarks>
    public class TmdbDepartments : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets a list of departments.
        /// </summary>
        /// <value>A list of departments.</value>
        [JsonProperty( PropertyName = "jobs" )]
        public List<TmdbDepartment> Departments { get; set; }
    }
}