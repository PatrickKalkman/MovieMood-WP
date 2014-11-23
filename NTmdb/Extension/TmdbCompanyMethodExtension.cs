using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbCompanyMethod" />.
    /// </summary>
    public static class TmdbCompanyMethodExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value.</returns>
        public static String ToTmdbParameter( this TmdbCompanyMethod value, IApiConfiguration apiConfiguration )
        {
            return ( value & TmdbCompanyMethod.Movies ) == TmdbCompanyMethod.Movies
                       ? apiConfiguration.AppendToCompanyMethodMovies
                       : String.Empty;
        }
    }
}