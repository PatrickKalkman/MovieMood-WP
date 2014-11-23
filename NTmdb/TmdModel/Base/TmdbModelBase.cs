using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Base class for all TMDb models.
    /// </summary>
    public class TmdbModelBase : ITmdbModelBase
    {
        #region Implementation of ITmdbModelBase

        /// <summary>
        ///     Gets or sets the ETag returned by the TMDb API.
        /// </summary>
        /// <value>The ETag returned by the TMDb API.</value>
        [JsonIgnore]
        public String ETag { get; set; }

        /// <summary>
        ///     Desterilizes the given JSON string.
        /// </summary>
        /// <param name="jsonContent">The string containing the JSON data to desterilize.</param>
        /// <typeparam name="T">The type of the TMDb object.</typeparam>
        /// <returns>The desterilized object.</returns>
        public async Task<T> DeserializeJson<T>( String jsonContent )
        {
            return await JsonConvert.DeserializeObjectAsync<T>( jsonContent );
        }

        /// <summary>
        ///     Serializes the model into a JSON string.
        /// </summary>
        /// <returns>The serialized object.</returns>
        public async Task<String> Serialize()
        {
            return await JsonConvert.SerializeObjectAsync( this );
        }

        #endregion Implementation of ITmdbModelBase

        /// <summary>
        ///     Desterilizes the given JSON string.
        /// </summary>
        /// <param name="jsonContent">The string containing the JSON data to desterilize.</param>
        /// <typeparam name="T">The type of the TMDb object.</typeparam>
        /// <returns>The desterilized object.</returns>
        public static async Task<T> Deserialize<T>( String jsonContent )
        {
            return await JsonConvert.DeserializeObjectAsync<T>( jsonContent );
        }
    }
}