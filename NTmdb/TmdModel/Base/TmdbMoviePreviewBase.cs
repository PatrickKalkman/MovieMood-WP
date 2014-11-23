using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Base class for all movie preview like object.s
    /// </summary>
    public class TmdbMoviePreviewBase : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the ID of the movie.
        /// </summary>
        /// <value>The ID of the movie.</value>
        [JsonProperty( PropertyName = "id" )]
        public Int32 Id { get; set; }

        /// <summary>
        ///     Gets or sets the original title of the movie.
        /// </summary>
        /// <value>The original title of the movie.</value>
        [JsonProperty( PropertyName = "original_title" )]
        public String OriginalTitle { get; set; }

        /// <summary>
        ///     Gets or sets the release date of the movie.
        /// </summary>
        /// <value>The release date of the movie.</value>
        [JsonProperty( PropertyName = "release_date" )]
        public String ReleaseDate { get; set; }

        /// <summary>
        ///     Gets or sets the path to the poster of the movie.
        /// </summary>
        /// <value>The path to the poster of the movie.</value>
        [JsonProperty( PropertyName = "poster_path" )]
        public String PosterPath { get; set; }

        public Uri MoviePoster
        {
            get { return new Uri("http://image.tmdb.org/t/p/w92" + PosterPath); }
        }

        public string ReleaseYear
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ReleaseDate))
                {
                    return ReleaseDate.Substring(0, 4);
                }
                return string.Empty;
            }
        }

        /// <summary>
        ///     Gets or sets the title of the movie.
        /// </summary>
        /// <value>The title of the movie.</value>
        [JsonProperty( PropertyName = "title" )]
        public String Title { get; set; }
    }
}