namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all possible search types.
    /// </summary>
    public enum TmdbSearchType
    {
        /// <summary>
        ///     No search type set, use TMDb default.
        /// </summary>
        None = -1,

        /// <summary>
        ///     This is almost guaranteed the option you will want. It's a great all purpose search type and by far the most tuned for every day querying.
        /// </summary>
        Phrase = 0,

        /// <summary>
        ///     For those wanting more of an "autocomplete" type search, set this option to 'Ngram'.
        /// </summary>
        Ngram = 1
    }
}