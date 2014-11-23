using System;

namespace NTmdb
{
    /// <summary>
    ///     Representing the result of a TMDb API call
    /// </summary>
    public class ApiCallResult : NetworkResultBase, IApiCallResult
    {
        #region Implementation of IApiCallResult

        /// <summary>
        ///     Get or sets the JSON returned by the TMDb API.
        /// </summary>
        /// <value>The JSON returned by the TMDb API.</value>
        public String Json { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP ETag.
        /// </summary>
        /// <value>The HTTP ETag.</value>
        public String ETag { get; set; }

        #endregion Implementation of IApiCallResult
    }
}