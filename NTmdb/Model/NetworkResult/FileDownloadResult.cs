using System;

namespace NTmdb
{
    /// <summary>
    ///     The result of a file download operation.
    /// </summary>
    public class FileDownloadResult : NetworkResultBase, IFileDownloadResult
    {
        #region Implementation of IFileDownloadResult

        /// <summary>
        ///     Gets or sets the path to the downloaded file,
        ///     only set if the file was downloaded and stored successfully.
        /// </summary>
        /// <value>
        ///     The path to the downloaded file,
        ///     only set if the file was downloaded and stored successfully.
        /// </value>
        public String FilePath { get; set; }

        #endregion Implementation of IFileDownloadResult
    }
}