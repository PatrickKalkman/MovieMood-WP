using System;

namespace NTmdb
{
    /// <summary>
    ///     Enumeration of all movie methods, which can get added to the get movie method.
    /// </summary>
    [Flags]
    public enum TmdbMovieMethod
    {
        /// <summary>
        ///     Append no no further methods.
        /// </summary>
        None = 1,

        /// <summary>
        ///     Append the alternative titles method to the movie method.
        /// </summary>
        AlternativeTitles = 2,

        /// <summary>
        ///     Append the casts method to the movie method.
        /// </summary>
        Casts = 4,

        /// <summary>
        ///     Append the images method to the movie method.
        /// </summary>
        Images = 8,

        /// <summary>
        ///     Append the keywords method to the movie method.
        /// </summary>
        Keywords = 16,

        /// <summary>
        ///     Append the releases method to the movie method.
        /// </summary>
        Releases = 32,

        /// <summary>
        ///     Append the trailers method to the movie method.
        /// </summary>
        Trailers = 64,

        /// <summary>
        ///     Append the translations method to the movie method.
        /// </summary>
        Translations = 128,

        /// <summary>
        ///     Append the similar movies method to the movie method.
        /// </summary>
        SimilarMovies = 256,

        /// <summary>
        ///     Append the reviews method to the movie method.
        /// </summary>
        Reviews = 512,

        /// <summary>
        ///     Append the lists method to the movie method.
        /// </summary>
        Lists = 1024,

        /// <summary>
        ///     Append the changes method to the movie method.
        /// </summary>
        Changes = 2048,

        /// <summary>
        ///     Append all possible methods to the movie method.
        /// </summary>
        All = 4095
    }
}