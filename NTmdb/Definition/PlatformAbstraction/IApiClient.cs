using System;
using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing the type which will load the JSON from the TMDb.
    /// </summary>
    /// <remarks>
    ///     Interface is needed because of Portable Class Libraries doesn't support HttpRequests.
    /// </remarks>
    public interface IApiClient
    {
        /// <summary>
        ///     Loads the JSON from the TMDb API.
        /// </summary>
        /// <param name="url">The URL to the TMDb API.</param>
        /// <param name="requestMethod">The method used to perform the request, default is GET.</param>
        /// <param name="cacheLevel">Specified the cache level used for the the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns>The result of the API call.</returns>
        Task<IApiCallResult> GetJsonAsync( String url, String requestMethod = null, CacheLevel? cacheLevel = null,
                                           TimeSpan? timeout = null, Boolean? useSecureConnection = false );

        /// <summary>
        ///     Loads the JSON from the TMDb API.
        /// </summary>
        /// <param name="url">The URL to the TMDb API.</param>
        /// <param name="requestContent">The content of the request sent to the TMDb API.</param>
        /// <param name="requestMethod">The method of the request, default is POST.</param>
        /// <param name="cacheLevel">Specified the cache level used for the the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns>The result of the API call.</returns>
        Task<IApiCallResult> GetJsonAsync( String url, ITmdbModelBase requestContent, String requestMethod = null,
                                           CacheLevel? cacheLevel = null, TimeSpan? timeout = null, Boolean? useSecureConnection = false );

        /// <summary>
        ///     Downloads the file at the given URL and saves it at the given path.
        /// </summary>
        /// <param name="url">The URL to the file to load.</param>
        /// <param name="fileName">The name of the file on the local storage.</param>
        /// <param name="cacheLevel">The cache level to use for the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns></returns>
        Task<IFileDownloadResult> DownloadFileAsync( String url, String fileName, CacheLevel? cacheLevel = null, TimeSpan? timeout = null,
                                                                  Boolean? useSecureConnection = false );

        /// <summary>
        ///     Gets the file at the given URL as byte array.
        /// </summary>
        /// <param name="url">The URL to the file to load.</param>
        /// <param name="cacheLevel">The cache level to use for the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns>The data read from the file stream.</returns>
        Task<IFileStreamResult> GetFileAsync( String url, CacheLevel? cacheLevel = null, TimeSpan? timeout = null,
                                                           Boolean? useSecureConnection = false );
    }
}