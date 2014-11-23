using System;

namespace NTmdb
{
    /// <summary>
    ///     Represents errors that occur during calls to the TMDb API.
    /// </summary>
    public class TmdbException : Exception
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="TmdbException" /> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public TmdbException( Exception innerException )
            : this( innerException, null )
        {
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="TmdbException" /> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        /// <param name="apiError">The error returned by the TMDb API.</param>
        public TmdbException( Exception innerException, TmdbStatusResponse apiError )
            : base( "An TMDb exception is occurred. For details check the inner exception and the API error.", innerException )
        {
            ApiError = apiError;
        }

        /// <summary>
        ///     Gets the error returned by the TMDb API.
        /// </summary>
        /// <value>The error returned by the TMDb API.</value>
        public TmdbStatusResponse ApiError { get; private set; }
    }
}