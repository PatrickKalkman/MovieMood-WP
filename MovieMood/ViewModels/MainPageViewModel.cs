using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows;

using Caliburn.Micro;

using MovieMood.Common;
using MovieMood.Resources;
using MovieMood.Services;

namespace MovieMood.ViewModels
{
    public class MainPageViewModel : MovieMoodViewModel
    {
        private readonly MoodService moodService;

        public MainPageViewModel(BackgroundImageBrush backgroundImageBrush, INavigationService navigationService, ILog logger, MoodService moodService)
            : base(backgroundImageBrush, navigationService, logger)
        {
            this.moodService = moodService;

            AboutButtonText = "about";
            PrivacyButtonText = "privacy";
            HelpButtonText = "help";
            SettingButtonText = "setting";
        }

        protected override void OnActivate()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(
                    "MovieMood needs a internet connection to function properly, make sure that you are connected through a wifi or other data connection");
            }

            Moods = new ObservableCollection<MoodPanel>(moodService.GetAll());

            base.OnActivate();
        }

        public string PageTitle
        {
            get { return AppResources.MainPageTitle; }
        }

        private ObservableCollection<MoodPanel> moods;

        public ObservableCollection<MoodPanel> Moods
        {
            get { return moods; }
            set
            {
                moods = value; 
                NotifyOfPropertyChange(() => Moods);
            }
        }

        private MoodPanel selectedMood;

        public MoodPanel SelectedMood
        {
            get { return selectedMood; }
            set
            {
                selectedMood = value;
                NotifyOfPropertyChange(() => SelectedMood);
                if (SelectedMood != null)
                {
                    NavigateToMood();
                }
            }
        }

        private void NavigateToMood()
        {
            var uri = navigationService.UriFor<MovieListViewModel>().WithParam(g => g.Mood, SelectedMood.Mood).BuildUri();
            navigationService.Navigate(uri);
        }

        public void Settings()
        {
            var uri = navigationService.UriFor<SettingsPageViewModel>().BuildUri();
            navigationService.Navigate(uri);
        }

        public void Privacy()
        {
            var uri = navigationService.UriFor<PrivacyPageViewModel>().BuildUri();
            navigationService.Navigate(uri);
        }

        public void Help()
        {
            var uri = navigationService.UriFor<HelpPageViewModel>().BuildUri();
            navigationService.Navigate(uri);
        }

        public void About()
        {
            var uri = navigationService.UriFor<AboutViewModel>().BuildUri();
            navigationService.Navigate(uri);
        }
            
        private string helpButtonText;

        public string HelpButtonText
        {
            get { return helpButtonText; }
            set
            {
                helpButtonText = value;
                NotifyOfPropertyChange(() => HelpButtonText);
            }
        }

        private string aboutButtonText;

        public string AboutButtonText
        {
            get { return aboutButtonText; }
            set
            {
                aboutButtonText = value;
                NotifyOfPropertyChange(() => AboutButtonText);
            }
        }

        private string privacyButtonText;

        public string PrivacyButtonText
        {
            get { return privacyButtonText; }
            set
            {
                privacyButtonText = value;
                NotifyOfPropertyChange(() => PrivacyButtonText);
            }
        }

        private string settingButtonText;

        public string SettingButtonText
        {
            get { return settingButtonText; }
            set
            {
                settingButtonText = value;
                NotifyOfPropertyChange(() => SettingButtonText);
            }
        }
    }
}