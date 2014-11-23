namespace MovieMood.Services
{
    public class MoodGenre
    {
        public string Genre { get; set; }
        public Mood Mood { get; set; } 
        public int TmDbGenreId { get; set; }
    }
}