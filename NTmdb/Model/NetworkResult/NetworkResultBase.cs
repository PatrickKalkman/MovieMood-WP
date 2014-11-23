using System;

namespace NTmdb
{
    /// <summary>
    ///     Base class for a network result
    /// </summary>
    public class NetworkResultBase : INetworkResult
    {
        #region Implementation of INetworkResult

        /// <summary>
        ///     Gets or sets the URL of of the requested resource.
        /// </summary>
        /// <value>The URL of of the requested resource.</value>
        public String SourceUrl { get; set; }

        /// <summary>
        ///     Gets or sets the exception which is occurred during the operation.
        ///     (If one is occurred).
        /// </summary>
        /// <value>The error occurred during the operation, or null.</value>
        public Exception Error { get; set; }

        #endregion Implementation of INetworkResult
    }
}