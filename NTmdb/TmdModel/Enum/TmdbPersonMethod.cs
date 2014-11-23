using System;

namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all person methods, which can get added to the get person method.
    /// </summary>
    [Flags]
    public enum TmdbPersonMethod
    {
        /// <summary>
        ///     Append no no further methods.
        /// </summary>
        None = 1,

        /// <summary>
        ///     Append the credits method to the person method.
        /// </summary>
        Credits = 2,

        /// <summary>
        ///     Append the images method to the person method.
        /// </summary>
        Images = 4,

        /// <summary>
        ///     Append the credits and images methods to the person method.
        /// </summary>
        CreditsAndIamges = 7,

        /// <summary>
        ///     Append the changes method to the person method.
        /// </summary>
        Changes = 8,

        /// <summary>
        ///     Append all possible methods to the person method.
        /// </summary>
        All = 15
    }
}