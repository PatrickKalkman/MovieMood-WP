using System;

namespace MovieMood.Services
{
    public class MoodPanel
    {
        public Uri MoodIcon { get; set; }
        public Mood Mood { get; set; }

        public string MoodString
        {
            get { return Mood.ToString().ToUpper(); }
        }
    }
}