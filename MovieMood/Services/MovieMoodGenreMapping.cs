using System.Collections.Generic;

namespace MovieMood.Services
{
    public class MovieMoodGenreMapping : List<MoodGenre>
    {
        public void Initialize()
        {
            this.Add(new MoodGenre { Genre = "Action", Mood = Mood.Anger });
            this.Add(new MoodGenre { Genre = "Romance", Mood = Mood.Envy });
            this.Add(new MoodGenre { Genre = "Comedy", Mood = Mood.Happy });
            this.Add(new MoodGenre { Genre = "Romance", Mood = Mood.Love });
            this.Add(new MoodGenre { Genre = "Drama", Mood = Mood.Sad });
            this.Add(new MoodGenre { Genre = "Thriller", Mood = Mood.Surprise });
            this.Add(new MoodGenre { Genre = "Horror", Mood = Mood.Afraid });
            this.Add(new MoodGenre { Genre = "Mystery", Mood = Mood.Anxious });
            this.Add(new MoodGenre { Genre = "Adventure", Mood = Mood.Excited });

        }
    }
}
