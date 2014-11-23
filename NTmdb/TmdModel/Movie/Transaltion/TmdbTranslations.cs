using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb translations object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbTranslations : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie to which the translations belongs.
        /// </summary>
        /// <value>The ID of the movie to which the translations belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the translations.
        /// </summary>
        /// <value>The translations.</value>
        [JsonProperty( PropertyName = "translations" )]
        public List<TmdbTranslation> Translations { get; set; }
    }
}