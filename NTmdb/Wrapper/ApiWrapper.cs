using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTmdb
{
    /// <summary>
    ///     Class wrapping the TMDb API for .Net applications.
    /// </summary>
    public class ApiWrapper : IApiWrapper
    {
        #region Properties

        /// <summary>
        ///     Gets ors sets the client used to call the TMDb API.
        /// </summary>
        /// <value>The client used to call the TMDb API.</value>
        public IApiClient ApiClient { get; set; }

        /// <summary>
        ///     Gets or sets the configuration of the TMDb API.
        /// </summary>
        /// <value>The configuration of the TMDb API.</value>
        public IApiConfiguration ApiConfiguration { get; set; }

        #endregion Properties

        #region Configuration

        /// <summary>
        ///     Gets the current TMDb configuration.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#configuration
        /// </remarks>
        /// <returns>The current TMDb configuration.</returns>
        public async Task<TmdbResult<TmdbConfiguration>> GetConfigurationAsync()
        {
            return await PerformApiCall<TmdbConfiguration>( GetApiUrl( ApiConfiguration.ConfigurationMethodName ) );
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
        public async Task<TmdbResult<TmdbAuthenticationToken>> GetAuthenticationTokenAsync()
        {
            return
                await
                PerformApiCall<TmdbAuthenticationToken>( GetApiUrl( ApiConfiguration.NewAuthenticationTokenMethodName ) );
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
        public async Task<TmdbResult<TmdbSession>> GetSessionAsync( String authenticationToken )
        {
            return
                await
                PerformApiCall<TmdbSession>( GetApiUrl( ApiConfiguration.NewSessionMethodName,
                                                        new Dictionary<String, String>
                                                            {
                                                                {
                                                                    ApiConfiguration.AuthenticationTokenParameterName, authenticationToken
                                                                }
                                                            } ) );
        }

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>A new guest session..</returns>
        public async Task<TmdbResult<TmdbGuestSession>> GetGuestSessionAsync()
        {
            return await PerformApiCall<TmdbGuestSession>( GetApiUrl( ApiConfiguration.NewGuestSessionMethodName ) );
        }

        #endregion Authentication

        #region Account

        /// <summary>
        ///     Get the basic information about the account to which the session ID belongs.
        /// </summary>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The basic information about the account to which the session ID belongs.</returns>
        public async Task<TmdbResult<TmdbAccount>> GetAccountAsync( String sessionId )
        {
            return
                await
                PerformApiCall<TmdbAccount>( GetApiUrl( ApiConfiguration.AccountMethodName, new Dictionary<String, String>
                    {
                        {
                            ApiConfiguration.SessionIdParameterName, sessionId
                        }
                    } ) );
        }

        /// <summary>
        ///     Get the list of the account with the given ID.
        /// </summary>
        /// <param name="accountId">The ID of the account to load the lists of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The language of the lists to load.</param>
        /// <returns>The list of the account with the given ID.</returns>
        public async Task<TmdbResult<TmdbMovieListPreviewList>> GetAccountListsAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                                      String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.SessionIdParameterName, sessionId
                    }
                };

            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbMovieListPreviewList>( GetApiUrl( String.Format( ApiConfiguration.AccountListsMethodName, accountId ), parmeters ) );
        }

        /// <summary>
        ///     Marks the movie in the given favorite request as favorite.
        /// </summary>
        /// <param name="accountId">The ID of the account.</param>
        /// <param name="favoriteRequest">A favorite request.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbResult<TmdbStatusResponse>> SetFavoriteAsync( Int32 accountId, TmdbFavoriteRequest favoriteRequest, String sessionId )
        {
            return
                await
                PerformApiCall<TmdbStatusResponse>(
                    GetApiUrl( String.Format( ApiConfiguration.AccountAddFavoriteMethodName, accountId ), new Dictionary<String, String>
                        {
                            {
                                ApiConfiguration.SessionIdParameterName, sessionId
                            }
                        } ), favoriteRequest );
        }

        /// <summary>
        ///     Adds/removes the movie with the given ID to/from the watch list.
        /// </summary>
        /// <param name="accountId">The ID of the account.</param>
        /// <param name="watchListRequest">A watch list request.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbResult<TmdbStatusResponse>> SetWatchListAsync( Int32 accountId, TmdbWatchListRequest watchListRequest, String sessionId )
        {
            return
                await
                PerformApiCall<TmdbStatusResponse>(
                    GetApiUrl( String.Format( ApiConfiguration.AccountEditWatchListMethodName, accountId ), new Dictionary<String, String>
                        {
                            {
                                ApiConfiguration.SessionIdParameterName, sessionId
                            }
                        } ), watchListRequest );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetAccountFavoriteMoviesAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                                           TmdbSortBy sortBy = TmdbSortBy.None,
                                                                                           TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                                           String iso639_1LanguageCode = null )
        {
            return
                await
                GetAccountMovieListAsync( ApiConfiguration.AccountFavoriteMoviesMethodName, accountId, sessionId, pageNumber, sortBy, sortOrder,
                                          iso639_1LanguageCode );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetAccountRatedMoviesAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                                        TmdbSortBy sortBy = TmdbSortBy.None,
                                                                                        TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                                        String iso639_1LanguageCode = null )
        {
            return
                await
                GetAccountMovieListAsync( ApiConfiguration.AccountRatedMoviesMethodName, accountId, sessionId, pageNumber, sortBy, sortOrder,
                                          iso639_1LanguageCode );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetAccountWatchListAsync( Int32 accountId, String sessionId, Int32? pageNumber = null,
                                                                                      TmdbSortBy sortBy = TmdbSortBy.None,
                                                                                      TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                                      String iso639_1LanguageCode = null )
        {
            return
                await
                GetAccountMovieListAsync( ApiConfiguration.AccountWatchListMethodName, accountId, sessionId, pageNumber, sortBy, sortOrder,
                                          iso639_1LanguageCode );
        }

        /// <summary>
        ///     Gets a movie list from an account.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="accountId">The ID of the account to load the list of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="sortOrder">The sort order of the ChangedEntries.</param>
        /// <param name="iso639_1LanguageCode">The language of the lists to load.</param>
        /// <param name="sortBy">The sort property of the ChangedEntries.</param>
        /// <returns></returns>
        private async Task<TmdbResult<TmdbMoviePreviewList>> GetAccountMovieListAsync( String methodName, Int32 accountId, String sessionId,
                                                                                       Int32? pageNumber = null, TmdbSortBy sortBy = TmdbSortBy.None,
                                                                                       TmdbSortOrder sortOrder = TmdbSortOrder.Unset,
                                                                                       String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.SessionIdParameterName, sessionId
                    }
                };

            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );
            if ( sortBy != TmdbSortBy.None )
                parmeters.Add( ApiConfiguration.SortByParameterName, sortBy.ToTmdbParameter( ApiConfiguration ) );
            if ( sortOrder != TmdbSortOrder.Unset )
                parmeters.Add( ApiConfiguration.SortOrderParameterName, sortOrder.ToTmdbParameter( ApiConfiguration ) );

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( String.Format( methodName, accountId ), parmeters ) );
        }

        #endregion Account

        #region Movie

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
        public async Task<TmdbResult<TmdbMovie>> GetMovieAsync( Int32 movieId, TmdbMovieMethod appendMethod = TmdbMovieMethod.None,
                                                                String iso639_1LanguageCode = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );
            if ( appendMethod != TmdbMovieMethod.None )
                parameters.Add( ApiConfiguration.AddToResponseParameterName, appendMethod.ToTmdbParameter( ApiConfiguration ) );

            return await PerformApiCall<TmdbMovie>( GetApiUrl( String.Format( ApiConfiguration.GetMovieMethodName, movieId ), parameters ) );
        }

        /// <summary>
        ///     Gets the alternative titles of the movie with the specified ID.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the titles of.</param>
        /// <param name="iso3166_1CountryCode">The ISO 3166-1 country code of the country to load the title of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The alternative titles of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbAlternativeTitles>> GetAlternativeMovieTitlesAsync( Int32 movieId, String iso3166_1CountryCode = null )
        {
            return
                await PerformApiCall<TmdbAlternativeTitles>( GetApiUrl( String.Format( ApiConfiguration.MovieAlternativeTitlesMethodName, movieId ),
                                                                        iso3166_1CountryCode == null
                                                                            ? null
                                                                            : new Dictionary<String, String>
                                                                                {
                                                                                    {
                                                                                        ApiConfiguration.CountryParameterName,
                                                                                        iso3166_1CountryCode
                                                                                    }
                                                                                } ) );
        }

        /// <summary>
        ///     Gets a TMDb guest session.
        /// </summary>
        /// <param name="movieId">The Id of the movie to load the cast of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#authentication
        /// </remarks>
        /// <returns>The cast of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbStaff>> GetMovieCastAsync( Int32 movieId )
        {
            return await PerformApiCall<TmdbStaff>( GetApiUrl( String.Format( ApiConfiguration.MovieCastMethodName, movieId ) ) );
        }

        /// <summary>
        ///     Gets the images of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the images of.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the images to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The images of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbImages>> GetMovieImagesAsync( Int32 movieId, String iso639_1LanguageCode = null )
        {
            return
                await
                PerformApiCall<TmdbImages>( GetApiUrl( String.Format( ApiConfiguration.ImagesMethodName, movieId ),
                                                       iso639_1LanguageCode == null
                                                           ? null
                                                           : new Dictionary<String, String>
                                                               {
                                                                   {
                                                                       ApiConfiguration.LanguageParameterName, iso639_1LanguageCode
                                                                   }
                                                               } ) );
        }

        /// <summary>
        ///     Gets the current keywords of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the keywords of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The keywords of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbMovieKeywords>> GetMovieKeywordsAsync( Int32 movieId )
        {
            return await PerformApiCall<TmdbMovieKeywords>( GetApiUrl( String.Format( ApiConfiguration.MovieKeywordsMethodName, movieId ) ) );
        }

        /// <summary>
        ///     Gets the releases of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the releases of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The releases of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbReleases>> GetMovieReleasesAsync( Int32 movieId )
        {
            return await PerformApiCall<TmdbReleases>( GetApiUrl( String.Format( ApiConfiguration.MovieReleasesMethodName, movieId ) ) );
        }

        /// <summary>
        ///     Gets the trailers of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the trailers of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The trailers of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbTrailers>> GetMovieTrailersAsync( Int32 movieId )
        {
            return await PerformApiCall<TmdbTrailers>( GetApiUrl( String.Format( ApiConfiguration.MovieTrailersMethodName, movieId ) ) );
        }

        /// <summary>
        ///     Gets the translations of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the translations of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The translations of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbTranslations>> GetMovieTranslationsAsync( Int32 movieId )
        {
            return await PerformApiCall<TmdbTranslations>( GetApiUrl( String.Format( ApiConfiguration.MovieTranslationsMethodName, movieId ) ) );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetSimilarMoviesAsync( Int32 movieId, Int32? pageNumber = null,
                                                                                   String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( String.Format( ApiConfiguration.SimilarMoviesMethodName, movieId ), parmeters ) );
        }

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
        public async Task<TmdbResult<TmdbMovieReviews>> GetMovieReviewsAsync( Int32 movieId, Int32? pageNumber = null,
                                                                              String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbMovieReviews>( GetApiUrl( String.Format( ApiConfiguration.MovieReviewsMethodName, movieId ), parmeters ) );
        }

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
        public async Task<TmdbResult<TmdbMovieLists>> GetMovieListsAsync( Int32 movieId, Int32? pageNumber = null, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbMovieLists>( GetApiUrl( String.Format( ApiConfiguration.MovieListsMethodName, movieId ), parmeters ) );
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
        public async Task<TmdbResult<TmdbChanges>> GetMovieChangesAsync( Int32 movieId, DateTime? startDate = null, DateTime? endDate = null )
        {
            var parmeters = new Dictionary<String, String>();

            if ( startDate != null )
                parmeters.Add( ApiConfiguration.StartDateParameterName, ( ( DateTime ) startDate ).ToString( ApiConfiguration.JsonDatePattern ) );
            if ( endDate != null )
                parmeters.Add( ApiConfiguration.EndDateParameterName, ( ( DateTime ) endDate ).ToString( ApiConfiguration.JsonDatePattern ) );

            return
                await PerformApiCall<TmdbChanges>( GetApiUrl( String.Format( ApiConfiguration.MovieChangesMethodName, movieId ), parmeters ) );
        }

        /// <summary>
        ///     Gets the latest movie.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The latest movie.</returns>
        public async Task<TmdbResult<TmdbMovie>> GetLatestMovieAsync()
        {
            return await PerformApiCall<TmdbMovie>( GetApiUrl( ApiConfiguration.LatestMoviesMethodName ) );
        }

        /// <summary>
        ///     Gets a list of upcoming movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of the upcoming movies.</returns>
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetUpcomingMoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( ApiConfiguration.UpcomingMethodName, parmeters ) );
        }

        /// <summary>
        ///     Gets a list of movies playing in theatres.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A  list of movies playing in theatres.</returns>
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetNowPlayingmoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( ApiConfiguration.NowPlayingMoviesMethodName, parmeters ) );
        }

        /// <summary>
        ///     Gets a list of popular movies on The Movie Database.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of popular movies on The Movie Database.</returns>
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetPopularMoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( ApiConfiguration.PopularMethodName, parmeters ) );
        }

        /// <summary>
        ///     Gets a list of top rated movies.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>A list of top rated movies.</returns>
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetTopRatedMoviesAsync( Int32? pageNumber = null, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( ApiConfiguration.TopRatedMoviesMethodName, parmeters ) );
        }

        /// <summary>
        ///     Gets the movie account state of the movie with the given ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to load the account state of.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The movie account state of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbMovieAccountStates>> GetMovieAccountStateAsync( Int32 movieId, String sessionId )
        {
            return await PerformApiCall<TmdbMovieAccountStates>( GetApiUrl( String.Format( ApiConfiguration.MovieAccountStatesMethodName, movieId ),
                                                                            new Dictionary<String, String>
                                                                                {
                                                                                    {
                                                                                        ApiConfiguration.SessionIdParameterName, sessionId
                                                                                    }
                                                                                } ) );
        }

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
        public async Task<TmdbResult<TmdbStatusResponse>> RateMovieAsync( Int32 movieId, TmdbMovieRatingRequest ratingRequest, String sessionId = null,
                                                                          String guestSessionId = null )
        {
            var parameter = new Dictionary<String, String>();
            if ( sessionId != null )
                parameter.Add( ApiConfiguration.SessionIdParameterName, sessionId );
            else if ( guestSessionId != null )
                parameter.Add( ApiConfiguration.GuestSessionIdParameterName, guestSessionId );

            return
                await
                PerformApiCall<TmdbStatusResponse>( GetApiUrl( String.Format( ApiConfiguration.RatingMethodName, movieId ), parameter ), ratingRequest );
        }

        #endregion Movie

        #region Collection

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
        public async Task<TmdbResult<TmdbMovieCollection>> GetCollectionAsync( Int32 collectionId,
                                                                               TmdbCollectionMethod appendMethod = TmdbCollectionMethod.None,
                                                                               String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );
            if ( appendMethod != TmdbCollectionMethod.None )
                parmeters.Add( ApiConfiguration.AddToResponseParameterName, appendMethod.ToTmdbParameter( ApiConfiguration ) );

            return
                await
                PerformApiCall<TmdbMovieCollection>( GetApiUrl( String.Format( ApiConfiguration.MovieCollectionMethodName, collectionId ), parmeters ) );
        }

        /// <summary>
        ///     Gets all of the images of the collection with the specified ID.
        /// </summary>
        /// <param name="collectionId">The ID of the collection to load the images of.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the images to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fcollection%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>All of the images of the collection with the specified ID.</returns>
        public async Task<TmdbResult<TmdbCollectionImages>> GetCollectionImagesAsync( Int32 collectionId, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbCollectionImages>( GetApiUrl( String.Format( ApiConfiguration.MovieCollectionImageMethodName, collectionId ),
                                                                 parmeters ) );
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
        public async Task<TmdbResult<TmdbPersonInformation>> GetPersonAsync( Int32 personId, TmdbPersonMethod appendMethod = TmdbPersonMethod.None )
        {
            var parameters = new Dictionary<String, String>();
            if ( appendMethod != TmdbPersonMethod.None )
                parameters.Add( ApiConfiguration.AddToResponseParameterName, appendMethod.ToTmdbParameter( ApiConfiguration ) );

            return
                await
                PerformApiCall<TmdbPersonInformation>( GetApiUrl( String.Format( ApiConfiguration.GetPersonMethodName, personId ), parameters ) );
        }

        /// <summary>
        ///     Gets the credits of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the credits of.</param>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the credits to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fcredits
        /// </remarks>
        /// <returns>The credits of the person with the given ID.</returns>
        public async Task<TmdbResult<TmdbPersonCredits>> GetPersonCreditsAsync( Int32 personId, String iso639_1LanguageCode = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( iso639_1LanguageCode != null )
                parmeters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbPersonCredits>( GetApiUrl( String.Format( ApiConfiguration.PersonCreditsMethodName, personId ), parmeters ) );
        }

        /// <summary>
        ///     Gets the images of the person with the given ID.
        /// </summary>
        /// <param name="personId">The ID of the person to load the images of.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2F%7Bid%7D%2Fimages
        /// </remarks>
        /// <returns>The images of the person with the given ID.</returns>
        public async Task<TmdbResult<TmdbPersonImages>> GetPersonImageAsync( Int32 personId )
        {
            return
                await
                PerformApiCall<TmdbPersonImages>( GetApiUrl( String.Format( ApiConfiguration.PersonImagesMethodName, personId ) ) );
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
        public async Task<TmdbResult<TmdbChanges>> GetPersonChangesAsync( Int32 personId, DateTime? startDate = null, DateTime? endDate = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( startDate != null )
                parmeters.Add( ApiConfiguration.StartDateParameterName, ( ( DateTime ) startDate ).ToString( ApiConfiguration.JsonDatePattern ) );
            if ( endDate != null )
                parmeters.Add( ApiConfiguration.EndDateParameterName, ( ( DateTime ) endDate ).ToString( ApiConfiguration.JsonDatePattern ) );

            return
                await PerformApiCall<TmdbChanges>( GetApiUrl( String.Format( ApiConfiguration.PersonChangesMethodName, personId ), parmeters ) );
        }

        /// <summary>
        ///     Gets the reviews of the movie with the given ID.
        /// </summary>
        /// <param name="pageNumber">The number of the page to load.</param>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#movies
        /// </remarks>
        /// <returns>The reviews of the movie with the given ID.</returns>
        public async Task<TmdbResult<TmdbPersonPreviewList>> GetPopularPersonsAsync( Int32? pageNumber = null )
        {
            var parmeters = new Dictionary<String, String>();
            if ( pageNumber != null )
                parmeters.Add( ApiConfiguration.PageParameterName, pageNumber.ToString() );

            return await PerformApiCall<TmdbPersonPreviewList>( GetApiUrl( ApiConfiguration.PopularPeopleMethodName, parmeters ) );
        }

        /// <summary>
        ///     Gets the latest added person.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fperson%2Flatest
        /// </remarks>
        /// <returns>The latest added person.</returns>
        public async Task<TmdbResult<TmdbPersonInformation>> GetLatestPersonAsync()
        {
            return
                await
                PerformApiCall<TmdbPersonInformation>( GetApiUrl( ApiConfiguration.LatestPersonMethodName ) );
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
        public async Task<TmdbResult<TmdbMovieList>> GetListAsync( String listId )
        {
            return
                await
                PerformApiCall<TmdbMovieList>( GetApiUrl( String.Format( ApiConfiguration.ListMethodName, listId ) ) );
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
        public async Task<TmdbResult<TmdbMovieListStaus>> GetListStateAsync( String listId, Int32 movieId )
        {
            return
                await
                PerformApiCall<TmdbMovieListStaus>( GetApiUrl( String.Format( ApiConfiguration.ListStatusMethodName, listId ),
                                                               new Dictionary<String, String>
                                                                   {
                                                                       {
                                                                           ApiConfiguration.MovieIdParameterName, movieId.ToString()
                                                                       }
                                                                   } ) );
        }

        /// <summary>
        ///     Creates a new movie list, with the given name, description and language.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#post-%2F3%2Flist
        /// </remarks>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbResult<TmdbCreateMovieListResponse>> CreateMovieListAsync( String sessionId,
                                                                                         TmdbCreateMovieListRequest createMovieListRequest )
        {
            var parameter = new Dictionary<String, String>();
            if ( sessionId != null )
                parameter.Add( ApiConfiguration.SessionIdParameterName, sessionId );

            return
                await
                PerformApiCall<TmdbCreateMovieListResponse>( GetApiUrl( ApiConfiguration.CreateMovieListMethodName, parameter ),
                                                             createMovieListRequest );
        }

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
        public async Task<TmdbResult<TmdbStatusResponse>> AddItemToListAsync( String listId, TmdbListItemRequest item, String sessionId )
        {
            var parameter = new Dictionary<String, String>();
            if ( sessionId != null )
                parameter.Add( ApiConfiguration.SessionIdParameterName, sessionId );

            return
                await
                PerformApiCall<TmdbStatusResponse>( GetApiUrl( String.Format( ApiConfiguration.ListAddItemMethodName, listId ), parameter ), item );
        }

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
        public async Task<TmdbResult<TmdbStatusResponse>> RemoveItemFromListAsync( String listId, TmdbListItemRequest item, String sessionId )
        {
            var parameter = new Dictionary<String, String>();
            if ( sessionId != null )
                parameter.Add( ApiConfiguration.SessionIdParameterName, sessionId );

            return
                await
                PerformApiCall<TmdbStatusResponse>( GetApiUrl( String.Format( ApiConfiguration.ListRemoveItemMethodName, listId ), parameter ), item );
        }

        /// <summary>
        ///     Deletes the list with the given ID.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#delete-%2F3%2Flist%2F%7Bid%7D
        /// </remarks>
        /// <param name="listId">The ID of the list to delete.</param>
        /// <param name="sessionId">A valid session ID.</param>
        /// <returns>The response from the TMDb.</returns>
        public async Task<TmdbResult<TmdbStatusResponse>> DeleteListAsync( String listId, String sessionId )
        {
            var parameter = new Dictionary<String, String>();
            if ( sessionId != null )
                parameter.Add( ApiConfiguration.SessionIdParameterName, sessionId );

            return
                await
                PerformApiCall<TmdbStatusResponse>( GetApiUrl( String.Format( ApiConfiguration.DeleteListMethodName, listId ), parameter ), "DELETE" );
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
        public async Task<TmdbResult<TmdbCompanyInformation>> GetCompanyAsync( Int32 companyId,
                                                                               TmdbCompanyMethod appendMethod = TmdbCompanyMethod.None )
        {
            var parameters = new Dictionary<String, String>();
            if ( appendMethod != TmdbCompanyMethod.None )
                parameters.Add( ApiConfiguration.AddToResponseParameterName, appendMethod.ToTmdbParameter( ApiConfiguration ) );

            return
                await
                PerformApiCall<TmdbCompanyInformation>( GetApiUrl( String.Format( ApiConfiguration.CompanyMethodName, companyId ), parameters ) );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetCompanyMoviesAsync( Int32 companyId, Int32? page = null,
                                                                                   String iso639_1LanguageCode = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( String.Format( ApiConfiguration.CompanyMoviesMethodName, companyId ), parameters ) );
        }

        #endregion Companies

        #region Genres

        /// <summary>
        ///     Gets a list of all genres.
        /// </summary>
        /// <remarks>
        ///     Details: http://docs.themoviedb.apiary.io/#get-%2F3%2Fgenre%2Flist
        /// </remarks>
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the genres to load.</param>
        /// <returns>A list of all genres.</returns>
        public async Task<TmdbResult<TmdbGenreList>> GetGenresAsync( String iso639_1LanguageCode = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return await PerformApiCall<TmdbGenreList>( GetApiUrl( ApiConfiguration.GenreListMethodName, parameters ) );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetGenreMoviesAsync( Int32 genreId, Int32? page = null, String iso639_1LanguageCode = null,
                                                                                 Boolean? includeAllMovies = null, Boolean? includeAdult = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );
            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            if ( includeAllMovies != null )
                parameters.Add( ApiConfiguration.IncludeAllMoviesParameterName, includeAllMovies.ToString() );

            if ( includeAdult != null )
                parameters.Add( ApiConfiguration.IncludeAdultParameterName, includeAdult.ToString() );

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( String.Format( ApiConfiguration.GenreMovieMethodName, genreId ), parameters ) );
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
        public async Task<TmdbResult<TmdbKeyword>> GetKeywordAsync( Int32 keywordId )
        {
            return
                await
                PerformApiCall<TmdbKeyword>( GetApiUrl( String.Format( ApiConfiguration.KeywordMethodName, keywordId ) ) );
        }

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
        public async Task<TmdbResult<TmdbMoviePreviewList>> GetKeywordMoviesAsync( Int32 keywordId, Int32? page = null,
                                                                                   String iso639_1LanguageCode = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( String.Format( ApiConfiguration.KeywordMoviesMethodName, keywordId ), parameters ) );
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
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the ChangedEntries to return.</param>
        /// <param name="filter">The filters to apply to the result.</param>
        /// <returns>The result of the TMDb discovery method, using the specified filters.</returns>
        public async Task<TmdbResult<TmdbMoviePreviewList>> DiscoverMoviesAsync( Int32? page = null, String iso639_1LanguageCode = null,
                                                                                 DisoveryFilter filter = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            if ( filter != null )
            {
                if ( !String.IsNullOrEmpty( filter.CertificationCountry ) )
                    parameters.Add( ApiConfiguration.CertificationCountryParameterName, filter.CertificationCountry );

                if ( filter.IncludeAdult != null )
                    parameters.Add( ApiConfiguration.IncludeAdultParameterName, filter.IncludeAdult.ToString() );

                if ( filter.Year != null )
                    parameters.Add( ApiConfiguration.YearParameterName, filter.Year.ToString() );

                if ( filter.MinimumVoteCount != null )
                    parameters.Add( ApiConfiguration.MinimumVoteCountParameterName, filter.MinimumVoteCount.ToString() );

                if ( filter.MinimumAverageVotet != null )
                    parameters.Add( ApiConfiguration.MinimumVoteAverageParameterName, filter.MinimumAverageVotet.ToString() );

                if ( filter.PrimaryReleaseYear != null )
                    parameters.Add( ApiConfiguration.PrimaryReleaseYearParameterName, filter.PrimaryReleaseYear.ToString() );

                if ( filter.MinimumReleaseDate != null )
                    parameters.Add( ApiConfiguration.MinimumReleaseDateParameterName,
                                    ( ( DateTime ) filter.MinimumReleaseDate ).ToString( ApiConfiguration.JsonDatePattern ) );

                if ( filter.MaximumReleaseDate != null )
                    parameters.Add( ApiConfiguration.MaximumReleaseDateParameterName,
                                    ( ( DateTime ) filter.MaximumReleaseDate ).ToString( ApiConfiguration.JsonDatePattern ) );

                if ( filter.MaximumCertification != null )
                    parameters.Add( ApiConfiguration.MaximumCertificationParameterName, filter.MaximumCertification );

                if ( filter.Companies != null && filter.Companies.Any() )
                    parameters.Add( ApiConfiguration.WithCompaniesParameterName,
                                    filter.Companies.Select( x => x.ToString() )
                                          .Aggregate( ( current, x ) => String.Concat( current, ApiConfiguration.AndChar, x ) ) );

                if ( filter.SortBy != TmdbDiscoverySortBy.None )
                    parameters.Add( ApiConfiguration.DiscoverySortByParameterName, filter.SortBy.ToTmdbParameter( ApiConfiguration ) );

                if ( filter.GenreFilter != null && filter.GenreFilter != null && filter.GenreFilter.Genres.Any() )
                    parameters.Add( ApiConfiguration.WithGenresParameterName,
                                    filter.GenreFilter.Genres.Select( x => x.ToString() ).Aggregate(
                                        ( current, x ) =>
                                        String.Concat( current,
                                                       filter.GenreFilter.Operator == TmdbFilterOperator.And
                                                           ? ApiConfiguration.AndChar
                                                           : ApiConfiguration.OrChar, x ) ) );
            }

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( ApiConfiguration.DiscoverMethodName, parameters ) );
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
        /// <param name="iso639_1LanguageCode">The ISO 639-1 language code of the movies to return.</param>
        /// <param name="includeAdult">Toggle the inclusion of adult titles.</param>
        /// <param name="year">Filter the ChangedEntries release dates to matches that include this value.</param>
        /// <param name="primaryReleaseYear">Filter the ChangedEntries so that only the primary release dates have this value.</param>
        /// <param name="searchType">The search used search type, normally the default value is the option you will want.</param>
        /// <returns>The movies which matches the given query and filter.</returns>
        public async Task<TmdbResult<TmdbMoviePreviewList>> SearchMovieAsync( String query, Int32? page = null, String iso639_1LanguageCode = null,
                                                                              Boolean? includeAdult = null, Int32? year = null,
                                                                              Int32? primaryReleaseYear = null,
                                                                              TmdbSearchType searchType = TmdbSearchType.None )
        {
            var parameters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.QueryParameterName, query.EscapeString()
                    }
                };

            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            if ( includeAdult != null )
                parameters.Add( ApiConfiguration.IncludeAdultParameterName, includeAdult.ToString() );

            if ( year != null )
                parameters.Add( ApiConfiguration.YearParameterName, year.ToString() );

            if ( primaryReleaseYear != null )
                parameters.Add( ApiConfiguration.PrimaryReleaseYearParameterName, primaryReleaseYear.ToString() );

            if ( searchType != TmdbSearchType.None )
                parameters.Add( ApiConfiguration.SearchTypeParameterName, searchType.ToTmdbParameter( ApiConfiguration ) );

            return
                await
                PerformApiCall<TmdbMoviePreviewList>( GetApiUrl( ApiConfiguration.SearchMovieMethodName, parameters ) );
        }

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
        public async Task<TmdbResult<TmdbMovieCollectionPreviewList>> SearchMovieCollectionAsync( String query, Int32? page = null,
                                                                                                  String iso639_1LanguageCode = null )
        {
            var parameters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.QueryParameterName, query.EscapeString()
                    }
                };

            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( !String.IsNullOrEmpty( iso639_1LanguageCode ) )
                parameters.Add( ApiConfiguration.LanguageParameterName, iso639_1LanguageCode );

            return
                await
                PerformApiCall<TmdbMovieCollectionPreviewList>( GetApiUrl( ApiConfiguration.SearchCollectionMethodName, parameters ) );
        }

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
        public async Task<TmdbResult<TmdbPersonPreviewList>> SearchPersonAsync( String query, Int32? page = null,
                                                                                Boolean? includeAdult = null,
                                                                                TmdbSearchType searchType = TmdbSearchType.None )
        {
            var parameters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.QueryParameterName, query.EscapeString()
                    }
                };

            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( searchType != TmdbSearchType.None )
                parameters.Add( ApiConfiguration.SearchTypeParameterName, searchType.ToTmdbParameter( ApiConfiguration ) );

            if ( includeAdult != null )
                parameters.Add( ApiConfiguration.IncludeAdultParameterName, includeAdult.ToString() );

            return
                await
                PerformApiCall<TmdbPersonPreviewList>( GetApiUrl( ApiConfiguration.SearchPersonMethodName, parameters ) );
        }

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
        public async Task<TmdbResult<TmdbMovieListPreviewList>> SearchListAsync( String query, Int32? page = null, Boolean? includeAdult = null )
        {
            var parameters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.QueryParameterName, query.EscapeString()
                    }
                };

            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            if ( includeAdult != null )
                parameters.Add( ApiConfiguration.IncludeAdultParameterName, includeAdult.ToString() );

            return
                await
                PerformApiCall<TmdbMovieListPreviewList>( GetApiUrl( ApiConfiguration.SearchListMethodName, parameters ) );
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
        public async Task<TmdbResult<TmdCompanyPreviewList>> SearchCompanyAsync( String query, Int32? page = null )
        {
            var parameters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.QueryParameterName, query.EscapeString()
                    }
                };

            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            return
                await
                PerformApiCall<TmdCompanyPreviewList>( GetApiUrl( ApiConfiguration.SearchCompanyMethodName, parameters ) );
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
        public async Task<TmdbResult<TmdbKeywords>> SearchKeywordAsync( String query, Int32? page = null )
        {
            var parameters = new Dictionary<String, String>
                {
                    {
                        ApiConfiguration.QueryParameterName, query.EscapeString()
                    }
                };

            if ( page != null )
                parameters.Add( ApiConfiguration.PageParameterName, page.ToString() );

            return
                await
                PerformApiCall<TmdbKeywords>( GetApiUrl( ApiConfiguration.SearchKeywordMethodName, parameters ) );
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
        public async Task<TmdbResult<TmdbReview>> GetReviewAsync( String reviewId )
        {
            return
                await
                PerformApiCall<TmdbReview>( GetApiUrl( String.Format( ApiConfiguration.ReviewMethodName, reviewId ) ) );
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
        public async Task<TmdbResult<TmdbChangedEntriesList>> GetChangedMoviesAsync( DateTime? startTime = null, DateTime? endTime = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( startTime != null )
                parameters.Add( ApiConfiguration.StartDateParameterName, ( ( DateTime ) startTime ).ToString( ApiConfiguration.JsonDatePattern ) );
            if ( endTime != null )
                parameters.Add( ApiConfiguration.EndDateParameterName, ( ( DateTime ) endTime ).ToString( ApiConfiguration.JsonDatePattern ) );

            return await PerformApiCall<TmdbChangedEntriesList>( GetApiUrl( ApiConfiguration.ChangedMoviesMethodName, parameters ) );
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
        public async Task<TmdbResult<TmdbChangedEntriesList>> GetChangedPeopleAsync( DateTime? startTime = null, DateTime? endTime = null )
        {
            var parameters = new Dictionary<String, String>();
            if ( startTime != null )
                parameters.Add( ApiConfiguration.StartDateParameterName, ( ( DateTime ) startTime ).ToString( ApiConfiguration.JsonDatePattern ) );
            if ( endTime != null )
                parameters.Add( ApiConfiguration.EndDateParameterName, ( ( DateTime ) endTime ).ToString( ApiConfiguration.JsonDatePattern ) );

            return await PerformApiCall<TmdbChangedEntriesList>( GetApiUrl( ApiConfiguration.ChangedPeopleMethodName, parameters ) );
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
        public async Task<TmdbResult<TmdbDepartments>> GetJobsAsync()
        {
            return await PerformApiCall<TmdbDepartments>( GetApiUrl( ApiConfiguration.JobsMethodName ) );
        }

        #endregion Jobs

        #region Images

        /// <summary>
        ///     Downloads the image at the given path.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="tmdbConfiguration">A valid TMDb configuration.</param>
        /// <param name="fileName">The file name of the downloaded image.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>The path to the downloaded image.</returns>
        public async Task<TmdbResult<String>> DownloadImageAsync( String filePath, TmdbConfiguration tmdbConfiguration, String fileName,
                                                                  String size = null )
        {
            var url = GetImageUrl( filePath, tmdbConfiguration, size );
            var result =
                await
                ApiClient.DownloadFileAsync( url, fileName, ApiConfiguration.CacheLevel, ApiConfiguration.Timeout,
                                             ApiConfiguration.UseSecureConnection );

            return new TmdbResult<String>
                {
                    Error = result.Error,
                    Result = result.FilePath
                };
        }

        /// <summary>
        ///     Gets the image which matches the given parameters.
        /// </summary>
        /// <param name="filePath">The path to the image.</param>
        /// <param name="tmdbConfiguration">A valid TMDb configuration.</param>
        /// <param name="size">The size of the image (optional, default is the original size).</param>
        /// <returns>Gets the data of the image at the specified URL.</returns>
        public async Task<TmdbResult<Byte[]>> GetImageAsync( String filePath, TmdbConfiguration tmdbConfiguration, String size = null )
        {
            var url = GetImageUrl( filePath, tmdbConfiguration, size );
            var result =
                await ApiClient.GetFileAsync( url, ApiConfiguration.CacheLevel, ApiConfiguration.Timeout, ApiConfiguration.UseSecureConnection );

            return new TmdbResult<Byte[]>
                {
                    Error = result.Error,
                    Result = result.StreamContent
                };
        }

        /// <summary>
        ///     Gets the URL to the image with the specified size.
        /// </summary>
        /// <param name="filePath">The path to the image file.</param>
        /// <param name="tmdbConfiguration">The configuration of the TMDb API.</param>
        /// <param name="size">The size in which the image should get loaded, or null get it in the original size.</param>
        /// <exception cref="ArgumentOutOfRangeException">Was not able to find the original size in the TMDb tmdbConfiguration.</exception>
        /// <returns>The URL to the image with the specified size.</returns>
        public String GetImageUrl( String filePath, TmdbConfiguration tmdbConfiguration, String size = null )
        {
            return size == null
                       ? filePath.GetImageOriginalSizeUrl( ApiConfiguration, tmdbConfiguration )
                       : filePath.GetImageUrl( size, ApiConfiguration, tmdbConfiguration );
        }

        #endregion

        #region Private Members

        /// <summary>
        ///     Performs a call to the given API URL.
        /// </summary>
        /// <typeparam name="T">The type of the result to return.</typeparam>
        /// <param name="apiUrl">The API URL to call.</param>
        /// <param name="requestMethod">The method of the request.</param>
        /// <returns>The result of the API call.</returns>
        private async Task<TmdbResult<T>> PerformApiCall<T>( String apiUrl, String requestMethod = null )
            where T : TmdbModelBase, new()
        {
            return await PerformApiCall<T>( apiUrl, null, requestMethod );
        }

        /// <summary>
        ///     Performs a call to the given API URL.
        /// </summary>
        /// <typeparam name="T">The type of the result to return.</typeparam>
        /// <param name="apiUrl">The API URL to call.</param>
        /// <param name="requestContent">The content of the request sent to the TMDb API.</param>
        /// <param name="requestMethod">The method of the request.</param>
        /// <returns>The result of the API call.</returns>
        private async Task<TmdbResult<T>> PerformApiCall<T>( String apiUrl, ITmdbModelBase requestContent, String requestMethod = null )
            where T : TmdbModelBase, new()
        {
            try
            {
                IApiCallResult apiCallResult;

                if ( requestContent != null )
                    apiCallResult =
                        await
                        ApiClient.GetJsonAsync( apiUrl, requestContent, requestMethod, ApiConfiguration.CacheLevel, ApiConfiguration.Timeout,
                                                ApiConfiguration.UseSecureConnection );
                else
                    apiCallResult =
                        await
                        ApiClient.GetJsonAsync( apiUrl, requestMethod, ApiConfiguration.CacheLevel, ApiConfiguration.Timeout,
                                                ApiConfiguration.UseSecureConnection );

                var result = new TmdbResult<T>();
                if ( apiCallResult.Error != null )
                {
                    if ( !String.IsNullOrEmpty( apiCallResult.Json ) )
                    {
                        var statusMessage = new TmdbStatusResponse();
                        statusMessage = await statusMessage.DeserializeJson<TmdbStatusResponse>( apiCallResult.Json );
                        result.ApiErrorResponse = statusMessage;
                    }
                    result.Error = apiCallResult.Error;
                    return result;
                }
                if ( String.IsNullOrEmpty( apiCallResult.Json ) )
                    return result;

                result.Result = new T();
                result.Result = await result.Result.DeserializeJson<T>( apiCallResult.Json );
                result.Result.ETag = apiCallResult.ETag;
                return result;
            }
            catch ( Exception ex )
            {
                return new TmdbResult<T>
                    {
                        Error = ex
                    };
            }
        }

        /// <summary>
        ///     Gets the API URL for the specified method, including the API key and the given optimal parameters.
        /// </summary>
        /// <param name="method">The API method.</param>
        /// <param name="optionalParameters">A set of optional parameters (Name, Value). </param>
        /// <returns>The URL of the specified API method.</returns>
        private String GetApiUrl( String method, Dictionary<String, String> optionalParameters = null )
        {
            var url = String.Format( "{0}/{1}?{2}={3}",
                                     ApiConfiguration.UseSecureConnection == true ? ApiConfiguration.SecureApiUrl : ApiConfiguration.ApiUrl,
                                     method,
                                     ApiConfiguration.ApiKeyParameterName, ApiConfiguration.ApiKey );
            return optionalParameters == null
                       ? url
                       : optionalParameters.Aggregate( url,
                                                       ( current, parm ) =>
                                                       String.Concat( current,
                                                                      String.Format( "&{0}={1}", parm.Key, parm.Value ) ) );
        }

        #endregion Private Members
    }
}