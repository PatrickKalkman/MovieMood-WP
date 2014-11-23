using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's production company preview object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcompany
    /// </remarks>
    public class TmdCompanyPreview : TmdbCompanyBasic
    {
        /// <summary>
        ///     Gets or sets the path to the logo of the image.
        /// </summary>
        /// <value>The path to the logo of the image.</value>
        [JsonProperty( PropertyName = "logo_path" )]
        public String LogoPath { get; set; }
    }
}