using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's company information object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D
    /// </remarks>
    public class TmdbCompanyInformation : TmdCompanyPreview
    {
        /// <summary>
        ///     Gets or sets the description of the company.
        /// </summary>
        /// <value>The description of the company.</value>
        [JsonProperty( PropertyName = "description" )]
        public String Description { get; set; }

        /// <summary>
        ///     Gets or sets the headquarter of the company.
        /// </summary>
        /// <value>The headquarter of the company.</value>
        [JsonProperty( PropertyName = "headquarters" )]
        public String Headquarter { get; set; }

        /// <summary>
        ///     Gets or sets the homepage of the company.
        /// </summary>
        /// <value>The homepage of the company.</value>
        [JsonProperty( PropertyName = "homepage" )]
        public String Homepage { get; set; }

        /// <summary>
        ///     Gets or sets the parent company of the company.
        /// </summary>
        /// <value>The parent company of the company.</value>
        [JsonProperty( PropertyName = "parent_company" )]
        public TmdbCompanyInformation ParentCompany { get; set; }

        /// <summary>
        ///     Gets or sets the movies made by the company.
        /// </summary>
        /// <remarks>
        ///     Value is only set if the movies method was appended to the request.
        /// </remarks>
        /// <value>The movies made by the company.</value>
        [JsonProperty( PropertyName = "movies" )]
        public TmdbMoviePreviewList Movies { get; set; }
    }
}