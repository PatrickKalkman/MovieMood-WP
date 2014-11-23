using System;
using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing the TMDb abstraction class.
    /// </summary>
    public interface ITmdbAbstraction
    {
        /// <summary>
        ///     Gets or sets the ISO 639-1 code of the request language.
        /// </summary>
        /// <remarks>
        ///     Default is
        ///     <value>null</value>
        ///     , in this case it will use the TMDb's default which is English.
        /// </remarks>
        /// <value>The ISO 639-1 code of the request language. </value>
        String Iso639_1LanguageCode { get; set; }

        /// <summary>
        ///     Gets or sets a value determining whether adult movies/actors should get loaded.
        /// </summary>
        /// <remarks>
        ///     Default is
        ///     <value>true</value>
        ///     .
        /// </remarks>
        /// <value>A value determining whether adult movies/actors should get loaded.</value>
        Boolean IncludeAdultMovies { get; set; }

        /// <summary>
        ///     Gets or sets a value which determines whether this class should throw exceptions if some are occurred during a API call, or if methods will return null values instead.
        /// </summary>
        /// <remarks>
        ///     Default is
        ///     <value>true</value>
        ///     .
        /// </remarks>
        /// <value>A value which determines whether this class should throw exceptions if some are occurred during a API call, or if methods will return null values instead.</value>
        Boolean ThrowException { get; set; }

        /// <summary>
        ///     Gets or sets the wrapper used to access the TMDb API.
        /// </summary>
        /// <value>The wrapper used to access the TMDb API.</value>
        IApiWrapper ApiWrapper { get; set; }

        /// <summary>
        ///     Gets or sets the session ID used for account related calls.
        /// </summary>
        /// <value>The session ID used for account related calls.</value>
        String SessionId { get; set; }

        /// <summary>
        ///     Gets or sets the configuration load from the TMDb API.
        /// </summary>
        /// <value>The configuration load from the TMDb API.</value>
        TmdbConfiguration TmdbConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets the session ID used for account related calls.
        /// </summary>
        /// <value>The session ID used for account related calls.</value>
        Int32 AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the authentication token used for creating a session Id.
        /// </summary>
        /// <value>The authentication token used for creating a session Id.</value>
        String AuthenticationToken { get; set; }

        /// <summary>
        ///     Gets the current TMDb configuration.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#configuration
        /// </remarks>
        /// <returns>The current TMDb configuration.</returns>
        Task<TmdbConfiguration> GetConfigurationAsync();

        /// <summary>
        ///     Gets a TMDb authentication authenticationToken.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        ///     Note: The authenticationToken expires after a period of time (check it's ExpiresAt property).
        /// </remarks>
        /// <returns>A new authentication authenticationToken.</returns>
        Task<TmdbAuthenticationToken> GetAuthenticationTokenAsync();

        /// <summary>
        ///     Gets a TMDb session.
        /// </summary>
        /// <param name="authenticationToken">The authentication authenticationToken needed to get a session.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        ///     Note: The user has to authorize a authenticationToken before you can create a session,
        ///     To authorize the authenticationToken, open: https://www.themoviedb.org/authenticate/{AuthenticationToken}
        ///     More information about session IDs: https://www.themoviedb.org/documentation/api/sessions
        /// </remarks>
        /// <returns>A new session, based on the given authenticationToken.</returns>
        Task<TmdbSession> GetSessionAsync( String authenticationToken = null );

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>A new guest session..</returns>
        Task<TmdbGuestSession> GetGuestSessionAsync();

        /// <summary>
        ///     Gets a valid session Id in one step, note that the user has to accept the token in the callback.
        /// </summary>
        /// <param name="userAceptTokenCallback">A callback in which the user has to accept the authentication token. (Return true means that the user has accepted the token).</param>
        /// <returns>A valid session ID, or null if the user has not accepted the token.</returns>
        Task<TmdbSession> GetSessionWithoutAuthenticationTokenAsync( Func<TmdbAuthenticationToken, Boolean> userAceptTokenCallback );

        /// <summary>
        ///     Get the basic information about the account to which the session ID belongs.
        /// </summary>
        /// <returns>The basic information about the account to which the session ID belongs.</returns>
        Task<TmdbAccount> GetAccountAsync();

        /// <summary>
        ///     Get the list of the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The list of the account with the given ID.</returns>
        Task<TmdbMovieListPreviewList> GetAccountListsAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Marks the movie in the given favorite request as favorite.
        /// </summary>
        /// <param name="favoriteRequest">A favorite request.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbStatusResponse> SetFavoriteAsync( TmdbFavoriteRequest favoriteRequest );

        /// <summary>
        ///     Adds/removes the movie with the given ID to/from the watch list.
        /// </summary>
        /// <param name="watchListRequest">A watch list request.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbStatusResponse> SetWatchListAsync( TmdbWatchListRequest watchListRequest );

        /// <summary>
        ///     Gets the list of the favorite movies of the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The list of the favorite movies of the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite_movies
        /// </remarks>
        Task<TmdbMoviePreviewList> GetAccountFavoriteMoviesAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets the list of the movies rated by the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The list of the movies rated by the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Frated_movies
        /// </remarks>
        Task<TmdbMoviePreviewList> GetAccountRatedMoviesAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets the watch list of the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The watch list of the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
        /// </remarks>
        Task<TmdbMoviePreviewList> GetAccountWatchListAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets the movie with the specified ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load.</param>
        /// <param name="appendMethod">Specifies the movie methods which should get appended to the movie method.</param>
        /// <remarks>
        ///     Note: Some of the properties of the returned movie object, may only be set when a specific method is appended to the movie method.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <returns>The movie with the given ID.</returns>
        Task<TmdbMovie> GetMovieAsync( Int32 movieId, TmdbMovieMethod appendMethod = TmdbMovieMethod.None );

        /// <summary>
        ///     Gets the alternative titles of the movie with the specified ID.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the titles of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The alternative titles of the movie with the given ID.</returns>
        Task<TmdbAlternativeTitles> GetAlternativeMovieTitlesAsync( Int32 movieId );

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the cast of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>The cast of the movie with the given ID.</returns>
        Task<TmdbStaff> GetMovieCastAsync( Int32 movieId );

        /// <summary>
        ///     Gets the images of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The images of the movie with the given ID.</returns>
        Task<TmdbImages> GetMovieImagesAsync( Int32 movieId );

        /// <summary>
        ///     Gets the current keywords of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the keywords of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The keywords of the movie with the given ID.</returns>
        Task<TmdbMovieKeywords> GetMovieKeywordsAsync( Int32 movieId );

        /// <summary>
        ///     Gets the releases of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the releases of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The releases of the movie with the given ID.</returns>
        Task<TmdbReleases> GetMovieReleasesAsync( Int32 movieId );

        /// <summary>
        ///     Gets the trailers of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the trailers of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The trailers of the movie with the given ID.</returns>
        Task<TmdbTrailers> GetMovieTrailersAsync( Int32 movieId );

        /// <summary>
        ///     Gets the translations of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the translations of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The translations of the movie with the given ID.</returns>
        Task<TmdbTranslations> GetMovieTranslationsAsync( Int32 movieId );

        /// <summary>
        ///     Gets the similar movies of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the similar movies of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The similar movies of the movie with the given ID.</returns>
        Task<TmdbMoviePreviewList> GetSimilarMoviesAsync( Int32 movieId, Int32? pageNumber = null );

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the reviews of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        Task<TmdbMovieReviews> GetMovieReviewsAsync( Int32 movieId, Int32? pageNumber = null );

        /// <summary>
        ///     Gets the movie lists of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the movie lists of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie lists of the movie with the given ID.</returns>
        Task<TmdbMovieLists> GetMovieListsAsync( Int32 movieId, Int32? pageNumber = null );

        /// <summary>
        ///     Gets the changes of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the changes of.</param>
        /// <param name="startDate">The start date of the changes.</param>
        /// <param name="endDate">The end date of the changes.</param>
        /// <remarks>
        ///     The maximum number of days that can be returned in a single request is 14.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D%2Fchanges
        /// </remarks>
        /// <returns>The changes of the movie with the given ID.</returns>
        Task<TmdbChanges> GetMovieChangesAsync( Int32 movieId, DateTime? startDate = null, DateTime? endDate = null );

        /// <summary>
        ///     Gets the latest movie.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The latest movie.</returns>
        Task<TmdbMovie> GetLatestMovieAsync();

        /// <summary>
        ///     Gets a list of upcoming movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of the upcoming movies.</returns>
        Task<TmdbMoviePreviewList> GetUpcomingMoviesAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets a list of movies playing in theatres.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A  list of movies playing in theatres.</returns>
        Task<TmdbMoviePreviewList> GetNowPlayingmoviesAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets a list of popular movies on The Movie Database.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of popular movies on The Movie Database.</returns>
        Task<TmdbMoviePreviewList> GetPopularMoviesAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets a list of top rated movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of top rated movies.</returns>
        Task<TmdbMoviePreviewList> GetTopRatedMoviesAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets the movie account state of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie account state of the movie with the given ID.</returns>
        Task<TmdbMovieAccountStates> GetMovieAccountStateAsync( Int32 movieId );

        /// <summary>
        ///     Rates the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <param name="rating">The rating of the movie. Value must be x*0.5</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbStatusResponse> RateMovieAsync( Int32 movieId, Double rating );

        /// <summary>
        ///     Gets the basic collection information of the collection with the given ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load.</param>
        /// <param name="appendMethod">Specifies the collection methods which should get appended to the collection method.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D
        /// </remarks>
        /// <returns>The basic collection information of the collection with the given ID.</returns>
        Task<TmdbMovieCollection> GetCollectionAsync( Int32 collectionId, TmdbCollectionMethod appendMethod = TmdbCollectionMethod.None );

        /// <summary>
        ///     Gets all of the images of the collection with the specified ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>All of the images of the collection with the specified ID.</returns>
        Task<TmdbCollectionImages> GetCollectionImagesAsync( Int32 collectionId );

        /// <summary>
        ///     Gets the general information of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load.</param>
        /// <param name="appendMethod">Specifies the person methods which should get appended to the person method.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <returns>The general information of the person with the given ID.</returns>
        Task<TmdbPersonInformation> GetPersonAsync( Int32 personId, TmdbPersonMethod appendMethod = TmdbPersonMethod.None );

        /// <summary>
        ///     Gets the credits of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the credits of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
        /// </remarks>
        /// <returns>The credits of the person with the given ID.</returns>
        Task<TmdbPersonCredits> GetPersonCreditsAsync( Int32 personId );

        /// <summary>
        ///     Gets the images of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The images of the person with the given ID.</returns>
        Task<TmdbPersonImages> GetPersonImageAsync( Int32 personId );

        /// <summary>
        ///     Gets the changes of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the changes of.</param>
        /// <param name="startDate">The start date of the changes.</param>
        /// <param name="endDate">The end date of the changes.</param>
        /// <remarks>
        ///     The maximum number of days that can be returned in a single request is 14.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fchanges
        /// </remarks>
        /// <returns>The changes of the person with the given ID.</returns>
        Task<TmdbChanges> GetPersonChangesAsync( Int32 personId, DateTime? startDate = null, DateTime? endDate = null );

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        Task<TmdbPersonPreviewList> GetPopularPersonsAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets the latest added person.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Flatest
        /// </remarks>
        /// <returns>The latest added person.</returns>
        Task<TmdbPersonInformation> GetLatestPersonAsync();

        /// <summary>
        ///     Gets the list with the specified ID.
        /// </summary>
        /// <param name="listId">The ID of the list to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The list with the specified ID.</returns>
        Task<TmdbMovieList> GetListAsync( String listId );

        /// <summary>
        ///     Gets the list state the movie with the given ID.
        /// </summary>
        /// <param name="listId">The ID of the list to check.</param>
        /// <param name="movieId">The ID of the movie to check the state of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The list state the movie with the given ID.</returns>
        Task<TmdbMovieListStaus> GetListStateAsync( String listId, Int32 movieId );

        /// <summary>
        ///     Creates a new movie list, with the given name, description and language.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
        /// </remarks>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbCreateMovieListResponse> CreateMovieListAsync( TmdbCreateMovieListRequest createMovieListRequest );

        /// <summary>
        ///     Adds the given item to the list with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fadd_item
        /// </remarks>
        /// <param name="listId">The ID of the list to which the item should get added.</param>
        /// <param name="movieId">The Id of the movie to add.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbStatusResponse> AddItemToListAsync( String listId, Int32 movieId );

        /// <summary>
        ///     Removes the given item from the list with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fremove_item
        /// </remarks>
        /// <param name="listId">The ID of the list from which the item should get removed.</param>
        /// <param name="movieId">The Id of the movie to remove.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbStatusResponse> RemoveItemFromListAsync( String listId, Int32 movieId );

        /// <summary>
        ///     Deletes the list with the given ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#delete-%2F3%2Flist%2F%7Bid%7D
        /// </remarks>
        /// <param name="listId">The ID of the list to delete.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbStatusResponse> DeleteListAsync( String listId );

        /// <summary>
        ///     Gets the company with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D
        /// </remarks>
        /// <param name="companyId">The ID of the company to load.</param>
        /// <param name="appendMethod">The methods to append to the response of the company method.</param>
        /// <returns>The company with the specified ID.</returns>
        Task<TmdbCompanyInformation> GetCompanyAsync( Int32 companyId, TmdbCompanyMethod appendMethod = TmdbCompanyMethod.None );

        /// <summary>
        ///     Gets the movies of the company with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="companyId">The ID of the company to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The movies of the company with the specified ID..</returns>
        Task<TmdbMoviePreviewList> GetCompanyMoviesAsync( Int32 companyId, Int32? page = null );

        /// <summary>
        ///     Gets a list of all genres.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2Flist
        /// </remarks>
        /// <returns>A list of all genres.</returns>
        Task<TmdbGenreList> GetGenresAsync();

        /// <summary>
        ///     Gets the movies which are of the given genre.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="genreId">The ID of the genre to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="includeAllMovies">Toggle the inclusion of all movies and not just those with 10 or more ratings.</param>
        /// <returns>The movies which are of the given genre.</returns>
        Task<TmdbMoviePreviewList> GetGenreMoviesAsync( Int32 genreId, Int32? page = null, Boolean? includeAllMovies = null );

        /// <summary>
        ///     Gets the keyword with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fkeyword%2F%7Bid%7D
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to load.</param>
        /// <returns>The keyword with the specified ID.</returns>
        Task<TmdbKeyword> GetKeywordAsync( Int32 keywordId );

        /// <summary>
        ///     Gets the movies which are tagged with the keyword with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fkeyword%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The movies which are tagged with the keyword with the specified ID.</returns>
        Task<TmdbMoviePreviewList> GetKeywordMoviesAsync( Int32 keywordId, Int32? page = null );

        /// <summary>
        ///     Gets the result of the TMDb discovery method, using the specified filters.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <param name="page">The number of the page to load (Minimum is 1).</param>
        /// <param name="filter">The filters to apply to the result.</param>
        /// <returns>The result of the TMDb discovery method, using the specified filters.</returns>
        Task<TmdbMoviePreviewList> DiscoverMoviesAsync( Int32? page = null, DisoveryFilter filter = null );

        /// <summary>
        ///     Gets the movies which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (movie name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="year">Filter the ChangedEntries release dates to matches that include this value.</param>
        /// <param name="primaryReleaseYear">Filter the ChangedEntries so that only the primary release dates have this value.</param>
        /// <returns>The movies which matches the given query and filter.</returns>
        Task<TmdbMoviePreviewList> SearchMovieAsync( String query, Int32? page = null, Int32? year = null, Int32? primaryReleaseYear = null );

        /// <summary>
        ///     Gets the movie collections which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (collection name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The movie collections which matches the given query and filter.</returns>
        Task<TmdbMovieCollectionPreviewList> SearchMovieCollectionAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the people which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (person name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The people which matches the given query and filter.</returns>
        Task<TmdbPersonPreviewList> SearchPersonAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the lists which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (list name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The lists which matches the given query and filter.</returns>
        Task<TmdbMovieListPreviewList> SearchListAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the companies which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (company name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The companies which matches the given query and filter.</returns>
        Task<TmdCompanyPreviewList> SearchCompanyAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the keywords which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fkeyword
        /// </remarks>
        /// <param name="query">The search query (keyword name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The keywords which matches the given query and filter.</returns>
        Task<TmdbKeywords> SearchKeywordAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the review with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Freview%2F%7Bid%7D
        /// </remarks>
        /// <param name="reviewId">The ID of the review to load.</param>
        /// <returns>The review with the specified ID.</returns>
        Task<TmdbReview> GetReviewAsync( String reviewId );

        /// <summary>
        ///     Gets a list of all movies which has changed in the specified time range.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
        /// </remarks>
        /// <param name="startTime">The start of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>A list of all movies which has changed in the specified time range.</returns>
        Task<TmdbChangedEntriesList> GetChangedMoviesAsync( DateTime? startTime = null, DateTime? endTime = null );

        /// <summary>
        ///     Gets a list of all people which has changed in the specified time range.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
        /// </remarks>
        /// <param name="startTime">The start of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>A list of all people which has changed in the specified time range.</returns>
        Task<TmdbChangedEntriesList> GetChangedPeopleAsync( DateTime? startTime = null, DateTime? endTime = null );

        /// <summary>
        ///     Gets a list of departments and jobs.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
        /// </remarks>
        /// <returns>A list of departments and jobs.</returns>
        Task<TmdbDepartments> GetJobsAsync();

        #region Images

        /// <summary>
        ///     Downloads the image at the given path.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="fileName">The file name of the downloaded image.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>The path to the downloaded image.</returns>
        Task<String> DownloadImageAsync( String filePath, String fileName, String size = null );

        /// <summary>
        ///     Gets the image which matches the given parameters.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="fileName">The file name of the downloaded image.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>Gets the data of the image at the specified URL.</returns>
        Task<Byte[]> GetImageAsync( String filePath, String fileName, String size = null );

        /// <summary>
        ///     Gets the URL to the image with the specified size.
        /// </summary>
        /// <param name="filePath">The path to the image file.</param>
        /// <param name="size">The size in which the image should get loaded, or null get it in the original size.</param>
        /// <exception cref="ArgumentOutOfRangeException">Was not able to find the original size in the TMDb tmdbConfiguration.</exception>
        /// <returns>The URL to the image with the specified size.</returns>
        String GetImageUrl( String filePath, String size = null );

        #endregion
    }
}