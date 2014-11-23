using System;
using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing the base class of a TMDb object.
    /// </summary>
    public interface ITmdbModelBase
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the ETag returned by the TMDb API.
        /// </summary>
        /// <value>The ETag returned by the TMDb API.</value>
        String ETag { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        ///     Desterilizes the given JSON string.
        /// </summary>
        /// <param name="jsonContent">The string containing the JSON data to desterilize.</param>
        /// <typeparam name="T">The type of the TMDb object.</typeparam>
        /// <returns>The desterilized object.</returns>
        Task<T> DeserializeJson<T>( String jsonContent );

        /// <summary>
        ///     Serializes the model into a JSON string.
        /// </summary>
        /// <returns>The serialized object.</returns>
        Task<String> Serialize();

        #endregion Methods
    }
}