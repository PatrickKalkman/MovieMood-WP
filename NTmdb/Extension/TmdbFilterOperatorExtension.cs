using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extensions fro <see cref="TmdbFilterOperator" />.
    /// </summary>
    public static class TmdbFilterOperatorExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value.</returns>
        public static String ToTmdbParameter( this TmdbFilterOperator value, IApiConfiguration apiConfiguration )
        {
            switch ( value )
            {
                case TmdbFilterOperator.And:
                    return apiConfiguration.AndChar;
                case TmdbFilterOperator.Or:
                    return apiConfiguration.OrChar;
                default:
                    throw new ArgumentException( "The given value is not a valid TmdbFilterOperator value.", "value" );
            }
        }
    }
}