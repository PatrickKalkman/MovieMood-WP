using System;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbSearchType" />.
    /// </summary>
    public static class TmdbSearchTypeExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value</returns>
        public static String ToTmdbParameter( this TmdbSearchType value, IApiConfiguration apiConfiguration )
        {
            switch ( value )
            {
                case TmdbSearchType.Phrase:
                    return apiConfiguration.SearchTypePhrase;
                case TmdbSearchType.Ngram:
                    return apiConfiguration.SearchTypeNgram;
                default:
                    throw new NotImplementedException( String.Format( "There is no implementation for the value: {0}", value ) );
            }
        }
    }
}