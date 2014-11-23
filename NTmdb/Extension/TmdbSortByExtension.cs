using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbSortBy" />.
    /// </summary>
    public static class TmdbSortByExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value</returns>
        public static String ToTmdbParameter( this TmdbSortBy value, IApiConfiguration apiConfiguration )
        {
            switch ( value )
            {
                case TmdbSortBy.CreatedAt:
                    return apiConfiguration.SortByCreatedAt;
                default:
                    throw new NotImplementedException( String.Format( "There is no implementation for the value: {0}", value ) );
            }
        }
    }
}