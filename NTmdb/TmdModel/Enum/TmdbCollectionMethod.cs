using System;

namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all collection methods, which can get added to the get collection method.
    /// </summary>
    [Flags]
    public enum TmdbCollectionMethod
    {
        /// <summary>
        ///     Append no no further methods.
        /// </summary>
        None = 1,

        /// <summary>
        ///     Append the images method to the collection method.
        /// </summary>
        Images = 2,

        /// <summary>
        ///     Append all possible methods to the collection method.
        /// </summary>
        All = 3
    }
}