using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing a TMDb person preview object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fpopular
    /// </remarks>
    public class TmdbPersonPreview : TmdbPersonBase
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the person is an adult actor or not.
        /// </summary>
        /// <value>A value indicating whether the person is an adult actor or not.</value>
        [JsonProperty( PropertyName = "adult" )]
        public Boolean IsAdultActor { get; set; }
    }
}