using System.Collections.Generic;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb genre list object object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2Flist
    /// </remarks>
    public class TmdbGenreList : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets a list of genres.
        /// </summary>
        /// <value>A list of genres.</value>
        [JsonProperty( PropertyName = "genres" )]
        public List<TmdbGenre> Genres { get; set; }
    }
}