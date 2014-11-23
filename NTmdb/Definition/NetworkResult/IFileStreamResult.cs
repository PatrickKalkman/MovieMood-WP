using System;

namespace NTmdb
{
    /// <summary>
    ///     Represents the result of a file stream operation.
    /// </summary>
    public interface IFileStreamResult : INetworkResult
    {
        /// <summary>
        /// Gets or sets the data read from the file stream.
        /// </summary>
        /// <value>The data read from the file stream.</value>
        Byte[] StreamContent { get; set; }
    }
}