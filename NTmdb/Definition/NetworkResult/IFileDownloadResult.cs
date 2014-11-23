using System;

namespace NTmdb
{
    /// <summary>
    ///     Represents the result of a file download.
    /// </summary>
    public interface IFileDownloadResult : INetworkResult
    {
        /// <summary>
        ///     Gets or sets the path to the downloaded file,
        ///     only set if the file was downloaded and stored successfully.
        /// </summary>
        /// <value>
        ///     The path to the downloaded file,
        ///     only set if the file was downloaded and stored successfully.
        /// </value>
        String FilePath { get; set; }
    }
}