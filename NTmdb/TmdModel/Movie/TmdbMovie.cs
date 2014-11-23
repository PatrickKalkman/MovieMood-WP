using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace NTmdb
{
    /// <summary>
    ///     Class representing the TMDb movie object.
    /// </summary>
    /// <remarks>
    ///     Details: http://docs.themoviedb.apiary.io/#movies
    /// </remarks>
    public class TmdbMovie : TmdbMoviePreview
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the movie contains adult content or not.
        /// </summary>
        /// <value>A value indicating whether the movie contains adult content or not.</value>
        [JsonProperty( PropertyName = "adult" )]
        public Boolean IsAdult { get; set; }

        /// <summary>
        ///     Gets or sets the id of the collection to which the movie belongs.
        /// </summary>
        /// <value>The id of the collection to which the movie belongs.</value>
        [JsonProperty( PropertyName = "belongs_to_collection" )]
        public TmdbMovieCollectionPreview BelongsToCollection { get; set; }

        /// <summary>
        ///     Gets or sets the budget of the movie.
        /// </summary>
        /// <value>The budget of the movie.</value>
        [JsonProperty( PropertyName = "budget" )]
        public Int64 Budget { get; set; }

        /// <summary>
        ///     Gets or sets the genres of the movie.
        /// </summary>
        /// <value>The genres of the movie.</value>
        [JsonProperty( PropertyName = "genres" )]
        public List<TmdbGenre> Genres { get; set; }

        /// <summary>
        ///     Gets or sets the homepage of the movie.
        /// </summary>
        /// <value>The homepage of the movie.</value>
        [JsonProperty( PropertyName = "homepage" )]
        public String Homepage { get; set; }

        /// <summary>
        ///     Gets or sets the IMDb id of the movie.
        /// </summary>
        /// <remarks>
        ///     IMDb id starts with "tt".
        /// </remarks>
        /// <value>The IMDb id of the movie.</value>
        [JsonProperty( PropertyName = "imdb_id" )]
        public String ImdbId { get; set; }

        /// <summary>
        ///     Gets or sets the overview of the movie.
        /// </summary>
        /// <value>The overview of the movie.</value>
        [JsonProperty( PropertyName = "overview" )]
        public String Overview { get; set; }

        /// <summary>
        ///     Gets or sets the popularity of the movie.
        /// </summary>
        /// <value>The popularity of the movie.</value>
        [JsonProperty( PropertyName = "popularity" )]
        public Double Popularity { get; set; }

        /// <summary>
        ///     Gets or sets the production companies of the movie.
        /// </summary>
        /// <value>The production companies of the movie.</value>
        [JsonProperty( PropertyName = "production_companies" )]
        public List<TmdbCompanyBasic> ProductionCompanies { get; set; }

        /// <summary>
        ///     Gets or sets the production countries of the movie.
        /// </summary>
        /// <value>The production countries of the movie.</value>
        [JsonProperty( PropertyName = "production_countries" )]
        public List<TmdbProductionCountry> ProductionCountries { get; set; }

        /// <summary>
        ///     Gets or sets the release date of the movie.
        /// </summary>
        /// <value>The release date of the movie.</value>
        [JsonProperty( PropertyName = "release_date" )]
        public String ReleaseDateString { get; set; }

        /// <summary>
        ///     Gets or sets the revenue of the movie.
        /// </summary>
        /// <value>The revenue of the movie.</value>
        [JsonProperty( PropertyName = "revenue" )]
        public Int64 Revenue { get; set; }

        /// <summary>
        ///     Gets or sets the runtime of the movie in minutes.
        /// </summary>
        /// <value>The runtime of the movie.</value>
        [JsonProperty( PropertyName = "runtime" )]
        public Int32? Runtime { get; set; }

        public string RuntimeString
        {
            get
            {
                if (Runtime.HasValue)
                {
                    int hours = (int)(Runtime / 60);
                    int minutes = Runtime.Value - (hours * 60);
                    return string.Format("{0:00}:{1:00}", hours, minutes);
                }
                return string.Empty;
            }
        }

        public string AudienceRating
        {
            get
            {
                if (Releases != null)
                {
                    if (Releases.Releases.Count > 0)
                    {
                        return Releases.Releases[0].Certification;
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        ///     Gets or sets the spoken languages of the movie.
        /// </summary>
        /// <value>The spoken languages of the movie.</value>
        [JsonProperty( PropertyName = "spoken_languages" )]
        public List<TmdbProductionCountry> SpokenLanguages { get; set; }

        /// <summary>
        ///     Gets or sets the status of the movie.
        /// </summary>
        /// <value>The status of the movie.</value>
        [JsonProperty( PropertyName = "status" )]
        public String Status { get; set; }

        /// <summary>
        ///     Gets or sets the tagline of the movie.
        /// </summary>
        /// <value>The tagline of the movie.</value>
        [JsonProperty( PropertyName = "tagline" )]
        public String Tagline { get; set; }

        #region Appended Methods

        /// <summary>
        ///     Gets or sets the alternative Titles of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the alternative titles method was appended to the movie method.
        /// </remarks>
        /// <value>The alternative title of the movie.</value>
        [JsonProperty( PropertyName = "alternative_titles" )]
        public TmdbAlternativeTitles AlternativeTitles { get; set; }

        /// <summary>
        ///     Gets or sets the staff of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the casts method was appended to the movie method.
        /// </remarks>
        /// <value>The staff of the movie.</value>
        [JsonProperty( PropertyName = "casts" )]
        public TmdbStaff Staff { get; set; }

        /// <summary>
        ///     Gets or sets the images of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the images method was appended to the movie method.
        /// </remarks>
        /// <value>The images of the movie.</value>
        [JsonProperty( PropertyName = "images" )]
        public TmdbImages Images { get; set; }

        /// <summary>
        ///     Gets or sets the keywords of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the keywords method was appended to the movie method.
        /// </remarks>
        /// <value>The keywords of the movie.</value>
        [JsonProperty( PropertyName = "keywords" )]
        public TmdbMovieKeywords Keywords { get; set; }

        /// <summary>
        ///     Gets or sets the releases of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the releases method was appended to the movie method.
        /// </remarks>
        /// <value>The releases of the movie.</value>
        [JsonProperty( PropertyName = "releases" )]
        public TmdbReleases Releases { get; set; }

        /// <summary>
        ///     Gets or sets the trailers of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the trailers method was appended to the movie method.
        /// </remarks>
        /// <value>The trailers of the movie.</value>
        [JsonProperty( PropertyName = "trailers" )]
        public TmdbTrailers Trailers { get; set; }

        /// <summary>
        ///     Gets or sets the translations of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the translations method was appended to the movie method.
        /// </remarks>
        /// <value>The translations of the movie.</value>
        [JsonProperty( PropertyName = "translations" )]
        public TmdbTranslations Translations { get; set; }

        /// <summary>
        ///     Gets or sets the similar movies of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the similar movies method was appended to the movie method.
        /// </remarks>
        /// <value>The similar movies of the movie.</value>
        [JsonProperty( PropertyName = "similar_movies" )]
        public TmdbMoviePreviewList SimilarMovies { get; set; }

        /// <summary>
        ///     Gets or sets the reviews of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the reviews method was appended to the movie method.
        /// </remarks>
        /// <value>The reviews of the movie.</value>
        [JsonProperty( PropertyName = "reviews" )]
        public TmdbMovieReviews MovieReviews { get; set; }

        /// <summary>
        ///     Gets or sets the lists, in which the movie is in.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the lists method was appended to the movie method.
        /// </remarks>
        /// <value>The lists, in which the movie is in.</value>
        [JsonProperty( PropertyName = "lists" )]
        public TmdbMovieLists Lists { get; set; }

        /// <summary>
        ///     Gets or sets the changes of the movie.
        /// </summary>
        /// <remarks>
        ///     Property is only set when the changes method was appended to the movie method.
        /// </remarks>
        /// <value>The changes of the movie.</value>
        [JsonProperty( PropertyName = "changes" )]
        public TmdbChanges Changes { get; set; }

        #endregion Appended Methods

        #region Methods

        /// <summary>
        ///     Gets the release date of the movie.
        /// </summary>
        /// <param name="datePattern">The pattern to use for parsing the TMDb's date format.</param>
        /// <returns>The release date of the movie, or null if method was not able to pars the TMDb's date format.</returns>
        public DateTime? GetReleaseDate( String datePattern )
        {
            try
            {
                return DateTime.ParseExact( ReleaseDateString, datePattern, CultureInfo.InvariantCulture );
            }
            catch ( FormatException )
            {
                return null;
            }
        }

        /// <summary>
        /// Return the combines genres as a string.
        /// </summary>
        public string GenresString
        {
            get { return ConvertToGenreString(this.Genres); }    
        }

        private string ConvertToGenreString(List<TmdbGenre> tmdbGenres)
        {
            string genrelist = string.Empty;
            foreach (var tmdbGenre in tmdbGenres)
            {
                genrelist += tmdbGenre.Name + " & ";
            }
            return genrelist.Substring(0, genrelist.Length - 3);
        }

        public string CastString
        {
            get
            {
                if (Staff != null)
                {
                    if (Staff.Cast != null)
                    {

                        int castsNumber = 0;
                        string castString = string.Empty;
                        foreach (TmdbCastMember castMember in Staff.Cast)
                        {
                            if (castsNumber < 2)
                            {
                                castString += castMember.Name + " & ";
                                castsNumber++;
                            }
                        }
                        if (castString.Length > 0)
                        {
                            return castString.Substring(0, castString.Length - 3);
                        }
                        return castString;
                    }
                }
                return string.Empty;
            }
        }

        public string Director
        {
            get
            {
                if (Staff != null)
                {
                    if (Staff.Crew != null)
                    {
                        foreach (TmdbCrewMember tmdbCrewMember in Staff.Crew)
                        {
                            if (tmdbCrewMember.Job == "Director")
                            {
                                return tmdbCrewMember.Name;
                            }
                        }
                    }
                }
                return string.Empty;
            }
        }



        #endregion Methods
    }
}