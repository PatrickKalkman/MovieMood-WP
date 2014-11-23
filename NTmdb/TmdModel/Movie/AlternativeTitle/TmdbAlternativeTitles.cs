using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the alternative titles added to the movie object, when the "append_to_response=alternative_titles"
    ///     parameter is specified.
    /// </summary>
    public class TmdbAlternativeTitles : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the id of the movie to which the titles belongs.
        /// </summary>
        /// <value>The id of the movie to which the titles belongs.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets a list of titles.
        /// </summary>
        /// <value>A list of titles.</value>
        [JsonProperty( PropertyName = "titles" )]
        public List<TmdbAlternativeTitle> Titles { get; set; }
    }
}