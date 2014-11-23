using Caliburn.Micro;

using MovieMood.Common;
using MovieMood.Resources;

namespace MovieMood.ViewModels
{
    public class HelpPageViewModel : MovieMoodViewModel
    {
        public HelpPageViewModel(BackgroundImageBrush backgroundImageBrush, INavigationService navigationService, ILog logger)
            : base(backgroundImageBrush, navigationService, logger)
        {
        }

        public string PageTitle
        {
            get { return AppResources.HelpPageTitle; }
        }
    }
}