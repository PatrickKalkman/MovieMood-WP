using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using NTmdb;

using Telerik.Windows.Controls;

namespace MovieMood.Services
{
    public class MovieService
    {
        private readonly TmdbAbstraction tmdbAbstraction;
        private readonly GenreService genreService;
        private readonly Random random = new Random(DateTime.Now.Millisecond);

        private readonly List<int> idsGenerated = new List<int>();

        public MovieService(TmdbAbstraction tmdbAbstraction, GenreService genreService)
        {
            this.tmdbAbstraction = tmdbAbstraction;
            this.genreService = genreService;
        }

        public async Task<List<TmdbMovie>> GetSuggestedMovies(Mood mood)
        {
            int tmdbGenreId = await genreService.GetGenreId(mood);
            int page = random.Next(1, 10);
            TmdbMoviePreviewList movies = await tmdbAbstraction.GetGenreMoviesAsync(tmdbGenreId, page);
            var tmdbMovies = new List<TmdbMovie>();
            for (int movieCount = 0; movieCount < 3; movieCount++)
            {
                int movieIndex = GetUniqueMovieId();
                TmdbMovie movie = await tmdbAbstraction.GetMovieAsync(movies.Movies[movieIndex].Id, TmdbMovieMethod.Casts | TmdbMovieMethod.Trailers | TmdbMovieMethod.Releases);
                tmdbMovies.Add(movie);
            }
            return tmdbMovies;
        }

        private int GetUniqueMovieId()
        {
            int uniqueId = random.Next(1, 20);
            int iterations = 0;
            while (idsGenerated.Contains(uniqueId))
            {
                uniqueId = random.Next(1, 20);
                iterations++;
                if (iterations > 5)
                {
                    break;
                }
            }
            return uniqueId;
        }

        public async Task<TmdbTrailers> GetTrailers(int movieId)
        {
            return await tmdbAbstraction.GetMovieTrailersAsync(movieId);
        }
    }
}
