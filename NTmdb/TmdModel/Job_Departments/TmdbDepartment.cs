using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's department object.
    /// </summary>
    /// <remarks>
    ///     Used for the following methods:
    ///     /3/job/list =>      http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
    /// </remarks>
    public class TmdbDepartment : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        [JsonProperty( PropertyName = "department" )]
        public String DepartmentName { get; set; }

        /// <summary>
        ///     Gets or sets the jobs which are belonging to the department.
        /// </summary>
        /// <value>The jobs which are belonging to the department.</value>
        [JsonProperty( PropertyName = "job_list" )]
        public List<String> JobList { get; set; }
    }
}