namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all possible sort by values of the TMDb's discover method.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
    /// </remarks>
    public enum TmdbDiscoverySortBy
    {
        /// <summary>
        ///     Do not sort results.
        /// </summary>
        None = -1,

        /// <summary>
        ///     Sort results by average vote (descending).
        /// </summary>
        VoteAverageDesc = 0,

        /// <summary>
        ///     Sort results by average vote (ascending).
        /// </summary>
        VoteAverageAsc = 1,

        /// <summary>
        ///     Sort results by release date (descending).
        /// </summary>
        ReleaseDateDesc = 2,

        /// <summary>
        ///     Sort results by release date (ascending).
        /// </summary>
        ReleaseDateAsc = 3,

        /// <summary>
        ///     Sort results by popularity (descending).
        /// </summary>
        PopularityDesc = 4,

        /// <summary>
        ///     Sort results by popularity (ascending).
        /// </summary>
        PopularityAsc = 5
    }
}