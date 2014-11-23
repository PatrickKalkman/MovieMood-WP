using System;
using System.Text;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbPersonMethod" />.
    /// </summary>
    public static class TmdbPersonMethodExtension
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value.</returns>
        public static String ToTmdbParameter( this TmdbPersonMethod value, IApiConfiguration apiConfiguration )
        {
            var sb = new StringBuilder();
            if ( ( value & TmdbPersonMethod.Credits ) == TmdbPersonMethod.Credits )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToPersonMethodCredits );

            if ( ( value & TmdbPersonMethod.Images ) == TmdbPersonMethod.Images )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToPersonMethodImages );

            if ( ( value & TmdbPersonMethod.Changes ) == TmdbPersonMethod.Changes )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToPersonMethodChanges );

            var names = sb.ToString();
            return names.EndsWith( "," )
                       ? names.Substring( 0, names.Length - 1 )
                       : names;
        }
    }
}