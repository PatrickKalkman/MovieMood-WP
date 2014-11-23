using System;
using System.Text;

namespace NTmdb
{
    /// <summary>
    ///     Class containing extension methods for <see cref="TmdbMovieMethod" />.
    /// </summary>
    public static class TmdbMovieMethodExtensions
    {
        /// <summary>
        ///     Converts the given value into a valid TMDb parameter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="apiConfiguration">The configuration of the API, used to get the parameter names/values from.</param>
        /// <returns>The converted value.</returns>
        public static String ToTmdbParameter( this TmdbMovieMethod value, IApiConfiguration apiConfiguration )
        {
            var sb = new StringBuilder();

            if ( ( value & TmdbMovieMethod.AlternativeTitles ) == TmdbMovieMethod.AlternativeTitles )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodAlternativeTitles );

            if ( ( value & TmdbMovieMethod.Casts ) == TmdbMovieMethod.Casts )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodCasts );

            if ( ( value & TmdbMovieMethod.Images ) == TmdbMovieMethod.Images )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodImages );

            if ( ( value & TmdbMovieMethod.Keywords ) == TmdbMovieMethod.Keywords )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodKeywords );

            if ( ( value & TmdbMovieMethod.Releases ) == TmdbMovieMethod.Releases )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodReleases );

            if ( ( value & TmdbMovieMethod.Trailers ) == TmdbMovieMethod.Trailers )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodTrailers );

            if ( ( value & TmdbMovieMethod.Translations ) == TmdbMovieMethod.Translations )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodTranslations );

            if ( ( value & TmdbMovieMethod.SimilarMovies ) == TmdbMovieMethod.SimilarMovies )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodSimilarMovies );

            if ( ( value & TmdbMovieMethod.Reviews ) == TmdbMovieMethod.Reviews )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodReviews );

            if ( ( value & TmdbMovieMethod.Lists ) == TmdbMovieMethod.Lists )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodLists );

            if ( ( value & TmdbMovieMethod.Changes ) == TmdbMovieMethod.Changes )
                sb.AppendFormat( "{0},", apiConfiguration.AppendToMovieMethodChanges );

            var names = sb.ToString();
            return names.EndsWith( "," )
                       ? names.Substring( 0, names.Length - 1 )
                       : names;
        }
    }
}