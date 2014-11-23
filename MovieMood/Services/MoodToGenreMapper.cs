using System;
using System.Linq;

namespace MovieMood.Services
{
    public class MoodToGenreMapper
    {
        private readonly MovieMoodGenreMapping movieMoodGenreMapping;

        public MoodToGenreMapper(MovieMoodGenreMapping movieMoodGenreMapping)
        {
            this.movieMoodGenreMapping = movieMoodGenreMapping;
        }

        public string Map(Mood mood)
        {
            MoodGenre mapping = movieMoodGenreMapping.SingleOrDefault(mg => mg.Mood == mood);
            if (mapping != null)
            {
                return mapping.Genre;
            }
            throw new ArgumentException(string.Format("Could not find mood {0}", mood.ToString()));
        }
    }
}
