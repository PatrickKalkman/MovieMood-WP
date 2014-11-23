using System;
using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     Interface representing the TMDb API wrapper.
    /// </summary>
    public interface IApiWrapper
    {
        /// <summary>
        ///     Gets ors sets the client used to call the TMDb API.
        /// </summary>
        /// <value>The client used to call the TMDb API.</value>
        IApiClient ApiClient { get; set; }

        /// <summary>
        ///     Gets or sets the configuration of the TMDb API.
        /// </summary>
        /// <value>The configuration of the TMDb API.</value>
        IApiConfiguration ApiConfiguration { get; set; }

        /// <summary>
        ///     Gets the current TMDb configuration.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#configuration
        /// </remarks>
        /// <returns>The current TMDb configuration.</returns>
        Task<TmdbResult<TmdbConfiguration>> GetConfigurationAsync();

        /// <summary>
        ///     Gets a TMDb authentication authenticationToken.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        ///     Note: The authenticationToken expires after a period of time (check it's ExpiresAt property).
        /// </remarks>
        /// <returns>A new authentication authenticationToken.</returns>
        Task<TmdbResult<TmdbAuthenticationToken>> GetAuthenticationTokenAsync();

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
        Task<TmdbResult<TmdbSession>> GetSessionAsync( String authenticationToken );

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>A new guest session..</returns>
        Task<TmdbResult<TmdbGuestSession>> GetGuestSessionAsync();

        /// <summary>
        ///     Get the basic information about the account to which the session ID belongs.
        /// </summary>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The basic information about the account to which the session ID belongs.</returns>
        Task<TmdbResult<TmdbAccount>> GetAccountAsync( String sessionId );

        /// <summary>
        ///     Get the list of the account with the given ID.
        /// </summary>
        /// <param name="accountId">The ID of the account to load the lists of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The language of the lists to load.</param>
        /// <returns>The list of the account with the given ID.</returns>
        Task<TmdbResult<TmdbMovieListPreviewList>> GetAccountListsAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                         String iso639_1LanguageCode = null );

        /// <summary>
        ///     Marks the movie in the given favorite request as favorite.
        /// </summary>
        /// <param name="accountId">The ID of the account.</param>
        /// <param name="favoriteRequest">A favorite request.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbStatusResponse>> SetFavoriteAsync( Int32 accountId, TmdbFavoriteRequest favoriteRequest, String sessionId );

        /// <summary>
        ///     Adds/removes the movie with the given ID to/from the watch list.
        /// </summary>
        /// <param name="accountId">The ID of the account.</param>
        /// <param name="watchListRequest">A watch list request.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbStatusResponse>> SetWatchListAsync( Int32 accountId, TmdbWatchListRequest watchListRequest, String sessionId );

        /// <summary>
        ///     Gets the list of the favorite movies of the account with the given ID.
        /// </summary>
        /// <param name="accountId">The ID of the account to load the lists of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="sortOrder">The sort order of the ChangedEntries.</param>
        /// <param name="iso639_1LanguageCode">The language of the lists to load.</param>
        /// <param name="sortBy">The sort property of the ChangedEntries.</param>
        /// <returns>The list of the favorite movies of the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite_movies
        /// </remarks>
        Task<TmdbResult<TmdbMoviePreviewList>> GetAccountFavoriteMoviesAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                              TmdbSortBy sortBy = TmdbSortBy.None,
                                                                              TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                              String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the list of the movies rated by the account with the given ID.
        /// </summary>
        /// <param name="accountId">The ID of the account to load the lists of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="sortOrder">The sort order of the ChangedEntries.</param>
        /// <param name="iso639_1LanguageCode">The language of the lists to load.</param>
        /// <param name="sortBy">The sort property of the ChangedEntries.</param>
        /// <returns>The list of the movies rated by the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Frated_movies
        /// </remarks>
        Task<TmdbResult<TmdbMoviePreviewList>> GetAccountRatedMoviesAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                           TmdbSortBy sortBy = TmdbSortBy.None,
                                                                           TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                           String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the watch list of the account with the given ID.
        /// </summary>
        /// <param name="accountId">The ID of the account to load the lists of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="sortOrder">The sort order of the ChangedEntries.</param>
        /// <param name="iso639_1LanguageCode">The language of the lists to load.</param>
        /// <param name="sortBy">The sort property of the ChangedEntries.</param>
        /// <returns>The watch list of the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
        /// </remarks>
        Task<TmdbResult<TmdbMoviePreviewList>> GetAccountWatchListAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                         TmdbSortBy sortBy = TmdbSortBy.None,
                                                                         TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                         String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the movie with the specified ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load.</param>
        /// <param name="appendMethod">Specifies the movie methods which should get appended to the movie method.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the data to return.</param>
        /// <remarks>
        ///     Note: Some of the properties of the returned movie object, may only be set when a specific method is appended to the movie method.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2F%7Bid%7D
        /// </remarks>
        /// <returns>The movie with the given ID.</returns>
        Task<TmdbResult<TmdbMovie>> GetMovieAsync( Int32 movieId, TmdbMovieMethod appendMethod = TmdbMovieMethod.None,
                                                   String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the alternative titles of the movie with the specified ID.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the titles of.</param>
        /// <param name="iso3166_1CountryCode">The ISO 3166-1 country code of the country to load the title of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The alternative titles of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbAlternativeTitles>> GetAlternativeMovieTitlesAsync( Int32 movieId, String iso3166_1CountryCode = null );

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the cast of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>The cast of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbStaff>> GetMovieCastAsync( Int32 movieId );

        /// <summary>
        ///     Gets the images of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the images of.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the images to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The images of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbImages>> GetMovieImagesAsync( Int32 movieId, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the current keywords of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the keywords of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The keywords of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbMovieKeywords>> GetMovieKeywordsAsync( Int32 movieId );

        /// <summary>
        ///     Gets the releases of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the releases of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The releases of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbReleases>> GetMovieReleasesAsync( Int32 movieId );

        /// <summary>
        ///     Gets the trailers of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the trailers of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The trailers of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbTrailers>> GetMovieTrailersAsync( Int32 movieId );

        /// <summary>
        ///     Gets the translations of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the translations of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The translations of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbTranslations>> GetMovieTranslationsAsync( Int32 movieId );

        /// <summary>
        ///     Gets the similar movies of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the similar movies of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the similar movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The similar movies of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetSimilarMoviesAsync( Int32 movieId, Int32? pageNumber = null,
                                                                      String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the reviews of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the reviews to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbMovieReviews>> GetMovieReviewsAsync( Int32 movieId, Int32? pageNumber = null,
                                                                 String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the movie lists of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the movie lists of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movie lists to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie lists of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbMovieLists>> GetMovieListsAsync( Int32 movieId, Int32? pageNumber = null, String iso639_1LanguageCode = null );

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
        Task<TmdbResult<TmdbChanges>> GetMovieChangesAsync( Int32 movieId, DateTime? startDate = null, DateTime? endDate = null );

        /// <summary>
        ///     Gets the latest movie.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The latest movie.</returns>
        Task<TmdbResult<TmdbMovie>> GetLatestMovieAsync();

        /// <summary>
        ///     Gets a list of upcoming movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of the upcoming movies.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetUpcomingMoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets a list of movies playing in theatres.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A  list of movies playing in theatres.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetNowPlayingmoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets a list of popular movies on The Movie Database.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of popular movies on The Movie Database.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetPopularMoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets a list of top rated movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of top rated movies.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetTopRatedMoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the movie account state of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie account state of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbMovieAccountStates>> GetMovieAccountStateAsync( Int32 movieId, String sessionId );

        /// <summary>
        ///     Rates the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <param name="ratingRequest">The RatingRequest (1-10) of the movie.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="guestSessionId">A valid guest session ID.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        ///     Specified only one session ID (
        ///     <paramref name="sessionId"></paramref>
        ///     OR
        ///     <paramref name="guestSessionId"></paramref>
        ///     )
        /// </remarks>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbStatusResponse>> RateMovieAsync( Int32 movieId, TmdbMovieRatingRequest ratingRequest, String sessionId = null,
                                                             String guestSessionId = null );

        /// <summary>
        ///     Gets the basic collection information of the collection with the given ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load.</param>
        /// <param name="appendMethod">Specifies the collection methods which should get appended to the collection method.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the collection to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D
        /// </remarks>
        /// <returns>The basic collection information of the collection with the given ID.</returns>
        Task<TmdbResult<TmdbMovieCollection>> GetCollectionAsync( Int32 collectionId,
                                                                  TmdbCollectionMethod appendMethod = TmdbCollectionMethod.None,
                                                                  String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets all of the images of the collection with the specified ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load the images of.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the images to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>All of the images of the collection with the specified ID.</returns>
        Task<TmdbResult<TmdbCollectionImages>> GetCollectionImagesAsync( Int32 collectionId, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the general information of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load.</param>
        /// <param name="appendMethod">Specifies the person methods which should get appended to the person method.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <returns>The general information of the person with the given ID.</returns>
        Task<TmdbResult<TmdbPersonInformation>> GetPersonAsync( Int32 personId, TmdbPersonMethod appendMethod = TmdbPersonMethod.None );

        /// <summary>
        ///     Gets the credits of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the credits of.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the credits to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
        /// </remarks>
        /// <returns>The credits of the person with the given ID.</returns>
        Task<TmdbResult<TmdbPersonCredits>> GetPersonCreditsAsync( Int32 personId, String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the images of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The images of the person with the given ID.</returns>
        Task<TmdbResult<TmdbPersonImages>> GetPersonImageAsync( Int32 personId );

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
        Task<TmdbResult<TmdbChanges>> GetPersonChangesAsync( Int32 personId, DateTime? startDate = null, DateTime? endDate = null );

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        Task<TmdbResult<TmdbPersonPreviewList>> GetPopularPersonsAsync( Int32? pageNumber = null );

        /// <summary>
        ///     Gets the latest added person.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Flatest
        /// </remarks>
        /// <returns>The latest added person.</returns>
        Task<TmdbResult<TmdbPersonInformation>> GetLatestPersonAsync();

        /// <summary>
        ///     Gets the list with the specified ID.
        /// </summary>
        /// <param name="listId">The ID of the list to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The list with the specified ID.</returns>
        Task<TmdbResult<TmdbMovieList>> GetListAsync( String listId );

        /// <summary>
        ///     Gets the list state the movie with the given ID.
        /// </summary>
        /// <param name="listId">The ID of the list to check.</param>
        /// <param name="movieId">The ID of the movie to check the state of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The list state the movie with the given ID.</returns>
        Task<TmdbResult<TmdbMovieListStaus>> GetListStateAsync( String listId, Int32 movieId );

        /// <summary>
        ///     Creates a new movie list, with the given name, description and language.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
        /// </remarks>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbCreateMovieListResponse>> CreateMovieListAsync( String sessionId,
                                                                            TmdbCreateMovieListRequest createMovieListRequest );

        /// <summary>
        ///     Adds the given item to the list with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fadd_item
        /// </remarks>
        /// <param name="listId">The ID of the list to which the item should get added.</param>
        /// <param name="item">The item to add to the list.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbStatusResponse>> AddItemToListAsync( String listId, TmdbListItemRequest item, String sessionId );

        /// <summary>
        ///     Removes the given item from the list with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fremove_item
        /// </remarks>
        /// <param name="listId">The ID of the list from which the item should get removed.</param>
        /// <param name="item">The item to remove from the list.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbStatusResponse>> RemoveItemFromListAsync( String listId, TmdbListItemRequest item, String sessionId );

        /// <summary>
        ///     Deletes the list with the given ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#delete-%2F3%2Flist%2F%7Bid%7D
        /// </remarks>
        /// <param name="listId">The ID of the list to delete.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        Task<TmdbResult<TmdbStatusResponse>> DeleteListAsync( String listId, String sessionId );

        /// <summary>
        ///     Gets the company with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D
        /// </remarks>
        /// <param name="companyId">The ID of the company to load.</param>
        /// <param name="appendMethod">The methods to append to the response of the company method.</param>
        /// <returns>The company with the specified ID.</returns>
        Task<TmdbResult<TmdbCompanyInformation>> GetCompanyAsync( Int32 companyId, TmdbCompanyMethod appendMethod = TmdbCompanyMethod.None );

        /// <summary>
        ///     Gets the movies of the company with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="companyId">The ID of the company to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to return.</param>
        /// <returns>The movies of the company with the specified ID..</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetCompanyMoviesAsync( Int32 companyId, Int32? page = null,
                                                                      String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets a list of all genres.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2Flist
        /// </remarks>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the genres to load.</param>
        /// <returns>A list of all genres.</returns>
        Task<TmdbResult<TmdbGenreList>> GetGenresAsync( String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the movies which are of the given genre.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="genreId">The ID of the genre to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to return.</param>
        /// <param name="includeAllMovies">Toggle the inclusion of all movies and not just those with 10 or more ratings.</param>
        /// <param name="includeAdult">Toggle the inclusion of adult titles.</param>
        /// <returns>The movies which are of the given genre.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetGenreMoviesAsync( Int32 genreId, Int32? page = null, String iso639_1LanguageCode = null,
                                                                    Boolean? includeAllMovies = null, Boolean? includeAdult = null );

        /// <summary>
        ///     Gets the keyword with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fkeyword%2F%7Bid%7D
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to load.</param>
        /// <returns>The keyword with the specified ID.</returns>
        Task<TmdbResult<TmdbKeyword>> GetKeywordAsync( Int32 keywordId );

        /// <summary>
        ///     Gets the movies which are tagged with the keyword with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fkeyword%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to return.</param>
        /// <returns>The movies which are tagged with the keyword with the specified ID.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> GetKeywordMoviesAsync( Int32 keywordId, Int32? page = null,
                                                                      String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the result of the TMDb discovery method, using the specified filters.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <param name="page">The number of the page to load (Minimum is 1).</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the ChangedEntries to return.</param>
        /// <param name="filter">The filters to apply to the result.</param>
        /// <returns>The result of the TMDb discovery method, using the specified filters.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> DiscoverMoviesAsync( Int32? page = null, String iso639_1LanguageCode = null,
                                                                    DisoveryFilter filter = null );

        /// <summary>
        ///     Gets the movies which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (movie name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to return.</param>
        /// <param name="includeAdult">Toggle the inclusion of adult titles.</param>
        /// <param name="year">Filter the ChangedEntries release dates to matches that include this value.</param>
        /// <param name="primaryReleaseYear">Filter the ChangedEntries so that only the primary release dates have this value.</param>
        /// <param name="searchType">The search used search type, normally the default value is the option you will want.</param>
        /// <returns>The movies which matches the given query and filter.</returns>
        Task<TmdbResult<TmdbMoviePreviewList>> SearchMovieAsync( String query, Int32? page = null, String iso639_1LanguageCode = null,
                                                                 Boolean? includeAdult = null, Int32? year = null,
                                                                 Int32? primaryReleaseYear = null,
                                                                 TmdbSearchType searchType = TmdbSearchType.None );

        /// <summary>
        ///     Gets the movie collections which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (collection name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movie collections to return.</param>
        /// <returns>The movie collections which matches the given query and filter.</returns>
        Task<TmdbResult<TmdbMovieCollectionPreviewList>> SearchMovieCollectionAsync( String query, Int32? page = null,
                                                                                     String iso639_1LanguageCode = null );

        /// <summary>
        ///     Gets the people which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (person name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="includeAdult">Toggle the inclusion of adult actors.</param>
        /// <param name="searchType">The search used search type, normally the default value is the option you will want.</param>
        /// <returns>The people which matches the given query and filter.</returns>
        Task<TmdbResult<TmdbPersonPreviewList>> SearchPersonAsync( String query, Int32? page = null,
                                                                   Boolean? includeAdult = null,
                                                                   TmdbSearchType searchType = TmdbSearchType.None );

        /// <summary>
        ///     Gets the lists which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (list name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <param name="includeAdult">Toggle the inclusion of adult lists.</param>
        /// <returns>The lists which matches the given query and filter.</returns>
        Task<TmdbResult<TmdbMovieListPreviewList>> SearchListAsync( String query, Int32? page = null, Boolean? includeAdult = null );

        /// <summary>
        ///     Gets the companies which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (company name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The companies which matches the given query and filter.</returns>
        Task<TmdbResult<TmdCompanyPreviewList>> SearchCompanyAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the keywords which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fkeyword
        /// </remarks>
        /// <param name="query">The search query (keyword name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The keywords which matches the given query and filter.</returns>
        Task<TmdbResult<TmdbKeywords>> SearchKeywordAsync( String query, Int32? page = null );

        /// <summary>
        ///     Gets the review with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Freview%2F%7Bid%7D
        /// </remarks>
        /// <param name="reviewId">The ID of the review to load.</param>
        /// <returns>The review with the specified ID.</returns>
        Task<TmdbResult<TmdbReview>> GetReviewAsync( String reviewId );

        /// <summary>
        ///     Gets a list of all movies which has changed in the specified time range.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
        /// </remarks>
        /// <param name="startTime">The start of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>A list of all movies which has changed in the specified time range.</returns>
        Task<TmdbResult<TmdbChangedEntriesList>> GetChangedMoviesAsync( DateTime? startTime = null, DateTime? endTime = null );

        /// <summary>
        ///     Gets a list of all people which has changed in the specified time range.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
        /// </remarks>
        /// <param name="startTime">The start of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>A list of all people which has changed in the specified time range.</returns>
        Task<TmdbResult<TmdbChangedEntriesList>> GetChangedPeopleAsync( DateTime? startTime = null, DateTime? endTime = null );

        /// <summary>
        ///     Gets a list of departments and jobs.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
        /// </remarks>
        /// <returns>A list of departments and jobs.</returns>
        Task<TmdbResult<TmdbDepartments>> GetJobsAsync();

        /// <summary>
        ///     Downloads the image at the given path.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="tmdbConfiguration">A valid TMDb configuration.</param>
        /// <param name="fileName">The file name of the downloaded image.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>The path to the downloaded image.</returns>
        Task<TmdbResult<String>> DownloadImageAsync( String filePath, TmdbConfiguration tmdbConfiguration, String fileName,
                                                                  String size = null );

        /// <summary>
        ///     Gets the image which matches the given parameters.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="tmdbConfiguration">A valid TMDb configuration.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>Gets the data of the image at the specified URL.</returns>
        Task<TmdbResult<Byte[]>> GetImageAsync( String filePath, TmdbConfiguration tmdbConfiguration, String size = null );
    
        /// <summary>
        ///     Gets the URL to the image with the specified size.
        /// </summary>
        /// <param name="filePath">The path to the image file.</param>
        /// <param name="tmdbConfiguration">The configuration of the TMDb API.</param>
        /// <param name="size">The size in which the image should get loaded, or null get it in the original size.</param>
        /// <exception cref="ArgumentOutOfRangeException">Was not able to find the original size in the TMDb tmdbConfiguration.</exception>
        /// <returns>The URL to the image with the specified size.</returns>
        String GetImageUrl( String filePath, TmdbConfiguration tmdbConfiguration, String size = null );
    }
}