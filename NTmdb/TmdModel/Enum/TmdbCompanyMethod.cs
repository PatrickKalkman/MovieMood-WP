using System;

namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all company methods, which can get added to the get company method.
    /// </summary>
    [Flags]
    public enum TmdbCompanyMethod
    {
        /// <summary>
        ///     Append no no further methods.
        /// </summary>
        None = 1,

        /// <summary>
        ///     Append the movies method to the company method.
        /// </summary>
        Movies = 2,

        /// <summary>
        ///     Append all possible methods to the company method.
        /// </summary>
        All = 3
    }
}