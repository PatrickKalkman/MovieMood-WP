using System;
using System.IO;
using System.Xml.Serialization;

namespace NTmdb
{
    /// <summary>
    ///     Represents the configuration for the TMDb API.
    /// </summary>
    public class ApiConfiguration : IApiConfiguration
    {
        #region Implementation of IApiConfiguration

        /// <summary>
        ///     Gets or sets the cache level of the requests.
        /// </summary>
        /// <value>The cache level of the requests.</value>
        public CacheLevel? CacheLevel { get; set; }

        /// <summary>
        ///     Gets or sets the timeout used to send a request to the TMDb and receive a response from the TMDb.
        /// </summary>
        /// <value>The timeout used to send a request to the TMDb and receive a response from the TMDb.</value>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        ///     Gets or sets a value determining whether a secure connection should get used or not.
        /// </summary>
        /// <value>A value determining whether a secure connection should get used or not.</value>
        public Boolean? UseSecureConnection { get; set; }

        /// <summary>
        ///     Gets or sets the TMDb PI key.
        /// </summary>
        /// <value>The TMDb PI key.</value>
        public string ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets the pattern used by the TMDb API for <see cref="DateTime" /> values.
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: "yyyy-MM-dd HH:mm:ss 'UTC'"
        /// </remarks>
        /// <value>
        ///     The pattern used by the TMDb API for <see cref="DateTime" /> values.
        /// </value>
        public string JsonDateTimePattern { get; set; }

        /// <summary>
        ///     Gets or sets the pattern used by the TMDb API for <see cref="DateTime" /> values (only date no time).
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: "yyyy-MM-dd"
        /// </remarks>
        /// <value>
        ///     The pattern used by the TMDb API for <see cref="DateTime" /> values (only date no time).
        /// </value>
        public string JsonDatePattern { get; set; }

        /// <summary>
        ///     Gets or sets the URL of the TMDb API.
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: http://api.themoviedb.org/3
        /// </remarks>
        /// <value>The URL of the TMDb API. </value>
        public string ApiUrl { get; set; }

        /// <summary>
        ///     Gets or sets the secure URL of the TMDb API.
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: https://api.themoviedb.org/3
        /// </remarks>
        /// <value>The secure URL of the TMDb API. </value>
        public string SecureApiUrl { get; set; }

        /// <summary>
        ///     Gets or sets the name of the API key parameter.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): api_key
        /// </remarks>
        /// <value>The name of the API key parameter.</value>
        public string ApiKeyParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the original size value, used to build a image URL.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fconfiguration
        /// </remarks>
        /// <value>The original size value, used to build a image URL.</value>
        public string OriginalImageSizeValue { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's configuration method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): configuration
        /// </remarks>
        /// <value>The name of the TMDb's configuration method.</value>
        public string ConfigurationMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's authentication new token method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): authentication/token/new
        /// </remarks>
        /// <value>The name of the TMDb's authentication new token method.</value>
        public string NewAuthenticationTokenMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's authentication new session method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): authentication/session/new
        /// </remarks>
        /// <value>The name of the TMDb's authentication new session method.</value>
        public string NewSessionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's authentication new guest session method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): authentication/guest_session/new
        /// </remarks>
        /// <value>The name of the TMDb's authentication new guest session method.</value>
        public string NewGuestSessionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account
        /// </remarks>
        /// <value>The name of the TMDb's account method.</value>
        public string AccountMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account lists method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/lists
        /// </remarks>
        /// <value>The name of the TMDb's account lists method.</value>
        public string AccountListsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account favorite movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/favorite_movies
        /// </remarks>
        /// <value>The name of the TMDb's account favorite movies lists method.</value>
        public string AccountFavoriteMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account favorite method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/favorite
        /// </remarks>
        /// <value>The name of the TMDb's account favorite method.</value>
        public string AccountAddFavoriteMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account rated movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/rated_movies
        /// </remarks>
        /// <value>The name of the TMDb's account rated movies method.</value>
        public string AccountRatedMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/movie_watchlist
        /// </remarks>
        /// <value>The name of the TMDb's account watch list method.</value>
        public string AccountWatchListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account edit watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/movie_watchlist
        /// </remarks>
        /// <value>The name of the TMDb's account edit watch list method.</value>
        public string AccountEditWatchListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/ (with parameter id: movie/{id})
        /// </remarks>
        /// <value>The name of the TMDb's movie method.</value>
        public string GetMovieMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's alternative titles method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/alternative_titles
        /// </remarks>
        /// <value>The name of the TMDb's alternative titles method.</value>
        public string MovieAlternativeTitlesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's cast method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/casts
        /// </remarks>
        /// <value>The name of the TMDb's cast method.</value>
        public string MovieCastMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's keywords method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/keywords
        /// </remarks>
        /// <value>The name of the TMDb's keywords method.</value>
        public string MovieKeywordsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's releases method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/releases
        /// </remarks>
        /// <value>The name of the TMDb's releases method.</value>
        public string MovieReleasesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's images method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/images
        /// </remarks>
        /// <value>The name of the TMDb's images method.</value>
        public string ImagesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's trailers method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/trailers
        /// </remarks>
        /// <value>The name of the TMDb's trailers method.</value>
        public string MovieTrailersMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's translations method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/translations
        /// </remarks>
        /// <value>The name of the TMDb's translations method.</value>
        public string MovieTranslationsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's similar movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/similar_movies
        /// </remarks>
        /// <value>The name of the TMDb's similar movies method.</value>
        public string SimilarMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's reviews method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/reviews
        /// </remarks>
        /// <value>The name of the TMDb's reviews method.</value>
        public string MovieReviewsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's lists method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/lists
        /// </remarks>
        /// <value>The name of the TMDb's lists method.</value>
        public string MovieListsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's changes method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/changes
        /// </remarks>
        /// <value>The name of the TMDb's changes method.</value>
        public string MovieChangesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's latest method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/latest
        /// </remarks>
        /// <value>The name of the TMDb's latest method.</value>
        public string LatestMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's upcoming method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/upcoming
        /// </remarks>
        /// <value>The name of the TMDb's upcoming method.</value>
        public string UpcomingMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's now playing method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/now_playing
        /// </remarks>
        /// <value>The name of the TMDb's now playing method.</value>
        public string NowPlayingMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's popular method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/popular
        /// </remarks>
        /// <value>The name of the TMDb's popular method.</value>
        public string PopularMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's top rated method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/top_rated
        /// </remarks>
        /// <value>The name of the TMDb's top rated method.</value>
        public string TopRatedMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's movie account state method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/account_states
        /// </remarks>
        /// <value>The name of the TMDb's movie account state method.</value>
        public string MovieAccountStatesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's rating method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/rating
        /// </remarks>
        /// <value>The name of the TMDb's rating method.</value>
        public string RatingMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's collection method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): collection/{id}
        /// </remarks>
        /// <value>The name of the TMDb's collection method.</value>
        public string MovieCollectionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's collection image method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): collection/{id}/images
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <value>The name of the TMDb's collection image method.</value>
        public string MovieCollectionImageMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <value>The name of the TMDb's person method.</value>
        public string GetPersonMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person credits method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}/credits
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
        /// </remarks>
        /// <value>The name of the TMDb's person credits method.</value>
        public string PersonCreditsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person images method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}/images
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <value>The name of the TMDb's person images method.</value>
        public string PersonImagesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person changes method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}/changes
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's person changes method.</value>
        public string PersonChangesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's popular people method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/popular
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's popular people method.</value>
        public string PopularPeopleMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's latest person method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/latest
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Flatest
        /// </remarks>
        /// <value>The name of the TMDb's latest person method.</value>
        public string LatestPersonMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}
        /// </remarks>
        /// <value>The name of the TMDb's list method.</value>
        public string ListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list status method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}/item_status
        /// </remarks>
        /// <value>The name of the TMDb's list status method.</value>
        public string ListStatusMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's create movie list method.
        /// </summary>
        /// <remarks>
        ///     Currently (28.06.2013): list
        ///     Method: /3/list =>     http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
        /// </remarks>
        /// <value>The name of the TMDb's create movie list method.</value>
        public string CreateMovieListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list add item method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}/add_item
        /// </remarks>
        /// <value>The name of the TMDb's list add item method.</value>
        public string ListAddItemMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list remove item method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}/remove_item
        /// </remarks>
        /// <value>The name of the TMDb's list remove item method.</value>
        public string ListRemoveItemMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's delete list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}
        /// </remarks>
        /// <value>The name of the TMDb's delete list method.</value>
        public string DeleteListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's company method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): company/{id}
        /// </remarks>
        /// <value>The name of the TMDb's company method.</value>
        public string CompanyMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's company movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): company/{id}/movies
        /// </remarks>
        /// <value>The name of the TMDb's company movies method.</value>
        public string CompanyMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's genre list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): genre/list
        /// </remarks>
        /// <value>The name of the TMDb's genre list method.</value>
        public string GenreListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's genre movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): genre/{id}/movies
        /// </remarks>
        /// <value>The name of the TMDb's genre movies method.</value>
        public string GenreMovieMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's keyword method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): keyword/{id}
        /// </remarks>
        /// <value>The name of the TMDb's keyword method.</value>
        public string KeywordMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's keyword movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): keyword/{id}/movies
        /// </remarks>
        /// <value>The name of the TMDb's keyword movies method.</value>
        public string KeywordMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): discover/movie
        /// </remarks>
        /// <value>The name of the TMDb's discover method.</value>
        public string DiscoverMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/movie
        /// </remarks>
        /// <value>The name of the TMDb's search movie method.</value>
        public string SearchMovieMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search collection method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/collection
        ///     Method: /3/search/collection =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcollection
        /// </remarks>
        /// <value>The name of the TMDb's search collection method.</value>
        public string SearchCollectionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search person method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/person
        ///     Method: /3/search/person =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fperson
        /// </remarks>
        /// <value>The name of the TMDb's search person method.</value>
        public string SearchPersonMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/list
        ///     Method: /3/search/list =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Flist
        /// </remarks>
        /// <value>The name of the TMDb's search list method.</value>
        public string SearchListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search company method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/company
        ///     Method: /3/search/company =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcompany
        /// </remarks>
        /// <value>The name of the TMDb's search company method.</value>
        public string SearchCompanyMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search keyword method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/keyword
        ///     Method: /3/search/keyword =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fkeyword
        /// </remarks>
        /// <value>The name of the TMDb's search keyword method.</value>
        public string SearchKeywordMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's review method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): review/{id}
        ///     Method: /3/review/{id} =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Freview%2F%7Bid%7D
        /// </remarks>
        /// <value>The name of the TMDb's review method.</value>
        public string ReviewMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's changed people method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): person/changes
        ///     Method: /3/person/changes =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's changed people method.</value>
        public string ChangedPeopleMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's jobs method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): job/list
        ///     Method: /3/review/{id} =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
        /// </remarks>
        /// <value>The name of the TMDb's jobs method.</value>
        public string JobsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's changed movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): movie/changes
        ///     Method: /3/movie/changes =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's changed movies method.</value>
        public string ChangedMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the request token parameter of the authentication new session method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): request_token
        /// </remarks>
        /// <value>The name of the request token parameter of the authentication new session method.</value>
        public string AuthenticationTokenParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the language parameter of the movie, similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account rated movies, account watch list, collection, collection images and images method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): language
        /// </remarks>
        /// <value>
        ///     The name of the language parameter of the movie, similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account rated movies, account watch list, collection, collection images and images method.
        /// </value>
        public string LanguageParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the country parameter of the alternate titles method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): country
        /// </remarks>
        /// <value>The name of the country parameter of the alternate titles method.</value>
        public string CountryParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the page parameter of the similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account watch list and review method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): page
        /// </remarks>
        /// <value>
        ///     The name of the page parameter of the similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account watch list and review method.
        /// </value>
        public string PageParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the start date parameter of the changes method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): start_date
        /// </remarks>
        /// <value>The name of the start date parameter of the changes method.</value>
        public string StartDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the end date parameter of the changes method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): end_date
        /// </remarks>
        /// <value>The name of the end date parameter of the changes method.</value>
        public string EndDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the session ID parameter of the account states, account, account lists, account favorite movies,
        ///     account favorite, account rated, account rated movies movies, account watch list, account edit watch list and rating method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): session_id
        /// </remarks>
        /// <value>
        ///     The name of the session ID parameter of the account states, account, account lists, account favorite movies,
        ///     account favorite, account rated movies, account rated movies, account watch list, account edit watch list and rating method.
        /// </value>
        public string SessionIdParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the guest session ID parameter of the rating method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): guest_session_id
        /// </remarks>
        /// <value>The name of the guest session ID parameter of the rating method.</value>
        public string GuestSessionIdParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sort by parameter of the account favorite movies, account rated movies, account watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): sort_by
        /// </remarks>
        /// <value>The name of the sort by parameter of the account favorite movies, account rated movies, account watch list method.</value>
        public string SortByParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sort order parameter of the account favorite movies, account rated movies, account watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): sort_order
        /// </remarks>
        /// <value>The name of the sort order parameter of the account favorite movies, account rated movies, account watch list method.</value>
        public string SortOrderParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the add to response parameter of the movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): append_to_response
        /// </remarks>
        /// <value>The name of the add to response parameter of the movie method.</value>
        public string AddToResponseParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the movie id parameter of the list status method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): movie_id
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Flist%2F%7Bid%7D%2Fitem_status
        /// </remarks>
        /// <value>The name of the movie id parameter of the list status method.</value>
        public string MovieIdParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the include adult parameter of the company movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): include_adult
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <value>The name of the include adult parameter of the company movies method.</value>
        public string IncludeAdultParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the include all movies parameter of the company movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): include_all_movies
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <value>The name of the include all movies parameter of the company movies method.</value>
        public string IncludeAllMoviesParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the certification country parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): certification_country
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <value>The name of the certification country parameter of the Discover method.</value>
        public string CertificationCountryParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the year parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): year
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the year parameter of the Discover method.</value>
        public string YearParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the minimum vote count parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): vote_count.gte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the minimum vote count parameter of the Discover method.</value>
        public string MinimumVoteCountParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the minimum vote average parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): vote_average.gte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the minimum vote average parameter of the Discover method.</value>
        public string MinimumVoteAverageParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the primary release year parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): primary_release_year
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the primary release year parameter of the Discover method.</value>
        public string PrimaryReleaseYearParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the minimum release date parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): release_date.gte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the minimum release date parameter of the Discover method.</value>
        public string MinimumReleaseDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the maximum release date parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): release_date.lte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the maximum release date parameter of the Discover method.</value>
        public string MaximumReleaseDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the maximum certification parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): certification.lte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the maximum certification parameter of the Discover method.</value>
        public string MaximumCertificationParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the with companies parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): with_companies
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the with companies parameter of the Discover method.</value>
        public string WithCompaniesParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sort by parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): sort_by
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the sort by parameter of the Discover method.</value>
        public string DiscoverySortByParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the with genres parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): with_genres
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the with genres parameter of the Discover method.</value>
        public string WithGenresParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the query parameter of the search movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): query
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <value>The name of the query parameter of the search movie method.</value>
        public string QueryParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the search type parameter of the search movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search_type
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <value>The name of the search type parameter of the search movie method.</value>
        public string SearchTypeParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the char used to separate multiple values in an 'AND' query.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): ,
        /// </remarks>
        /// <remarks>he char used to separate multiple values in an 'AND' query.</remarks>
        public string AndChar { get; set; }

        /// <summary>
        ///     Gets or sets the char used to separate multiple values in an 'OR' query.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): |
        /// </remarks>
        /// <remarks>he char used to separate multiple values in an 'OR' query.</remarks>
        public string OrChar { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.PopularityAsc</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): popularity.asc
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>
        ///     The value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.PopularityAsc</value>
        ///     .
        /// </remarks>
        public string SortByPopularityAscending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.PopularityDesc</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): popularity.desc
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>
        ///     The value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.PopularityDesc</value>
        ///     .
        /// </remarks>
        public string SortByPopularityDescending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.ReleaseDateAsc</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): release_date.asc
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>
        ///     The value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.ReleaseDateAsc</value>
        ///     .
        /// </remarks>
        public string SortByReleaseDateAscending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.ReleaseDateDesc</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): release_date.desc
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>
        ///     The value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.ReleaseDateDesc</value>
        ///     .
        /// </remarks>
        public string SortByReleaseDateDescending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.VoteAverageAsc</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): vote_average.asc
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>
        ///     The value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.VoteAverageAsc</value>
        ///     .
        /// </remarks>
        public string SortByVoteAverageAscending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.VoteAverageDesc</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): vote_average.desc
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>
        ///     The value of the sorting parameter of the discover method, for
        ///     <value>TmdbDiscoverySortBy.VoteAverageDesc</value>
        ///     .
        /// </remarks>
        public string SortByVoteAverageDescending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append method parameter of the discover method, for
        ///     <value>TmdbCollectionMethod.Images</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): images
        ///     Used for the following methods:
        ///     /3/collection/{id} =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append method parameter of the discover method, for
        ///     <value>TmdbCollectionMethod.Images</value>
        ///     .
        /// </remarks>
        public string MovieCollectionAppendImages { get; set; }

        /// <summary>
        ///     Gets or sets the value of the search type parameter of the search movie and search person method, for
        ///     <value>TmdbSearchType.Phrase</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): phrase
        ///     Used for the following methods:
        ///     /3/search/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        ///     /3/search/person =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fperson
        /// </remarks>
        /// <remarks>
        ///     The value of the search type parameter of the search movie and search person method, for
        ///     <value>TmdbSearchType.Phrase</value>
        ///     .
        /// </remarks>
        public string SearchTypePhrase { get; set; }

        /// <summary>
        ///     Gets or sets the value of the search type parameter of the search movie and search person method, for
        ///     <value>TmdbSearchType.Ngram</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): ngram
        ///     Used for the following methods:
        ///     /3/search/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        ///     /3/search/person =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fperson
        /// </remarks>
        /// <remarks>
        ///     The value of the search type parameter of the search movie and search person method, for
        ///     <value>TmdbSearchType.Ngram</value>
        ///     .
        /// </remarks>
        public string SearchTypeNgram { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sort by parameter of account movie list methods, for
        ///     <value>TmdbSortBy.CreatedAt</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): created_at
        ///     Used for the following methods:
        ///     /3/account/{id}/favorite_movies =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite_movies
        ///     /3/account/{id}/rated_movies    =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Frated_movies
        ///     /3/account/{id}/movie_watchlist =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
        /// </remarks>
        /// <remarks>
        ///     The value of the sort by parameter of account movie list methods, for
        ///     <value>TmdbSortBy.CreatedAt</value>
        ///     .
        /// </remarks>
        public string SortByCreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sort order parameter of account movie list methods, for
        ///     <value>TmdbSortOrder.Ascending</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): asc
        ///     Used for the following methods:
        ///     /3/account/{id}/favorite_movies =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite_movies
        ///     /3/account/{id}/rated_movies    =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Frated_movies
        ///     /3/account/{id}/movie_watchlist =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
        /// </remarks>
        /// <remarks>
        ///     The value of the sort order parameter of account movie list methods, for
        ///     <value>TmdbSortOrder.Ascending</value>
        ///     .
        /// </remarks>
        public string SortOrderAscending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sort order parameter of account movie list methods, for
        ///     <value>TmdbSortOrder.Descending</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): desc
        ///     Used for the following methods:
        ///     /3/account/{id}/favorite_movies =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite_movies
        ///     /3/account/{id}/rated_movies    =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Frated_movies
        ///     /3/account/{id}/movie_watchlist =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
        /// </remarks>
        /// <remarks>
        ///     The value of the sort order parameter of account movie list methods, for
        ///     <value>TmdbSortOrder.Descending</value>
        ///     .
        /// </remarks>
        public string SortOrderDescending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the person method, for
        ///     <value>TmdbPersonMethod.Credits</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): credits
        ///     Used for the following methods:
        ///     /3/person/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the person method, for
        ///     <value>TmdbPersonMethod.Credits</value>
        ///     .
        /// </remarks>
        public string AppendToPersonMethodCredits { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the person method, for
        ///     <value>TmdbPersonMethod.Images</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): images
        ///     Used for the following methods:
        ///     /3/person/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the person method, for
        ///     <value>TmdbPersonMethod.Images</value>
        ///     .
        /// </remarks>
        public string AppendToPersonMethodImages { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the person method, for
        ///     <value>TmdbPersonMethod.Changes</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): changes
        ///     Used for the following methods:
        ///     /3/person/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the person method, for
        ///     <value>TmdbPersonMethod.Changes</value>
        ///     .
        /// </remarks>
        public string AppendToPersonMethodChanges { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.AlternativeTitles</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): alternative_titles
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.AlternativeTitles</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodAlternativeTitles { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Casts</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): casts
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Casts</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodCasts { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Images</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): images
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Images</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodImages { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Keywords</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): keywords
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Keywords</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodKeywords { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Releases</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): releases
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Releases</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodReleases { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Trailers</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): trailers
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Trailers</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodTrailers { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Translations</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): translations
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Translations</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodTranslations { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.SimilarMovies</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): similar_movies
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.SimilarMovies</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodSimilarMovies { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Reviews</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): reviews
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Reviews</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodReviews { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Lists</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): lists
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Lists</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodLists { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Changes</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (27.06.2013): changes
        ///     Used for the following methods:
        ///     /3/movie/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the movie method, for
        ///     <value>TmdbMovieMethod.Changes</value>
        ///     .
        /// </remarks>
        public string AppendToMovieMethodChanges { get; set; }

        /// <summary>
        ///     Gets or sets the value of the append to response parameter of the company method, for
        ///     <value>TmdbCompanyMethod.Movies</value>
        ///     .
        /// </summary>
        /// <remarks>
        ///     Currently (02.07.2013): movies
        ///     Used for the following methods:
        ///     /3/company/{id} =>       http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D
        /// </remarks>
        /// <remarks>
        ///     The value of the append to response parameter of the company method, for
        ///     <value>TmdbCompanyMethod.Movies</value>
        ///     .
        /// </remarks>
        public string AppendToCompanyMethodMovies { get; set; }

        #endregion Implementation of IApiConfiguration

        #region Public Members

        /// <summary>
        ///     Sets all properties to their default value.
        /// </summary>
        /// <remarks>
        ///     The default values can change at any time.
        ///     I try to update them when they change...
        ///     Please notify me if you find outdated values which are
        ///     not updated in the latest release of this library.
        /// </remarks>
        /// <param name="apiKey">A valid TMDb API key.</param>
        public void RestoreDefaultValues( String apiKey = null )
        {
            ApiKeyParameterName = "api_key";
            ApiUrl = "http://api.themoviedb.org/3";
            SecureApiUrl = "https://api.themoviedb.org/3";
            ApiKey = apiKey ?? String.Empty;
            UseSecureConnection = false;
            OriginalImageSizeValue = "original";
            ConfigurationMethodName = "configuration";
            NewAuthenticationTokenMethodName = "authentication/token/new";
            NewSessionMethodName = "authentication/session/new";
            CreateMovieListMethodName = "list";
            AuthenticationTokenParameterName = "request_token";
            NewGuestSessionMethodName = "authentication/guest_session/new";
            JsonDateTimePattern = "yyyy-MM-dd HH:mm:ss 'UTC'";
            JsonDatePattern = "yyyy-MM-dd";
            GetMovieMethodName = "movie/{0}";
            LanguageParameterName = "language";
            MovieAlternativeTitlesMethodName = "movie/{0}/alternative_titles";
            CountryParameterName = "country";
            MovieCastMethodName = "movie/{0}/casts";
            ImagesMethodName = "movie/{0}/images";
            MovieKeywordsMethodName = "movie/{0}/keywords";
            MovieReleasesMethodName = "movie/{0}/releases";
            MovieTrailersMethodName = "movie/{0}/trailers";
            MovieTranslationsMethodName = "movie/{0}/translations";
            SimilarMoviesMethodName = "movie/{0}/similar_movies";
            MovieReviewsMethodName = "movie/{0}/reviews";
            PageParameterName = "page";
            MovieListsMethodName = "movie/{0}/lists";
            MovieChangesMethodName = "movie/{0}/changes";
            EndDateParameterName = "end_date";
            StartDateParameterName = "start_date";
            LatestMoviesMethodName = "movie/latest";
            UpcomingMethodName = "movie/upcoming";
            NowPlayingMoviesMethodName = "movie/now_playing";
            PopularMethodName = "movie/popular";
            TopRatedMoviesMethodName = "movie/top_rated";
            MovieAccountStatesMethodName = "movie/{0}/account_states";
            SessionIdParameterName = "session_id";
            RatingMethodName = "movie/{0}/rating";
            GuestSessionIdParameterName = "guest_session_id";
            AccountMethodName = "account";
            AccountListsMethodName = "account/{0}/lists";
            AccountFavoriteMoviesMethodName = "account/{0}/favorite_movies";
            SortByParameterName = "sort_by";
            SortOrderParameterName = "sort_order";
            AccountAddFavoriteMethodName = "account/{0}/favorite";
            AccountRatedMoviesMethodName = "account/{0}/rated_movies";
            AccountWatchListMethodName = "account/{0}/movie_watchlist";
            AccountEditWatchListMethodName = "account/{0}/movie_watchlist";
            AddToResponseParameterName = "append_to_response";
            MovieCollectionMethodName = "collection/{0}";
            MovieCollectionImageMethodName = "collection/{0}/images";
            GetPersonMethodName = "person/{0}";
            PersonCreditsMethodName = "person/{0}/credits";
            PersonImagesMethodName = "person/{0}/images";
            PersonChangesMethodName = "person/{0}/changes";
            PopularPeopleMethodName = "person/popular";
            LatestPersonMethodName = "person/latest";
            ListMethodName = "list/{0}";
            ListStatusMethodName = "list/{0}/item_status";
            MovieIdParameterName = "movie_id";
            ListAddItemMethodName = "list/{0}/add_item";
            ListRemoveItemMethodName = "list/{0}/remove_item";
            DeleteListMethodName = "list/{0}";
            CompanyMethodName = "company/{0}";
            CompanyMoviesMethodName = "company/{0}/movies";
            IncludeAllMoviesParameterName = "include_all_movies";
            IncludeAdultParameterName = "include_adult";
            KeywordMethodName = "keyword/{0}";
            KeywordMoviesMethodName = "keyword/{0}/movies";
            DiscoverMethodName = "discover/movie";
            CertificationCountryParameterName = "certification_country";
            YearParameterName = "year";
            MinimumVoteCountParameterName = "vote_count.gte";
            MinimumVoteAverageParameterName = "vote_average.gte";
            PrimaryReleaseYearParameterName = "primary_release_year";
            MinimumReleaseDateParameterName = "release_date.gte";
            MaximumReleaseDateParameterName = "release_date.lte";
            MaximumCertificationParameterName = "certification.lte";
            WithCompaniesParameterName = "with_companies";
            DiscoverySortByParameterName = "sort_by";
            WithGenresParameterName = "with_genres";
            AndChar = ";";
            OrChar = "|";
            GenreListMethodName = "genre/list";
            GenreMovieMethodName = "genre/{0}/movies";
            SearchMovieMethodName = "search/movie";
            QueryParameterName = "query";
            SearchTypeParameterName = "search_type";
            SearchCollectionMethodName = "search/collection";
            SearchPersonMethodName = "search/person";
            SearchListMethodName = "search/list";
            SearchCompanyMethodName = "search/company";
            SearchKeywordMethodName = "search/keyword";
            ReviewMethodName = "review/{0}";
            JobsMethodName = "job/list";
            ChangedMoviesMethodName = "movie/changes";
            ChangedPeopleMethodName = "person/changes";
            CacheLevel = NTmdb.CacheLevel.Default;
            SortByPopularityAscending = "popularity.asc";
            SortByPopularityDescending = "popularity.desc";
            SortByReleaseDateAscending = "release_date.asc";
            SortByReleaseDateDescending = "release_date.desc";
            SortByVoteAverageAscending = "vote_average.asc";
            SortByVoteAverageDescending = "vote_average.desc";
            MovieCollectionAppendImages = "images";
            SearchTypePhrase = "phrase";
            SearchTypeNgram = "ngram";
            SortByCreatedAt = "created_at";
            SortOrderAscending = "asc";
            SortOrderDescending = "desc";
            AppendToPersonMethodCredits = "credits";
            AppendToPersonMethodImages = "images";
            AppendToPersonMethodChanges = "changes";
            AppendToMovieMethodAlternativeTitles = "alternative_titles";
            AppendToMovieMethodCasts = "casts";
            AppendToMovieMethodImages = "images";
            AppendToMovieMethodKeywords = "keywords";
            AppendToMovieMethodReleases = "releases";
            AppendToMovieMethodTrailers = "trailers";
            AppendToMovieMethodTranslations = "translations";
            AppendToMovieMethodSimilarMovies = "similar_movies";
            AppendToMovieMethodReviews = "reviews";
            AppendToMovieMethodLists = "lists";
            AppendToMovieMethodChanges = "changes";
            AppendToCompanyMethodMovies = "movies";
            Timeout = TimeSpan.FromSeconds( 10 );
        }

        /// <summary>
        ///     Serialize the current instance of the API configuration into a string.
        /// </summary>
        /// <returns>The current instance of the API configuration as string.</returns>
        public String Serialize()
        {
            var xml = new XmlSerializer( GetType() );
            using ( var stream = new StringWriter() )
            {
                xml.Serialize( stream, this );
                return stream.ToString();
            }
        }

        /// <summary>
        ///     Deserializes a new API configuration from the given string.
        /// </summary>
        /// <param name="content">A serialized API configuration.</param>
        /// <returns>The deserialized API configuration.</returns>
        public static IApiConfiguration Deserialize( String content )
        {
            var xml = new XmlSerializer( typeof ( ApiConfiguration ) );
            using ( var stream = new StringReader( content ) )
                return xml.Deserialize( stream ) as ApiConfiguration;
        }

        #endregion Public Members
    }
}