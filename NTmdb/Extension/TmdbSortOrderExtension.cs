using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbSortOrder" />.
    /// </summary>
    public static class TmdbSortOrderExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value</returns>
        public static String ToTmdbParameter( this TmdbSortOrder value, IApiConfiguration apiConfiguration )
        {
            switch ( value )
            {
                case TmdbSortOrder.Ascending:
                    return apiConfiguration.SortOrderAscending;
                case TmdbSortOrder.Descending:
                    return apiConfiguration.SortOrderDescending;
                default:
                    throw new NotImplementedException( String.Format( "There is no implementation for the value: {0}", value ) );
            }
        }
    }
}