using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb person information object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
    /// </remarks>
    public class TmdbPersonInformation : TmdbPersonPreview
    {
        /// <summary>
        ///     Gets or sets a list of names which the person is also know as.
        /// </summary>
        /// <value>A list of names which the person is also know as.</value>
        [JsonProperty( PropertyName = "also_known_as" )]
        public List<String> AlsoKnownAs { get; set; }

        /// <summary>
        ///     Gets or sets the biography of the person.
        /// </summary>
        /// <value>The biography of the person.</value>
        [JsonProperty( PropertyName = "biography" )]
        public String Biography { get; set; }

        /// <summary>
        ///     Gets or sets the birthday of the person.
        /// </summary>
        /// <value>The birthday of the person.</value>
        [JsonProperty( PropertyName = "birthday" )]
        public String Birthday { get; set; }

        /// <summary>
        ///     Gets or sets the death day of the person.
        /// </summary>
        /// <value>The death day of the person.</value>
        [JsonProperty( PropertyName = "deathday" )]
        public String Deathday { get; set; }

        /// <summary>
        ///     Gets or sets a URL to the homepage of the person.
        /// </summary>
        /// <value>A URL to the homepage of the person.</value>
        [JsonProperty( PropertyName = "homepage" )]
        public String Homepage { get; set; }

        /// <summary>
        ///     Gets or sets the place of birth of the person.
        /// </summary>
        /// <value>The place of birth of the person.</value>
        [JsonProperty( PropertyName = "place_of_birth" )]
        public String PlaceOfBirth { get; set; }

        #region Appended Methods

        /// <summary>
        ///     Gets or sets the credits of the person.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the credits method was appended to the person method.
        /// </remarks>
        /// <value>The credits of the person.</value>
        [JsonProperty( PropertyName = "credits" )]
        public TmdbPersonCredits Credits { get; set; }

        /// <summary>
        ///     Gets or sets the images of the person.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the images method was appended to the person method.
        /// </remarks>
        /// <value>The images of the person.</value>
        [JsonProperty( PropertyName = "images" )]
        public TmdbPersonImages Images { get; set; }

        /// <summary>
        ///     Gets or sets the changes of the person.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the changes method was appended to the person method.
        /// </remarks>
        /// <value>The changes of the person.</value>
        [JsonProperty( PropertyName = "changes" )]
        public TmdbChanges Changes { get; set; }

        #endregion Appended Methods
    }
}