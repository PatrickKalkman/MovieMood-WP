namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all valid filter operators.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
    /// </remarks>
    public enum TmdbFilterOperator
    {
        /// <summary>
        ///     Filters are getting aggregated to a 'and' query.
        /// </summary>
        And = 0,

        /// <summary>
        ///     Filters are getting aggregated to a 'or' query.
        /// </summary>
        Or = 1,
    }
}