using System;

namespace NTmdb
{
    /// <summary>
    ///     The result of a streaming operation.
    /// </summary>
    public class FileStreamResult : NetworkResultBase, IFileStreamResult
    {
        #region Implementation of IFileStreamResult

        /// <summary>
        /// Gets or sets the data read from the file stream.
        /// </summary>
        /// <value>The data read from the file stream.</value>
        public Byte[] StreamContent { get; set; }

        #endregion Implementation of IFileStreamResult
    }
}