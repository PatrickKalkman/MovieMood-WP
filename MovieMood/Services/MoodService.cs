using System;
using System.Collections.Generic;

namespace MovieMood.Services
{
    public class MoodService
    {
        public List<MoodPanel> GetAll()
        {
            var moods = new List<MoodPanel>();
            moods.Add(new MoodPanel {Mood = Mood.Love, MoodIcon = new Uri("../Assets/Moods/Love.png", UriKind.Relative)});
            moods.Add(new MoodPanel { Mood = Mood.Afraid, MoodIcon = new Uri("../Assets/Moods/Afraid.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Anger, MoodIcon = new Uri("../Assets/Moods/Angry.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Envy, MoodIcon = new Uri("../Assets/Moods/Envy.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Happy, MoodIcon = new Uri("../Assets/Moods/Happy.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Sad, MoodIcon = new Uri("../Assets/Moods/Sad.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Surprise, MoodIcon = new Uri("../Assets/Moods/Surprised.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Excited, MoodIcon = new Uri("../Assets/Moods/Excited.png", UriKind.Relative) });
            moods.Add(new MoodPanel { Mood = Mood.Anxious, MoodIcon = new Uri("../Assets/Moods/Anxious.png", UriKind.Relative) });
            return moods;
        }
    }
}
