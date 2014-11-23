namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbResult{T}" />.
    /// </summary>
    public static class TmdbResultExtension
    {
        /// <summary>
        ///     Unwraps the given <see cref="TmdbResult{T}" /> and returns its inner result.
        /// </summary>
        /// <typeparam name="T">The type of the inner result.</typeparam>
        /// <param name="tmdbResult">
        ///     The <see cref="TmdbResult{T}" /> to unwrap.
        /// </param>
        /// <returns>
        ///     The inner result of the given <see cref="TmdbResult{T}" />, or null if an error is occurred during the API operation.
        /// </returns>
        public static T Unwrap<T>( this TmdbResult<T> tmdbResult ) where T : class
        {
            return tmdbResult.Error == null ? tmdbResult.Result : null;
        }

        /// <summary>
        ///     Unwraps the given <see cref="TmdbResult{T}" /> and returns its inner result.
        /// </summary>
        /// <typeparam name="T">The type of the inner result.</typeparam>
        /// <param name="tmdbResult">
        ///     The <see cref="TmdbResult{T}" /> to unwrap.
        /// </param>
        /// <exception cref="TmdbException">The result has contained a error.</exception>
        /// <returns>
        ///     The inner result of the given <see cref="TmdbResult{T}" />.
        /// </returns>
        public static T UnwrapOrThrow<T>( this TmdbResult<T> tmdbResult ) where T : class
        {
            if ( tmdbResult.Error != null )
                throw new TmdbException( tmdbResult.Error, tmdbResult.ApiErrorResponse );
            return tmdbResult.Result;
        }
    }
}