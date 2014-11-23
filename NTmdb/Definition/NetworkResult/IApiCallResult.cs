using System;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing the result of a TMDb API call.
    /// </summary>
    public interface IApiCallResult : INetworkResult
    {
        /// <summary>
        ///     Get or sets the JSON returned by the TMDb API.
        /// </summary>
        /// <value>The JSON returned by the TMDb API.</value>
        String Json { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP ETag.
        /// </summary>
        /// <value>The HTTP ETag.</value>
        String ETag { get; set; }
    }
}