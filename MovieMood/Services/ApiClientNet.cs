using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NTmdb;

namespace MovieMood.Services
{
    public class ApiClientNet : IApiClient
    {
        #region Implementation of IApiClient

        /// <summary>
        ///     Loads the JSON from the TMDb API.
        /// </summary>
        /// <param name="url">The URL to the TMDb API.</param>
        /// <param name="requestMethod">The method used to perform the request, default is GET.</param>
        /// <param name="cacheLevel">Specified the cache level used for the the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns>The result of the API call.</returns>
        public async Task<IApiCallResult> GetJsonAsync(String url, String requestMethod = null, CacheLevel? cacheLevel = null,
                                                        TimeSpan? timeout = null, Boolean? useSecureConnection = false)
        {
            var request = GetRequest(url, requestMethod ?? "GET", cacheLevel, timeout, useSecureConnection: useSecureConnection);
            return await GetJsonResponseAsync(request);
        }

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
        public async Task<IApiCallResult> GetJsonAsync(String url, ITmdbModelBase requestContent, String requestMethod = null,
                                                        CacheLevel? cacheLevel = null, TimeSpan? timeout = null, Boolean? useSecureConnection = false)
        {
            var request = GetRequest(url, requestMethod ?? "POST", cacheLevel, timeout, "application/json", useSecureConnection);

            try
            {
                using (var requestStream = await request.GetRequestStreamAsync())
                {
                    var byteArray = Encoding.UTF8.GetBytes(await requestContent.Serialize());
                    await requestStream.WriteAsync(byteArray, 0, byteArray.Length);
                }
                return await GetJsonResponseAsync(request);
            }
            catch (WebException ex)
            {
                return new ApiCallResult
                {
                    Error = ex
                };
            }
        }

        /// <summary>
        ///     Downloads the file at the given URL and saves it at the given path.
        /// </summary>
        /// <param name="url">The URL to the file to load.</param>
        /// <param name="fileName">The name of the file on the local storage.</param>
        /// <param name="cacheLevel">The cache level to use for the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns></returns>
        public async Task<IFileDownloadResult> DownloadFileAsync(String url, String fileName, CacheLevel? cacheLevel = null, TimeSpan? timeout = null,
                                                      Boolean? useSecureConnection = false)
        {
            var result = new FileDownloadResult
            {
                SourceUrl = url
            };
            try
            {
                var request = GetRequest(url, "GET", cacheLevel, timeout, useSecureConnection: useSecureConnection, acceptJson: false);

                using (var response = await request.GetResponseAsync())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var fileStream = File.OpenWrite(fileName))
                        {
                            var buffer = new byte[4096];
                            int bytesRead;
                            do
                            {
                                bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length);
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                            } while (bytesRead != 0);
                            result.FilePath = fileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }
            return result;
        }

        /// <summary>
        ///     Gets the file at the given URL as byte array.
        /// </summary>
        /// <param name="url">The URL to the file to load.</param>
        /// <param name="cacheLevel">The cache level to use for the request.</param>
        /// <param name="timeout">The timeout value for sending a request and receiving a response.</param>
        /// <param name="useSecureConnection">A value determining whether a secure connection should get used or not.</param>
        /// <returns>The data read from the file stream.</returns>
        public async Task<IFileStreamResult> GetFileAsync(String url, CacheLevel? cacheLevel = null, TimeSpan? timeout = null, Boolean? useSecureConnection = false)
        {
            var result = new FileStreamResult
            {
                SourceUrl = url
            };
            try
            {
                var request = GetRequest(url, "GET", cacheLevel, timeout, useSecureConnection: useSecureConnection, acceptJson: false);
                using (var stream = await GetMemoryStream(request))
                    result.StreamContent = stream.ToArray();
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }
            return result;
        }
        #endregion Implementation of IApiClient

        #region Private Members

        private static HttpWebRequest GetRequest(String url, String requestMethod, CacheLevel? cacheLevel = null, TimeSpan? timeout = null,
                                                  String contentType = null, Boolean? useSecureConnection = false, Boolean acceptJson = true)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = requestMethod;

            if (acceptJson)
                request.Accept = "application/json";

            if (contentType != null)
                request.ContentType = contentType;

            //request.Headers.Add("If-None-Match", ""); ETag...
            return request;
        }

        /// <summary>
        ///     Gets the response from the web request.
        /// </summary>
        /// <param name="request">The request to get the response stream from.</param>
        /// <returns>The response read from the given request.</returns>
        private static async Task<IApiCallResult> GetJsonResponseAsync(HttpWebRequest request)
        {
            var result = new ApiCallResult();
            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                        result.Json = await reader.ReadToEndAsync();

                    result.ETag = response.Headers["ETag"];
                }

                result.SourceUrl = request.RequestUri.ToString();
                return result;
            }
            catch (WebException ex)
            {
                using (var response = ex.Response)
                using (var reader = new StreamReader(response.GetResponseStream()))
                    result.Json = reader.ReadToEnd();
                result.Error = ex;
                return result;
            }
        }

        /// <summary>
        ///     Gets a memory stream which has the response of the given request as content.
        /// </summary>
        /// <param name="request">The request to get the stream's content from.</param>
        /// <returns>A memory stream which has the response of the given request as content.</returns>
        private static async Task<MemoryStream> GetMemoryStream(HttpWebRequest request)
        {
            using (var response = await request.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var memoryStream = new MemoryStream();
                    var buffer = new byte[4096];
                    Int32 bytesRead;

                    do
                    {
                        bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length);
                        await memoryStream.WriteAsync(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                    return memoryStream;
                }
            }
        }

        #endregion Private Members
    }
}
