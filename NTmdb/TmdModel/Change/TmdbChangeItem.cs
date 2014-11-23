using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb change item object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbChangeItem : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the change.
        /// </summary>
        /// <value>The ID of the change.</value>
        [JsonProperty( PropertyName = "id" )]
        public String Id { get; set; }

        /// <summary>
        ///     Gets or sets the performed action.
        /// </summary>
        /// <value>The performed action.</value>
        [JsonProperty( PropertyName = "action" )]
        public String Action { get; set; }

        /// <summary>
        ///     Gets or sets the time of the change.
        /// </summary>
        /// <value>The time of the change.</value>
        [JsonProperty( PropertyName = "time" )]
        public String Time { get; set; }

        /// <summary>
        ///     Gets or sets the ISO 639-1 language code of the changed entry.
        /// </summary>
        /// <value>The ISO 639-1 language code of the changed entry.</value>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public String Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the changed value.
        /// </summary>
        /// <remarks>
        ///     The TMDb API returns various different object types, need to implement a advanced conversion JSON to object XY
        /// </remarks>
        /// <value>The changed value.</value>
        [JsonProperty( PropertyName = "value" )]
        public Object Value { get; set; }

        /// <summary>
        ///     Gets or sets the original value.
        /// </summary>
        /// <remarks>
        ///     The TMDb API returns various different object types, need to implement a advanced conversion JSON to object XY
        /// </remarks>
        /// <value>The original value.</value>
        [JsonProperty( PropertyName = "original_value" )]
        public Object OriginalValue { get; set; }
    }
}