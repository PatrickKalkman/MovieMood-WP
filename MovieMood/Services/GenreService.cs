using System;
using System.Linq;
using System.Threading.Tasks;

using MovieMood.Common;

using NTmdb;

namespace MovieMood.Services
{
    public class GenreService
    {
        private readonly TmdbAbstraction tmdbAbstraction;
        private readonly CachingService cachingService;
        private const string GenreCacheKey = "Genres";
        private const int CacheTimeInMinutes = 24 * 60 * 5;

        public GenreService(TmdbAbstraction tmdbAbstraction, CachingService cachingService)
        {
            this.tmdbAbstraction = tmdbAbstraction;
            this.cachingService = cachingService;
        }

        public async Task<int> GetGenreId(Mood mood)
        {
            MovieMoodGenreMapping genres = await GetGenres();
            MoodGenre moodGenre = genres.SingleOrDefault(g => g.Mood == mood);
            if (moodGenre != null)
            {
                return moodGenre.TmDbGenreId;
            }
            throw new ArgumentException(string.Format("Could not find mood {0}", mood), "mood");
        }

        public async Task<MovieMoodGenreMapping> GetGenres()
        {
            var cacheItem = await cachingService.IsAvailable(GenreCacheKey, CacheTimeInMinutes);
            if (cacheItem.IsAvailable && !cacheItem.IsExpired)
            {
                return await cachingService.LoadCachedData<MovieMoodGenreMapping>(GenreCacheKey, CacheTimeInMinutes);
            }

            var mapping = await GenerateMapping();
            cachingService.StoreCachedData(GenreCacheKey, mapping);
            return mapping;
        }

        private async Task<MovieMoodGenreMapping> GenerateMapping()
        {
            TmdbGenreList genres = await tmdbAbstraction.GetGenresAsync();
            var mapping = new MovieMoodGenreMapping();
            mapping.Initialize();
            foreach (MoodGenre moodGenre in mapping)
            {
                TmdbGenre genre = genres.Genres.SingleOrDefault(g => String.Equals(g.Name, moodGenre.Genre, StringComparison.CurrentCultureIgnoreCase));
                if (genre != null)
                {
                    moodGenre.TmDbGenreId = genre.Id;
                }
            }
            return mapping;
        }

        public void ClearCache()
        {
            cachingService.Clear(GenreCacheKey);
        }
    }
}
