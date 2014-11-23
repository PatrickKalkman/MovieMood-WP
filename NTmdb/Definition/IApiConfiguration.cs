using System;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing the configuration for the TMDb API.
    /// </summary>
    public interface IApiConfiguration
    {
        #region Connection

        /// <summary>
        ///     Gets or sets the cache level of the requests.
        /// </summary>
        /// <value>The cache level of the requests.</value>
        CacheLevel? CacheLevel { get; set; }

        /// <summary>
        ///     Gets or sets the timeout used to send a request to the TMDb and receive a response from the TMDb.
        /// </summary>
        /// <value>The timeout used to send a request to the TMDb and receive a response from the TMDb.</value>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        ///     Gets or sets a value determining whether a secure connection should get used or not.
        /// </summary>
        /// <value>A value determining whether a secure connection should get used or not.</value>
        Boolean? UseSecureConnection { get; set; }

        #endregion Connection

        #region Common

        /// <summary>
        ///     Gets or sets the TMDb PI key.
        /// </summary>
        /// <value>The TMDb PI key.</value>
        String ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets the pattern used by the TMDb API for <see cref="DateTime" /> values.
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: "yyyy-MM-dd HH:mm:ss 'UTC'"
        /// </remarks>
        /// <value>
        ///     The pattern used by the TMDb API for <see cref="DateTime" /> values.
        /// </value>
        String JsonDateTimePattern { get; set; }

        /// <summary>
        ///     Gets or sets the pattern used by the TMDb API for <see cref="DateTime" /> values (only date no time).
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: "yyyy-MM-dd"
        /// </remarks>
        /// <value>
        ///     The pattern used by the TMDb API for <see cref="DateTime" /> values (only date no time).
        /// </value>
        String JsonDatePattern { get; set; }

        /// <summary>
        ///     Gets or sets the URL of the TMDb API.
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: http://api.themoviedb.org/3
        /// </remarks>
        /// <value>The URL of the TMDb API. </value>
        String ApiUrl { get; set; }

        /// <summary>
        ///     Gets or sets the secure URL of the TMDb API.
        /// </summary>
        /// <remarks>
        ///     Currently(21.06.2013) it is: https://api.themoviedb.org/3
        /// </remarks>
        /// <value>The secure URL of the TMDb API. </value>
        String SecureApiUrl { get; set; }

        /// <summary>
        ///     Gets or sets the name of the API key parameter.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): api_key
        /// </remarks>
        /// <value>The name of the API key parameter.</value>
        String ApiKeyParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the original size value, used to build a image URL.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fconfiguration
        /// </remarks>
        /// <value>The original size value, used to build a image URL.</value>
        String OriginalImageSizeValue { get; set; }

        #endregion Common

        #region Method Names

        /// <summary>
        ///     Gets or sets the name of the TMDb's configuration method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): configuration
        /// </remarks>
        /// <value>The name of the TMDb's configuration method.</value>
        String ConfigurationMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's authentication new token method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): authentication/token/new
        /// </remarks>
        /// <value>The name of the TMDb's authentication new token method.</value>
        String NewAuthenticationTokenMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's authentication new session method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): authentication/session/new
        /// </remarks>
        /// <value>The name of the TMDb's authentication new session method.</value>
        String NewSessionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's authentication new guest session method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): authentication/guest_session/new
        /// </remarks>
        /// <value>The name of the TMDb's authentication new guest session method.</value>
        String NewGuestSessionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account
        /// </remarks>
        /// <value>The name of the TMDb's account method.</value>
        String AccountMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account lists method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/lists
        /// </remarks>
        /// <value>The name of the TMDb's account lists method.</value>
        String AccountListsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account favorite movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/favorite_movies
        /// </remarks>
        /// <value>The name of the TMDb's account favorite movies lists method.</value>
        String AccountFavoriteMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account favorite method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/favorite
        /// </remarks>
        /// <value>The name of the TMDb's account favorite method.</value>
        String AccountAddFavoriteMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account rated movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/rated_movies
        /// </remarks>
        /// <value>The name of the TMDb's account rated movies method.</value>
        String AccountRatedMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/movie_watchlist
        /// </remarks>
        /// <value>The name of the TMDb's account watch list method.</value>
        String AccountWatchListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's account edit watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): account/{id}/movie_watchlist
        /// </remarks>
        /// <value>The name of the TMDb's account edit watch list method.</value>
        String AccountEditWatchListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/ (with parameter id: movie/{id})
        /// </remarks>
        /// <value>The name of the TMDb's movie method.</value>
        String GetMovieMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's alternative titles method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/alternative_titles
        /// </remarks>
        /// <value>The name of the TMDb's alternative titles method.</value>
        String MovieAlternativeTitlesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's cast method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/casts
        /// </remarks>
        /// <value>The name of the TMDb's cast method.</value>
        String MovieCastMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's keywords method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/keywords
        /// </remarks>
        /// <value>The name of the TMDb's keywords method.</value>
        String MovieKeywordsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's releases method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/releases
        /// </remarks>
        /// <value>The name of the TMDb's releases method.</value>
        String MovieReleasesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's images method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/images
        /// </remarks>
        /// <value>The name of the TMDb's images method.</value>
        String ImagesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's trailers method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/trailers
        /// </remarks>
        /// <value>The name of the TMDb's trailers method.</value>
        String MovieTrailersMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's translations method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/translations
        /// </remarks>
        /// <value>The name of the TMDb's translations method.</value>
        String MovieTranslationsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's similar movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/similar_movies
        /// </remarks>
        /// <value>The name of the TMDb's similar movies method.</value>
        String SimilarMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's reviews method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/reviews
        /// </remarks>
        /// <value>The name of the TMDb's reviews method.</value>
        String MovieReviewsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's lists method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/lists
        /// </remarks>
        /// <value>The name of the TMDb's lists method.</value>
        String MovieListsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's changes method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/changes
        /// </remarks>
        /// <value>The name of the TMDb's changes method.</value>
        String MovieChangesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's latest method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/latest
        /// </remarks>
        /// <value>The name of the TMDb's latest method.</value>
        String LatestMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's upcoming method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/upcoming
        /// </remarks>
        /// <value>The name of the TMDb's upcoming method.</value>
        String UpcomingMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's now playing method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/now_playing
        /// </remarks>
        /// <value>The name of the TMDb's now playing method.</value>
        String NowPlayingMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's popular method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/popular
        /// </remarks>
        /// <value>The name of the TMDb's popular method.</value>
        String PopularMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's top rated method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/top_rated
        /// </remarks>
        /// <value>The name of the TMDb's top rated method.</value>
        String TopRatedMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's movie account state method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/account_states
        /// </remarks>
        /// <value>The name of the TMDb's movie account state method.</value>
        String MovieAccountStatesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's rating method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): movie/{id}/rating
        /// </remarks>
        /// <value>The name of the TMDb's rating method.</value>
        String RatingMethodName { get; set; }

        #region Collection

        /// <summary>
        ///     Gets or sets the name of the TMDb's collection method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): collection/{id}
        /// </remarks>
        /// <value>The name of the TMDb's collection method.</value>
        String MovieCollectionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's collection image method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): collection/{id}/images
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <value>The name of the TMDb's collection image method.</value>
        String MovieCollectionImageMethodName { get; set; }

        #endregion Collection

        #region People

        /// <summary>
        ///     Gets or sets the name of the TMDb's person method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <value>The name of the TMDb's person method.</value>
        String GetPersonMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person credits method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}/credits
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
        /// </remarks>
        /// <value>The name of the TMDb's person credits method.</value>
        String PersonCreditsMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person images method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}/images
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <value>The name of the TMDb's person images method.</value>
        String PersonImagesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's person changes method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/{id}/changes
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's person changes method.</value>
        String PersonChangesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's popular people method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/popular
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's popular people method.</value>
        String PopularPeopleMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's latest person method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): person/latest
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Flatest
        /// </remarks>
        /// <value>The name of the TMDb's latest person method.</value>
        String LatestPersonMethodName { get; set; }

        #endregion People

        #region Lists

        /// <summary>
        ///     Gets or sets the name of the TMDb's list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}
        /// </remarks>
        /// <value>The name of the TMDb's list method.</value>
        String ListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list status method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}/item_status
        /// </remarks>
        /// <value>The name of the TMDb's list status method.</value>
        String ListStatusMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's create movie list method.
        /// </summary>
        /// <remarks>
        ///     Currently (28.06.2013): list
        ///     Method: /3/list =>     http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
        /// </remarks>
        /// <value>The name of the TMDb's create movie list method.</value>
        String CreateMovieListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list add item method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}/add_item
        /// </remarks>
        /// <value>The name of the TMDb's list add item method.</value>
        String ListAddItemMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's list remove item method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}/remove_item
        /// </remarks>
        /// <value>The name of the TMDb's list remove item method.</value>
        String ListRemoveItemMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's delete list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): list/{id}
        /// </remarks>
        /// <value>The name of the TMDb's delete list method.</value>
        String DeleteListMethodName { get; set; }

        #endregion Lists

        #region Companies

        /// <summary>
        ///     Gets or sets the name of the TMDb's company method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): company/{id}
        /// </remarks>
        /// <value>The name of the TMDb's company method.</value>
        String CompanyMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's company movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): company/{id}/movies
        /// </remarks>
        /// <value>The name of the TMDb's company movies method.</value>
        String CompanyMoviesMethodName { get; set; }

        #endregion Companies

        #region Genres

        /// <summary>
        ///     Gets or sets the name of the TMDb's genre list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): genre/list
        /// </remarks>
        /// <value>The name of the TMDb's genre list method.</value>
        String GenreListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's genre movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): genre/{id}/movies
        /// </remarks>
        /// <value>The name of the TMDb's genre movies method.</value>
        String GenreMovieMethodName { get; set; }

        #endregion Genres

        #region Keywords

        /// <summary>
        ///     Gets or sets the name of the TMDb's keyword method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): keyword/{id}
        /// </remarks>
        /// <value>The name of the TMDb's keyword method.</value>
        String KeywordMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's keyword movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): keyword/{id}/movies
        /// </remarks>
        /// <value>The name of the TMDb's keyword movies method.</value>
        String KeywordMoviesMethodName { get; set; }

        #endregion Keywords

        #region Discover

        /// <summary>
        ///     Gets or sets the name of the TMDb's discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): discover/movie
        /// </remarks>
        /// <value>The name of the TMDb's discover method.</value>
        String DiscoverMethodName { get; set; }

        #endregion Discover

        #region Search

        /// <summary>
        ///     Gets or sets the name of the TMDb's search movie method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/movie
        /// </remarks>
        /// <value>The name of the TMDb's search movie method.</value>
        String SearchMovieMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search collection method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/collection
        ///     Method: /3/search/collection =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcollection
        /// </remarks>
        /// <value>The name of the TMDb's search collection method.</value>
        String SearchCollectionMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search person method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/person
        ///     Method: /3/search/person =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fperson
        /// </remarks>
        /// <value>The name of the TMDb's search person method.</value>
        String SearchPersonMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search list method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/list
        ///     Method: /3/search/list =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Flist
        /// </remarks>
        /// <value>The name of the TMDb's search list method.</value>
        String SearchListMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search company method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/company
        ///     Method: /3/search/company =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fcompany
        /// </remarks>
        /// <value>The name of the TMDb's search company method.</value>
        String SearchCompanyMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's search keyword method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search/keyword
        ///     Method: /3/search/keyword =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fkeyword
        /// </remarks>
        /// <value>The name of the TMDb's search keyword method.</value>
        String SearchKeywordMethodName { get; set; }

        #endregion Search

        #region Review

        /// <summary>
        ///     Gets or sets the name of the TMDb's review method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): review/{id}
        ///     Method: /3/review/{id} =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Freview%2F%7Bid%7D
        /// </remarks>
        /// <value>The name of the TMDb's review method.</value>
        String ReviewMethodName { get; set; }

        #endregion Review

        #region Changes

        /// <summary>
        ///     Gets or sets the name of the TMDb's changed movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): movie/changes
        ///     Method: /3/movie/changes =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's changed movies method.</value>
        String ChangedMoviesMethodName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the TMDb's changed people method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): person/changes
        ///     Method: /3/person/changes =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
        /// </remarks>
        /// <value>The name of the TMDb's changed people method.</value>
        String ChangedPeopleMethodName { get; set; }

        #endregion Changes

        #region Jobs

        /// <summary>
        ///     Gets or sets the name of the TMDb's jobs method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): job/list
        ///     Method: /3/review/{id} =>     http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
        /// </remarks>
        /// <value>The name of the TMDb's jobs method.</value>
        String JobsMethodName { get; set; }

        #endregion Jobs

        #endregion Method Names

        #region Parameter Names

        /// <summary>
        ///     Gets or sets the name of the request token parameter of the authentication new session method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): request_token
        /// </remarks>
        /// <value>The name of the request token parameter of the authentication new session method.</value>
        String AuthenticationTokenParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the language parameter of the movie, similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account rated movies, account watch list, collection, collection images,
        ///     person credits, company movies, discover, genre list, genre movies, search movies, search collection and images method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): language
        /// </remarks>
        /// <value>
        ///     The name of the language parameter of the movie, similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account rated movies, account watch list, collection, collection images,
        ///     person credits, company movies, discover, genre list, genre movies, search movies, search collection and images method.
        /// </value>
        String LanguageParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the country parameter of the alternate titles method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): country
        /// </remarks>
        /// <value>The name of the country parameter of the alternate titles method.</value>
        String CountryParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the page parameter of the similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account watch list, popular people, company movies, keyword movies, discover, genre movies,
        ///     search movie, search collection, search list, search company, search keyword and review method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): page
        /// </remarks>
        /// <value>
        ///     The name of the page parameter of the similar movies, lists, upcoming, now playing, popular,
        ///     top rated, account lists, account favorite movies, account watch list, popular people, company movies, keyword movies, discover, genre movies,
        ///     search movies, search collection, search list, search company, search keyword and review method.
        /// </value>
        String PageParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the start date parameter of the movie changes and person changes, changed movies, changed people method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): start_date
        /// </remarks>
        /// <value>The name of the start date parameter of the movie changes and person changes, changed movies, changed people method.</value>
        String StartDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the end date parameter of the movie changes and person changes, changed movies, changed people method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): end_date
        /// </remarks>
        /// <value>The name of the end date parameter of the changes and person changes, changed movies, changed people method.</value>
        String EndDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the session ID parameter of the account states, account, account lists, account favorite movies,
        ///     account favorite, account rated, account rated movies movies, account watch list, account edit watch list, list add item,
        ///     list remove item and rating method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): session_id
        /// </remarks>
        /// <value>
        ///     The name of the session ID parameter of the account states, account, account lists, account favorite movies,
        ///     account favorite, account rated movies, account rated movies, account watch list, account edit watch list,
        ///     list remove item list add item and rating method.
        /// </value>
        String SessionIdParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the guest session ID parameter of the rating method.
        /// </summary>
        /// <remarks>
        ///     Currently (21.06.2013): guest_session_id
        /// </remarks>
        /// <value>The name of the guest session ID parameter of the rating method.</value>
        String GuestSessionIdParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sort by parameter of the account favorite movies, account rated movies, account watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): sort_by
        /// </remarks>
        /// <value>The name of the sort by parameter of the account favorite movies, account rated movies, account watch list method.</value>
        String SortByParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sort order parameter of the account favorite movies, account rated movies, account watch list method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): sort_order
        /// </remarks>
        /// <value>The name of the sort order parameter of the account favorite movies, account rated movies, account watch list method.</value>
        String SortOrderParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the add to response parameter of the movie, collection and person method.
        /// </summary>
        /// <remarks>
        ///     Currently (24.06.2013): append_to_response
        /// </remarks>
        /// <value>The name of the add to response parameter of the movie, collection and person method.</value>
        String AddToResponseParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the movie id parameter of the list status method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): movie_id
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Flist%2F%7Bid%7D%2Fitem_status
        /// </remarks>
        /// <value>The name of the movie id parameter of the list status method.</value>
        String MovieIdParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the include adult parameter of the company movies, genre movies, search movies, search person, search list and discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): include_adult
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <value>The name of the include adult parameter of the company movies, genre movies, search movies, search person, search list and discover method.</value>
        String IncludeAdultParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the include all movies parameter of the company movies and genre movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): include_all_movies
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <value>The name of the include all movies parameter of the company movies and genre movies method.</value>
        String IncludeAllMoviesParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the certification country parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): certification_country
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the certification country parameter of the Discover method.</value>
        String CertificationCountryParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the year parameter of the Discover and search movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): year
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the year parameter of the Discover and search movies method.</value>
        String YearParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the minimum vote count parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): vote_count.gte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the minimum vote count parameter of the Discover method.</value>
        String MinimumVoteCountParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the minimum vote average parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): vote_average.gte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the minimum vote average parameter of the Discover method.</value>
        String MinimumVoteAverageParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the primary release year parameter of the Discover and search movies method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): primary_release_year
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the primary release year parameter of the Discover and search movies method.</value>
        String PrimaryReleaseYearParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the minimum release date parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): release_date.gte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the minimum release date parameter of the Discover method.</value>
        String MinimumReleaseDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the maximum release date parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): release_date.lte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the maximum release date parameter of the Discover method.</value>
        String MaximumReleaseDateParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the maximum certification parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): certification.lte
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the maximum certification parameter of the Discover method.</value>
        String MaximumCertificationParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the with companies parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): with_companies
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the with companies parameter of the Discover method.</value>
        String WithCompaniesParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the sort by parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): sort_by
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the sort by parameter of the Discover method.</value>
        String DiscoverySortByParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the with genres parameter of the Discover method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): with_genres
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <value>The name of the with genres parameter of the Discover method.</value>
        String WithGenresParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the query parameter of the search movie, search collection, search person, search list, search company, search keyword method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): query
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <value>The name of the query parameter of the search movie, search collection, search person, search list, search company, search keyword method.</value>
        String QueryParameterName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the search type parameter of the search movie, search person method.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): search_type
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <value>The name of the search type parameter of the search movie, search person method.</value>
        String SearchTypeParameterName { get; set; }

        #endregion Parameter Names

        #region Enum Names

        #region TmdbFilterOperator

        /// <summary>
        ///     Gets or sets the char used to separate multiple values in an 'AND' query.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): ,
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>The char used to separate multiple values in an 'AND' query.</remarks>
        String AndChar { get; set; }

        /// <summary>
        ///     Gets or sets the char used to separate multiple values in an 'OR' query.
        /// </summary>
        /// <remarks>
        ///     Currently (25.06.2013): |
        ///     Used for the following methods:
        ///     /3/discover/movie =>        http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <remarks>The char used to separate multiple values in an 'OR' query.</remarks>
        String OrChar { get; set; }

        #endregion TmdbFilterOperator

        #region TmdbDiscoverySortBy

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
        String SortByPopularityAscending { get; set; }

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
        String SortByPopularityDescending { get; set; }

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
        String SortByReleaseDateAscending { get; set; }

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
        String SortByReleaseDateDescending { get; set; }

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
        String SortByVoteAverageAscending { get; set; }

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
        String SortByVoteAverageDescending { get; set; }

        #endregion TmdbDiscoverySortBy

        #region TmdbCollectionMethod

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
        String MovieCollectionAppendImages { get; set; }

        #endregion TmdbCollectionMethod

        #region TmdbSearchType

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
        String SearchTypePhrase { get; set; }

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
        String SearchTypeNgram { get; set; }

        #endregion TmdbSearchType

        #region TmdbSortBy

        /// <summary>
        ///     Gets or sets the value of the sort by parameter of  the account movie list methods, for
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
        ///     The value of the sort by parameter of the account movie list methods, for
        ///     <value>TmdbSortBy.CreatedAt</value>
        ///     .
        /// </remarks>
        String SortByCreatedAt { get; set; }

        #endregion TmdbSortBy

        #region TmdbSortOrder

        /// <summary>
        ///     Gets or sets the value of the sort order parameter of the account movie list methods, for
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
        ///     The value of the sort order parameter of the account movie list methods, for
        ///     <value>TmdbSortOrder.Ascending</value>
        ///     .
        /// </remarks>
        String SortOrderAscending { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sort order parameter of the account movie list methods, for
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
        ///     The value of the sort order parameter of the account movie list methods, for
        ///     <value>TmdbSortOrder.Descending</value>
        ///     .
        /// </remarks>
        String SortOrderDescending { get; set; }

        #endregion TmdbSortOrder

        #region TmdbPersonMethod

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
        String AppendToPersonMethodCredits { get; set; }

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
        String AppendToPersonMethodImages { get; set; }

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
        String AppendToPersonMethodChanges { get; set; }

        #endregion TmdbPersonMethod

        #region TmdbMovieMethod

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
        String AppendToMovieMethodAlternativeTitles { get; set; }

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
        String AppendToMovieMethodCasts { get; set; }

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
        String AppendToMovieMethodImages { get; set; }

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
        String AppendToMovieMethodKeywords { get; set; }

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
        String AppendToMovieMethodReleases { get; set; }

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
        String AppendToMovieMethodTrailers { get; set; }

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
        String AppendToMovieMethodTranslations { get; set; }

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
        String AppendToMovieMethodSimilarMovies { get; set; }

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
        String AppendToMovieMethodReviews { get; set; }

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
        String AppendToMovieMethodLists { get; set; }

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
        String AppendToMovieMethodChanges { get; set; }

        #endregion TmdbMovieMethod

        #region TmdbCompanyMethod

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
        String AppendToCompanyMethodMovies { get; set; }

        #endregion TmdbCompanyMethod

        #endregion Enum Names
    }
}