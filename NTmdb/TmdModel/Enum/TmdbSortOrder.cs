namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all TMDb sort orders.
    /// </summary>
    public enum TmdbSortOrder
    {
        /// <summary>
        ///     No sort order set, use TMDb default.
        /// </summary>
        Unset = -1,

        /// <summary>
        ///     Ascending sort order
        /// </summary>
        Ascending = 0,

        /// <summary>
        ///     Descending sort order
        /// </summary>
        Descending = 1
    }
}