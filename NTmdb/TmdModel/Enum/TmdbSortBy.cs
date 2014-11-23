namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all properties, which are valid for sorting.
    /// </summary>
    public enum TmdbSortBy
    {
        /// <summary>
        ///     No sort property set, use TMDb default.
        /// </summary>
        None = -1,

        /// <summary>
        ///     Sort results by created_at.
        /// </summary>
        CreatedAt = 0,
    }
}