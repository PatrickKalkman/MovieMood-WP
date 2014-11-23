using System;
using System.Threading;
using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     A high level wrapper for the TMDb API, which internally uses <see cref="IApiWrapper" />.
    /// </summary>
    /// <remarks>
    ///     This class provides the same features as a implementation of <see cref="IApiWrapper" />.
    ///     The difference between the two classes is that <see cref="TmdbAbstraction" /> is a bit easier to use and
    ///     and it takes less code to use it than <see cref="IApiWrapper" />.
    ///     But you lose control compared to <see cref="IApiWrapper" /> when you use <see cref="TmdbAbstraction" />.
    /// </remarks>
    public class TmdbAbstraction : ITmdbAbstraction
    {
        #region Fields

        /// <summary>
        ///     The semaphore used to limit the concurrent connections.
        /// </summary>
        private readonly SemaphoreSlim _semaphore;

        /// <summary>
        ///     Stores the Id of a account.
        /// </summary>
        private Int32? _accountId;

        /// <summary>
        ///     Stores a authentication token.
        /// </summary>
        private String _authenticationToken;

        /// <summary>
        ///     Stores a session ID.
        /// </summary>
        private String _sessionId;

        /// <summary>
        ///     Stores a TMDb configuration.
        /// </summary>
        private TmdbConfiguration _tmdbConfiguration;

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets or sets the sort by value of the account movie lists.
        /// </summary>
        /// <remarks>
        ///     Default is:
        ///     <value>TmdbSortBy.None</value>
        ///     (which means it will use the TMDb default).
        /// </remarks>
        /// <value>The sort by value of the account movie lists.</value>
        public TmdbSortBy AccountMovieListSortBy { get; set; }

        /// <summary>
        ///     Gets or sets the sort order of the account movie lists.
        /// </summary>
        /// <remarks>
        ///     Default is:
        ///     <value>TmdbSortOrder.Unset</value>
        ///     (which means it will use the TMDb default).
        /// </remarks>
        /// <value>The sort order of the account movie lists.</value>
        public TmdbSortOrder AccountMovieListSortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the search type used for searching movies and persons.
        /// </summary>
        /// <remarks>
        ///     Default is:
        ///     <value>TmdbSearchType.None</value>
        ///     (which means it will use the TMDb default).
        /// </remarks>
        /// <value>The search type used for searching movies and persons.</value>
        public TmdbSearchType SearchType { get; set; }

        /// <summary>
        ///     Gets or sets the ISO 639-1 code of the request language.
        /// </summary>
        /// <remarks>
        ///     Default is
        ///     <value>null</value>
        ///     , in this case it will use the TMDb's default which is English.
        /// </remarks>
        /// <value>The ISO 639-1 code of the request language. </value>
        public String Iso639_1LanguageCode { get; set; }

        /// <summary>
        ///     Gets or sets a value determining whether adult movies/actors should get loaded.
        /// </summary>
        /// <remarks>
        ///     Default is
        ///     <value>true</value>
        ///     .
        /// </remarks>
        /// <value>A value determining whether adult movies/actors should get loaded.</value>
        public Boolean IncludeAdultMovies { get; set; }

        /// <summary>
        ///     Gets or sets a value which determines whether this class should throw exceptions if some are occurred during a API call, or if methods will return null values instead.
        /// </summary>
        /// <remarks>
        ///     Default is
        ///     <value>true</value>
        ///     .
        /// </remarks>
        /// <value>A value which determines whether this class should throw exceptions if some are occurred during a API call, or if methods will return null values instead.</value>
        public Boolean ThrowException { get; set; }

        /// <summary>
        ///     Gets or sets the wrapper used to access the TMDb API.
        /// </summary>
        /// <value>The wrapper used to access the TMDb API.</value>
        public IApiWrapper ApiWrapper { get; set; }

        /// <summary>
        ///     Gets or sets the authentication token used for creating a session Id.
        /// </summary>
        /// <value>The authentication token used for creating a session Id.</value>
        public String AuthenticationToken
        {
            get
            {
                if (String.IsNullOrEmpty(_authenticationToken))
                    throw new ArgumentException("Authentication Token is not set, get a valid token first.", "AuthenticationToken");
                return _authenticationToken;
            }
            set { _authenticationToken = value; }
        }

        /// <summary>
        ///     Gets or sets the session ID used for account related calls.
        /// </summary>
        /// <value>The session ID used for account related calls.</value>
        public String SessionId
        {
            get
            {
                if ( String.IsNullOrEmpty( _sessionId ) )
                    throw new ArgumentException( "Session Id is not set, get a valid session ID first.", "SessionId" );
                return _sessionId;
            }
            set { _sessionId = value; }
        }

        /// <summary>
        ///     Gets or sets the configuration load from the TMDb API.
        /// </summary>
        /// <value>The configuration load from the TMDb API.</value>
        public TmdbConfiguration TmdbConfiguration
        {
            get
            {
                if ( _tmdbConfiguration == null )
                    throw new ArgumentException( "TMDb configuration is not set, load configuration first.", "TmdbConfiguration" );
                return _tmdbConfiguration;
            }
            set { _tmdbConfiguration = value; }
        }

        /// <summary>
        ///     Gets or sets the session ID used for account related calls.
        /// </summary>
        /// <value>The session ID used for account related calls.</value>
        public Int32 AccountId
        {
            get
            {
                if ( _accountId == null )
                    throw new ArgumentException( "Account Id is not set, load account first.", "AccountId" );
                return ( Int32 ) _accountId;
            }
            set { _accountId = value; }
        }

        #endregion Properties

        #region Ctor

        /// <summary>
        ///     Initialize a new instance of the <see cref="TmdbAbstraction" /> class.
        /// </summary>
        /// <remarks>
        ///     It's not possible to create a new instance of <see cref="IApiWrapper" />, because of some code is platform specific.
        ///     Details: <see cref="IApiClient" />.
        /// </remarks>
        /// <param name="apiWrapper">The API wrapper used to perform API calls.</param>
        /// <param name="maxConcurrentConnections">The maximum number of concurrent connections. Default is 30</param>
        public TmdbAbstraction( IApiWrapper apiWrapper, Int32 maxConcurrentConnections = 30 )
        {
            if ( maxConcurrentConnections < 1 )
                throw new ArgumentException( "The maximum number of concurrent connections must be grater or equals 1.", "maxConcurrentConnections" );

            ApiWrapper = apiWrapper;
            IncludeAdultMovies = true;
            ThrowException = true;
            AccountMovieListSortBy = TmdbSortBy.None;
            AccountMovieListSortOrder = TmdbSortOrder.Unset;
            SearchType = TmdbSearchType.None;

            _semaphore = new SemaphoreSlim( maxConcurrentConnections, maxConcurrentConnections );
        }

        #endregion Ctor

        #region Configuration

        /// <summary>
        ///     Gets the current TMDb configuration.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#configuration
        /// </remarks>
        /// <returns>The current TMDb configuration.</returns>
        public async Task<TmdbConfiguration> GetConfigurationAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetConfigurationAsync();
                TmdbConfiguration config;

                if ( ThrowException )
                {
                    config = result.UnwrapOrThrow();
                    TmdbConfiguration = config;
                }
                else
                {
                    config = result.Unwrap();
                    if ( config != null )
                        TmdbConfiguration = config;
                }
                return config;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Configuration

        #region Authentication

        /// <summary>
        ///     Gets a TMDb authentication authenticationToken.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        ///     Note: The authenticationToken expires after a period of time (check it's ExpiresAt property).
        /// </remarks>
        /// <returns>A new authentication authenticationToken.</returns>
        public async Task<TmdbAuthenticationToken> GetAuthenticationTokenAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetAuthenticationTokenAsync();
                TmdbAuthenticationToken token;

                if (ThrowException)
                {
                    token = result.UnwrapOrThrow();
                    AuthenticationToken = token.Token;
                }
                else
                {
                    token = result.Unwrap();
                    if (token != null)
                        AuthenticationToken = token.Token;
                }
                return token;
            }
            finally
            {
                _semaphore.Release();
            }
        }

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
        public async Task<TmdbSession> GetSessionAsync( String authenticationToken = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetSessionAsync(authenticationToken ?? AuthenticationToken);
                TmdbSession session;

                if (ThrowException)
                {
                    session = result.UnwrapOrThrow();
                    SessionId = session.SessionId;
                }
                else
                {
                    session = result.Unwrap();
                    if (session != null)
                        SessionId = session.SessionId;
                }
                return session;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>A new guest session..</returns>
        public async Task<TmdbGuestSession> GetGuestSessionAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetGuestSessionAsync();
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #region Aditional

        /// <summary>
        ///     Gets a valid session Id in one step, note that the user has to accept the token in the callback.
        /// </summary>
        /// <param name="userAceptTokenCallback">A callback in which the user has to accept the authentication token. (Return true means that the user has accepted the token).</param>
        /// <returns>A valid session ID, or null if the user has not accepted the token.</returns>
        public async Task<TmdbSession> GetSessionWithoutAuthenticationTokenAsync( Func<TmdbAuthenticationToken, Boolean> userAceptTokenCallback )
        {
            try
            {
                await _semaphore.WaitAsync();

                if ( userAceptTokenCallback == null )
                    throw new ArgumentNullException( "userAceptTokenCallback", "Callback can not be null." );

                var token = await GetAuthenticationTokenAsync();
                if ( userAceptTokenCallback( token ) )
                    return await GetSessionAsync( token.Token );
                return null;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Aditional

        #endregion Authentication

        #region Account

        /// <summary>
        ///     Get the basic information about the account to which the session ID belongs.
        /// </summary>
        /// <returns>The basic information about the account to which the session ID belongs.</returns>
        public async Task<TmdbAccount> GetAccountAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetAccountAsync( SessionId );
                TmdbAccount account;

                if ( ThrowException )
                {
                    account = result.UnwrapOrThrow();
                    AccountId = account.Id;
                }
                else
                {
                    account = result.Unwrap();
                    if ( account != null )
                        AccountId = account.Id;
                }
                return account;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Get the list of the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The list of the account with the given ID.</returns>
        public async Task<TmdbMovieListPreviewList> GetAccountListsAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetAccountListsAsync( AccountId, SessionId, pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Marks the movie in the given favorite request as favorite.
        /// </summary>
        /// <param name="favoriteRequest">A favorite request.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbStatusResponse> SetFavoriteAsync( TmdbFavoriteRequest favoriteRequest )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SetFavoriteAsync( AccountId, favoriteRequest, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Adds/removes the movie with the given ID to/from the watch list.
        /// </summary>
        /// <param name="watchListRequest">A watch list request.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbStatusResponse> SetWatchListAsync( TmdbWatchListRequest watchListRequest )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SetWatchListAsync( AccountId, watchListRequest, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the list of the favorite movies of the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The list of the favorite movies of the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Ffavorite_movies
        /// </remarks>
        public async Task<TmdbMoviePreviewList> GetAccountFavoriteMoviesAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result =
                    await
                    ApiWrapper.GetAccountFavoriteMoviesAsync( AccountId, SessionId, pageNumber, AccountMovieListSortBy, AccountMovieListSortOrder,
                                                              Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the list of the movies rated by the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The list of the movies rated by the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Frated_movies
        /// </remarks>
        public async Task<TmdbMoviePreviewList> GetAccountRatedMoviesAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result =
                    await
                    ApiWrapper.GetAccountRatedMoviesAsync( AccountId, SessionId, pageNumber, AccountMovieListSortBy, AccountMovieListSortOrder,
                                                           Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the watch list of the account with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <returns>The watch list of the account with the given ID.</returns>
        /// <remarks>
        ///     Note: Currently only <see cref="TmdbSortBy.CreatedAt" /> is supported as sort by parameter.
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Faccount%2F%7Bid%7D%2Fmovie_watchlist
        /// </remarks>
        public async Task<TmdbMoviePreviewList> GetAccountWatchListAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result =
                    await
                    ApiWrapper.GetAccountWatchListAsync( AccountId, SessionId, pageNumber, AccountMovieListSortBy, AccountMovieListSortOrder,
                                                         Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Account

        #region Movie

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
        public async Task<TmdbMovie> GetMovieAsync( Int32 movieId, TmdbMovieMethod appendMethod = TmdbMovieMethod.None )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieAsync( movieId, appendMethod, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the alternative titles of the movie with the specified ID.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the titles of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The alternative titles of the movie with the given ID.</returns>
        public async Task<TmdbAlternativeTitles> GetAlternativeMovieTitlesAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetAlternativeMovieTitlesAsync( movieId, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the cast of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>The cast of the movie with the given ID.</returns>
        public async Task<TmdbStaff> GetMovieCastAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieCastAsync( movieId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the images of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The images of the movie with the given ID.</returns>
        public async Task<TmdbImages> GetMovieImagesAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieImagesAsync( movieId, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the current keywords of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the keywords of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The keywords of the movie with the given ID.</returns>
        public async Task<TmdbMovieKeywords> GetMovieKeywordsAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieKeywordsAsync( movieId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the releases of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the releases of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The releases of the movie with the given ID.</returns>
        public async Task<TmdbReleases> GetMovieReleasesAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieReleasesAsync( movieId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the trailers of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the trailers of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The trailers of the movie with the given ID.</returns>
        public async Task<TmdbTrailers> GetMovieTrailersAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieTrailersAsync( movieId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the translations of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the translations of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The translations of the movie with the given ID.</returns>
        public async Task<TmdbTranslations> GetMovieTranslationsAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieTranslationsAsync( movieId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the similar movies of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the similar movies of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The similar movies of the movie with the given ID.</returns>
        public async Task<TmdbMoviePreviewList> GetSimilarMoviesAsync( Int32 movieId, Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetSimilarMoviesAsync( movieId, pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the reviews of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        public async Task<TmdbMovieReviews> GetMovieReviewsAsync( Int32 movieId, Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieReviewsAsync( movieId, pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the movie lists of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the movie lists of.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie lists of the movie with the given ID.</returns>
        public async Task<TmdbMovieLists> GetMovieListsAsync( Int32 movieId, Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieListsAsync( movieId, pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

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
        public async Task<TmdbChanges> GetMovieChangesAsync( Int32 movieId, DateTime? startDate = null, DateTime? endDate = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieChangesAsync( movieId, startDate, endDate );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the latest movie.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The latest movie.</returns>
        public async Task<TmdbMovie> GetLatestMovieAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetLatestMovieAsync();
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a list of upcoming movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of the upcoming movies.</returns>
        public async Task<TmdbMoviePreviewList> GetUpcomingMoviesAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetUpcomingMoviesAsync( pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a list of movies playing in theatres.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A  list of movies playing in theatres.</returns>
        public async Task<TmdbMoviePreviewList> GetNowPlayingmoviesAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetNowPlayingmoviesAsync( pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a list of popular movies on The Movie Database.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of popular movies on The Movie Database.</returns>
        public async Task<TmdbMoviePreviewList> GetPopularMoviesAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetPopularMoviesAsync( pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a list of top rated movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of top rated movies.</returns>
        public async Task<TmdbMoviePreviewList> GetTopRatedMoviesAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetTopRatedMoviesAsync( pageNumber, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the movie account state of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie account state of the movie with the given ID.</returns>
        public async Task<TmdbMovieAccountStates> GetMovieAccountStateAsync( Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetMovieAccountStateAsync( movieId, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Rates the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <param name="rating">The rating of the movie. Value must be x*0.5</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbStatusResponse> RateMovieAsync( Int32 movieId, Double rating )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.RateMovieAsync( movieId, new TmdbMovieRatingRequest
                    {
                        Value = rating
                    }, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Movie

        #region Collection

        /// <summary>
        ///     Gets the basic collection information of the collection with the given ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load.</param>
        /// <param name="appendMethod">Specifies the collection methods which should get appended to the collection method.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D
        /// </remarks>
        /// <returns>The basic collection information of the collection with the given ID.</returns>
        public async Task<TmdbMovieCollection> GetCollectionAsync( Int32 collectionId, TmdbCollectionMethod appendMethod = TmdbCollectionMethod.None )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetCollectionAsync( collectionId, appendMethod, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets all of the images of the collection with the specified ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>All of the images of the collection with the specified ID.</returns>
        public async Task<TmdbCollectionImages> GetCollectionImagesAsync( Int32 collectionId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetCollectionImagesAsync( collectionId, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Collection

        #region People

        /// <summary>
        ///     Gets the general information of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load.</param>
        /// <param name="appendMethod">Specifies the person methods which should get appended to the person method.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D
        /// </remarks>
        /// <returns>The general information of the person with the given ID.</returns>
        public async Task<TmdbPersonInformation> GetPersonAsync( Int32 personId, TmdbPersonMethod appendMethod = TmdbPersonMethod.None )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetPersonAsync( personId, appendMethod );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the credits of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the credits of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
        /// </remarks>
        /// <returns>The credits of the person with the given ID.</returns>
        public async Task<TmdbPersonCredits> GetPersonCreditsAsync( Int32 personId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetPersonCreditsAsync( personId, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the images of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The images of the person with the given ID.</returns>
        public async Task<TmdbPersonImages> GetPersonImageAsync( Int32 personId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetPersonImageAsync( personId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

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
        public async Task<TmdbChanges> GetPersonChangesAsync( Int32 personId, DateTime? startDate = null, DateTime? endDate = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetPersonChangesAsync( personId, startDate, endDate );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        public async Task<TmdbPersonPreviewList> GetPopularPersonsAsync( Int32? pageNumber = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetPopularPersonsAsync( pageNumber );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the latest added person.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Flatest
        /// </remarks>
        /// <returns>The latest added person.</returns>
        public async Task<TmdbPersonInformation> GetLatestPersonAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetLatestPersonAsync();
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion People

        #region Lists

        /// <summary>
        ///     Gets the list with the specified ID.
        /// </summary>
        /// <param name="listId">The ID of the list to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The list with the specified ID.</returns>
        public async Task<TmdbMovieList> GetListAsync( String listId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetListAsync( listId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the list state the movie with the given ID.
        /// </summary>
        /// <param name="listId">The ID of the list to check.</param>
        /// <param name="movieId">The ID of the movie to check the state of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The list state the movie with the given ID.</returns>
        public async Task<TmdbMovieListStaus> GetListStateAsync( String listId, Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetListStateAsync( listId, movieId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Creates a new movie list, with the given name, description and language.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
        /// </remarks>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbCreateMovieListResponse> CreateMovieListAsync( TmdbCreateMovieListRequest createMovieListRequest )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.CreateMovieListAsync( SessionId, createMovieListRequest );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Adds the given item to the list with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fadd_item
        /// </remarks>
        /// <param name="listId">The ID of the list to which the item should get added.</param>
        /// <param name="movieId">The Id of the movie to add.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbStatusResponse> AddItemToListAsync( String listId, Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.AddItemToListAsync( listId, new TmdbListItemRequest
                    {
                        MovieId = movieId
                    }, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Removes the given item from the list with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist%2F%7Bid%7D%2Fremove_item
        /// </remarks>
        /// <param name="listId">The ID of the list from which the item should get removed.</param>
        /// <param name="movieId">The Id of the movie to remove.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbStatusResponse> RemoveItemFromListAsync( String listId, Int32 movieId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.RemoveItemFromListAsync( listId, new TmdbListItemRequest
                    {
                        MovieId = movieId
                    }, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Deletes the list with the given ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#delete-%2F3%2Flist%2F%7Bid%7D
        /// </remarks>
        /// <param name="listId">The ID of the list to delete.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbStatusResponse> DeleteListAsync( String listId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.DeleteListAsync( listId, SessionId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Lists

        #region Companies

        /// <summary>
        ///     Gets the company with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D
        /// </remarks>
        /// <param name="companyId">The ID of the company to load.</param>
        /// <param name="appendMethod">The methods to append to the response of the company method.</param>
        /// <returns>The company with the specified ID.</returns>
        public async Task<TmdbCompanyInformation> GetCompanyAsync( Int32 companyId, TmdbCompanyMethod appendMethod = TmdbCompanyMethod.None )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetCompanyAsync( companyId, appendMethod );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the movies of the company with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcompany%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="companyId">The ID of the company to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The movies of the company with the specified ID..</returns>
        public async Task<TmdbMoviePreviewList> GetCompanyMoviesAsync( Int32 companyId, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetCompanyMoviesAsync( companyId, page, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Companies

        #region Genres

        /// <summary>
        ///     Gets a list of all genres.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2Flist
        /// </remarks>
        /// <returns>A list of all genres.</returns>
        public async Task<TmdbGenreList> GetGenresAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetGenresAsync( Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

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
        public async Task<TmdbMoviePreviewList> GetGenreMoviesAsync( Int32 genreId, Int32? page = null, Boolean? includeAllMovies = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetGenreMoviesAsync( genreId, page, Iso639_1LanguageCode, includeAllMovies, IncludeAdultMovies );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Genres

        #region Keywords

        /// <summary>
        ///     Gets the keyword with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fkeyword%2F%7Bid%7D
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to load.</param>
        /// <returns>The keyword with the specified ID.</returns>
        public async Task<TmdbKeyword> GetKeywordAsync( Int32 keywordId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetKeywordAsync( keywordId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the movies which are tagged with the keyword with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fkeyword%2F%7Bid%7D%2Fmovies
        /// </remarks>
        /// <param name="keywordId">The ID of the keyword to load the movies of.</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The movies which are tagged with the keyword with the specified ID.</returns>
        public async Task<TmdbMoviePreviewList> GetKeywordMoviesAsync( Int32 keywordId, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetKeywordMoviesAsync( keywordId, page, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Keywords

        #region Discover

        /// <summary>
        ///     Gets the result of the TMDb discovery method, using the specified filters.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fdiscover%2Fmovie
        /// </remarks>
        /// <param name="page">The number of the page to load (Minimum is 1).</param>
        /// <param name="filter">The filters to apply to the result.</param>
        /// <returns>The result of the TMDb discovery method, using the specified filters.</returns>
        public async Task<TmdbMoviePreviewList> DiscoverMoviesAsync( Int32? page = null, DisoveryFilter filter = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.DiscoverMoviesAsync( page, Iso639_1LanguageCode, filter );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Discover

        #region Search

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
        public async Task<TmdbMoviePreviewList> SearchMovieAsync( String query, Int32? page = null, Int32? year = null,
                                                                  Int32? primaryReleaseYear = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result =
                    await ApiWrapper.SearchMovieAsync( query, page, Iso639_1LanguageCode, IncludeAdultMovies, year, primaryReleaseYear, SearchType );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the movie collections which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (collection name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The movie collections which matches the given query and filter.</returns>
        public async Task<TmdbMovieCollectionPreviewList> SearchMovieCollectionAsync( String query, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SearchMovieCollectionAsync( query, page, Iso639_1LanguageCode );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the people which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (person name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The people which matches the given query and filter.</returns>
        public async Task<TmdbPersonPreviewList> SearchPersonAsync( String query, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SearchPersonAsync( query, page, IncludeAdultMovies, SearchType );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the lists which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (list name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The lists which matches the given query and filter.</returns>
        public async Task<TmdbMovieListPreviewList> SearchListAsync( String query, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SearchListAsync( query, page, IncludeAdultMovies );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the companies which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fmovie
        /// </remarks>
        /// <param name="query">The search query (company name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The companies which matches the given query and filter.</returns>
        public async Task<TmdCompanyPreviewList> SearchCompanyAsync( String query, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SearchCompanyAsync( query, page );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the keywords which matches the given query and filter.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fsearch%2Fkeyword
        /// </remarks>
        /// <param name="query">The search query (keyword name).</param>
        /// <param name="page">The number of the page to load.</param>
        /// <returns>The keywords which matches the given query and filter.</returns>
        public async Task<TmdbKeywords> SearchKeywordAsync( String query, Int32? page = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.SearchKeywordAsync( query, page );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Search

        #region Review

        /// <summary>
        ///     Gets the review with the specified ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Freview%2F%7Bid%7D
        /// </remarks>
        /// <param name="reviewId">The ID of the review to load.</param>
        /// <returns>The review with the specified ID.</returns>
        public async Task<TmdbReview> GetReviewAsync( String reviewId )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetReviewAsync( reviewId );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Review

        #region Changes

        /// <summary>
        ///     Gets a list of all movies which has changed in the specified time range.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fmovie%2Fchanges
        /// </remarks>
        /// <param name="startTime">The start of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>A list of all movies which has changed in the specified time range.</returns>
        public async Task<TmdbChangedEntriesList> GetChangedMoviesAsync( DateTime? startTime = null, DateTime? endTime = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetChangedMoviesAsync( startTime, endTime );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets a list of all people which has changed in the specified time range.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Fchanges
        /// </remarks>
        /// <param name="startTime">The start of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>A list of all people which has changed in the specified time range.</returns>
        public async Task<TmdbChangedEntriesList> GetChangedPeopleAsync( DateTime? startTime = null, DateTime? endTime = null )
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetChangedPeopleAsync( startTime, endTime );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Changes

        #region Jobs

        /// <summary>
        ///     Gets a list of departments and jobs.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fjob%2Flist
        /// </remarks>
        /// <returns>A list of departments and jobs.</returns>
        public async Task<TmdbDepartments> GetJobsAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetJobsAsync();
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion Jobs

        #region Images

        /// <summary>
        ///     Downloads the image at the given path.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="fileName">The file name of the downloaded image.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>The path to the downloaded image.</returns>
        public async Task<String> DownloadImageAsync(String filePath, String fileName, String size = null)
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.DownloadImageAsync( filePath, TmdbConfiguration, fileName, size );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the image which matches the given parameters.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="fileName">The file name of the downloaded image.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>Gets the data of the image at the specified URL.</returns>
        public async Task<Byte[]> GetImageAsync(String filePath, String fileName, String size = null)
        {
            try
            {
                await _semaphore.WaitAsync();

                var result = await ApiWrapper.GetImageAsync( filePath, TmdbConfiguration, size );
                return ThrowException ? result.UnwrapOrThrow() : result.Unwrap();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        ///     Gets the URL to the image with the specified size.
        /// </summary>
        /// <param name="filePath">The path to the image file.</param>
        /// <param name="size">The size in which the image should get loaded, or null get it in the original size.</param>
        /// <exception cref="ArgumentOutOfRangeException">Was not able to find the original size in the TMDb tmdbConfiguration.</exception>
        /// <returns>The URL to the image with the specified size.</returns>
        public String GetImageUrl(String filePath, String size = null)
        {
            try
            {
                return ApiWrapper.GetImageUrl( filePath, TmdbConfiguration, size );
            }
            catch 
            {
                if ( ThrowException )
                    throw;
                return null;
            }
        }

        #endregion
    }
}