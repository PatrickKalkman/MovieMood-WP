using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="Task{TResult}" />.
    /// </summary>
    public static class TaskTmdbResultExtension
    {
        /// <summary>
        ///     Unwraps the given <see cref="Task{TmdbResult}" /> and returns the inner result of the task's result.
        /// </summary>
        /// <typeparam name="T">The type of the inner result.</typeparam>
        /// <param name="task">The task to unwrap.</param>
        /// <returns>The inner result, or null if an error is occurred during the API operation.</returns>
        public static async Task<T> Unwrap<T>( this Task<TmdbResult<T>> task ) where T : class
        {
            var tmdbResult = await task;
            return tmdbResult.Unwrap();
        }

        /// <summary>
        ///     Unwraps the given <see cref="Task{TmdbResult}" /> and returns the inner result of the task's result.
        /// </summary>
        /// <typeparam name="T">The type of the inner result.</typeparam>
        /// <param name="task">
        ///     The task to unwrap.
        /// </param>
        /// <exception cref="TmdbException">The result has contained a error.</exception>
        /// <returns>
        ///     The inner result of the given <see cref="Task{TmdbResult}" />.
        /// </returns>
        public static async Task<T> UnwrapOrThrow<T>( this Task<TmdbResult<T>> task ) where T : class
        {
            var tmdbResult = await task;
            return tmdbResult.UnwrapOrThrow();
        }
    }
}