using System;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb's movie list preview object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D%2Flists
    /// </remarks>
    public class TmdbMovieListPreview : TmdbModelBase
    {
        /// <summary>
        ///     Gets or sets the description of the movie list.
        /// </summary>
        /// <value>The description of the movie list.</value>
        [JsonProperty( PropertyName = "description" )]
        public String Description { get; set; }

        /// <summary>
        ///     Gets or sets the favorite count of the movie list.
        /// </summary>
        /// <value>The favorite count of the movie list.</value>
        [JsonProperty( PropertyName = "favorite_count" )]
        public Int32 FavoriteCount { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the movie list.
        /// </summary>
        /// <value>The ID of the movie list.</value>
        [JsonProperty( PropertyName = "id" )]
        public String Id { get; set; }

        /// <summary>
        ///     Gets or sets the number of movie in the list.
        /// </summary>
        /// <value>The number of movies in the list.</value>
        [JsonProperty( PropertyName = "item_count" )]
        public Int32 ItemCount { get; set; }

        /// <summary>
        ///     Gets or sets the ISO 639-1 language code of the movie list.
        /// </summary>
        /// <value>The ISO 639-1 language code of the movie list.</value>
        [JsonProperty( PropertyName = "iso_639_1" )]
        public String Iso639_1 { get; set; }

        /// <summary>
        ///     Gets or sets the type of the list.
        /// </summary>
        /// <remarks>
        ///     Value gets not always set!
        ///     (The movie/list method does use set this property.)
        /// </remarks>
        /// <value>The type of the list.</value>
        [JsonProperty( PropertyName = "list_type" )]
        public String ListType { get; set; }

        /// <summary>
        ///     Gets or sets the name of the movie list.
        /// </summary>
        /// <value>The name of the movie list.</value>
        [JsonProperty( PropertyName = "name" )]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets the path to the poster of the movie collection.
        /// </summary>
        /// <value>The path to the poster of the movie collection.</value>
        [JsonProperty( PropertyName = "poster_path" )]
        public String PosterPath { get; set; }
    }
}