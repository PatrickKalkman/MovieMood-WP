using System;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing a basic result.
    /// </summary>
    public interface INetworkResult
    {
        /// <summary>
        ///     Gets or sets the URL of of the requested resource.
        /// </summary>
        /// <value>The URL of of the requested resource.</value>
        String SourceUrl { get; set; }

        /// <summary>
        ///     Gets or sets the exception which is occurred during the operation.
        ///     (If one is occurred).
        /// </summary>
        /// <value>The error occurred during the operation, or null.</value>
        Exception Error { get; set; }
    }
}