using System.Windows;

using Caliburn.Micro;

using MovieMood.Common;
using MovieMood.Services;

namespace MovieMood.ViewModels
{
    public class SettingsPageViewModel : MovieMoodViewModel
    {
        private readonly GenreService genreService;

        public SettingsPageViewModel(BackgroundImageBrush backgroundImageBrush, INavigationService navigationService, ILog logger, GenreService genreService) : base(backgroundImageBrush, navigationService, logger)
        {
            this.genreService = genreService;
        }

        public void ClearCache()
        {
            genreService.ClearCache();
            MessageBox.Show("The movie cache is cleared.");
        }
    }
}
