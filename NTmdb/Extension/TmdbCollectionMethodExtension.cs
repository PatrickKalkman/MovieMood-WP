using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbCollectionMethod" />.
    /// </summary>
    public static class TmdbCollectionMethodExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value.</returns>
        public static String ToTmdbParameter( this TmdbCollectionMethod value, IApiConfiguration apiConfiguration )
        {
            return ( value & TmdbCollectionMethod.Images ) == TmdbCollectionMethod.Images
                       ? apiConfiguration.MovieCollectionAppendImages
                       : String.Empty;
        }
    }
}