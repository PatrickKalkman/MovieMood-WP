using System;

namespace NTmdb
{
    /// <summary>
    ///     Represent the result of a TMDb method.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    public class TmdbResult<T> : ITmdbResult<T> where T : class
    {
        /// <summary>
        ///     Gets or sets the result.
        /// </summary>
        /// <value>The result, or null if the method has thrown an exception.</value>
        public T Result { get; set; }

        /// <summary>
        ///     Gets or sets the exception which is occurred during the method call.
        ///     (If one is occurred).
        /// </summary>
        /// <value>The error occurred during the method call, or null.</value>
        public Exception Error { get; set; }

        /// <summary>
        ///     Gets or sets the status response returned by the TMDb API.
        /// </summary>
        /// <remarks>
        ///     Note: This property will only be set, if your API call failed
        ///     and the API client was able to read a status response from the
        ///     response stream.
        /// </remarks>
        /// <value>The status response returned by the TMDb API.</value>
        public TmdbStatusResponse ApiErrorResponse { get; set; }
    }
}