using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's production company preview object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcompany
    /// </remarks>
    public class TmdCompanyPreviewList : TmdbListBase
    {
        /// <summary>
        ///     Gets or sets a list of company previews.
        /// </summary>
        /// <value>A list of company previews.</value>
        [JsonProperty( PropertyName = "results" )]
        public List<TmdCompanyPreview> Companies { get; set; }
    }
}