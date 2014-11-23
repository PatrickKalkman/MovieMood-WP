using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbDiscoverySortBy" />.
    /// </summary>
    public static class TmdbDiscoverySortByExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value.</returns>
        public static String ToTmdbParameter( this TmdbDiscoverySortBy value, IApiConfiguration apiConfiguration )
        {
            switch ( value )
            {
                case TmdbDiscoverySortBy.PopularityAsc:
                    return apiConfiguration.SortByPopularityAscending;
                case TmdbDiscoverySortBy.PopularityDesc:
                    return apiConfiguration.SortByPopularityDescending;
                case TmdbDiscoverySortBy.ReleaseDateAsc:
                    return apiConfiguration.SortByReleaseDateAscending;
                case TmdbDiscoverySortBy.ReleaseDateDesc:
                    return apiConfiguration.SortByReleaseDateDescending;
                case TmdbDiscoverySortBy.VoteAverageAsc:
                    return apiConfiguration.SortByVoteAverageAscending;
                case TmdbDiscoverySortBy.VoteAverageDesc:
                    return apiConfiguration.SortByVoteAverageDescending;
                default:
                    throw new ArgumentException( "The given value is not a valid TmdbDiscoverySortBy value.", "value" );
            }
        }
    }
}