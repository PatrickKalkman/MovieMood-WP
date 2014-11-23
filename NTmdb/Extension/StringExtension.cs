using System;
using System.IO;
using System.Text.RegularExpressions;

namespace NTmdb
{
    /// <summary>
    ///     Class containing some extensions for <see cref="string" />.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        ///     Escapes the given string.
        /// </summary>
        /// <param name="s">The string to escape.</param>
        /// <returns>The escaped string.</returns>
        public static String EscapeString( this String s )
        {
            return Regex.Replace( s, "[" + Regex.Escape( new String( Path.GetInvalidFileNameChars() ) ) + "]", "-" );
        }

        /// <summary>
        ///     Gets the URL to a image resource.
        /// </summary>
        /// <param name="filePath">The file path of the image (for example: 8uO0gUM8aNqYLs1OsTBQiXu0fEv.jpg).</param>
        /// <param name="size">The size of the image (for example: w500, value from the TMDb tmdbConfiguration).</param>
        /// <param name="apiConfiguration">The tmdbConfiguration of the API wrapper.</param>
        /// <param name="tmdbConfiguration">The tmdbConfiguration loaded from the TMDb API.</param>
        /// <returns>The URl to the image with the specified size.</returns>
        public static String GetImageUrl( this String filePath, String size, IApiConfiguration apiConfiguration, TmdbConfiguration tmdbConfiguration )
        {
            return String.Format( "{0}/{1}/{2}",
                                  apiConfiguration.UseSecureConnection == true
                                      ? tmdbConfiguration.ImageConfiguration.SecureBaseUrl
                                      : tmdbConfiguration.ImageConfiguration.BaseUrl, size, filePath );
        }

        /// <summary>
        ///     Gets the URL to a image resource with the original size.
        /// </summary>
        /// <param name="filePath">The file path of the image (for example: 8uO0gUM8aNqYLs1OsTBQiXu0fEv.jpg).</param>
        /// <param name="apiConfiguration">The tmdbConfiguration of the API wrapper.</param>
        /// <param name="tmdbConfiguration">The tmdbConfiguration loaded from the TMDb API.</param>
        /// <exception cref="ArgumentOutOfRangeException">Was not able to find the original size in the TMDb tmdbConfiguration.</exception>
        /// <returns>The URl to the image with the original size.</returns>
        public static String GetImageOriginalSizeUrl( this String filePath, IApiConfiguration apiConfiguration, TmdbConfiguration tmdbConfiguration )
        {
            return String.Format( "{0}/{1}/{2}",
                                  apiConfiguration.UseSecureConnection == true
                                      ? tmdbConfiguration.ImageConfiguration.SecureBaseUrl
                                      : tmdbConfiguration.ImageConfiguration.BaseUrl,
                                  apiConfiguration.OriginalImageSizeValue, filePath );
        }
    }
}