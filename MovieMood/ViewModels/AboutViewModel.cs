using System;
using System.Reflection;

using Caliburn.Micro;

using Microsoft.Phone.Tasks;

using MovieMood.Common;
using MovieMood.Resources;

namespace MovieMood.ViewModels
{
    public class AboutViewModel : MovieMoodViewModel
    {
        public AboutViewModel(BackgroundImageBrush backgroundImageBrush, INavigationService navigationService, ILog logger)
            : base(backgroundImageBrush, navigationService, logger)
        {
        }

        public string PageTitle
        {
            get { return AppResources.AboutPageTitle; }
        }


        public string Version
        {
            get
            {
                var nameHelper = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
                return nameHelper.Version.ToString();
            }
        }

        public string AppDescription
        {
            get
            {
                return "Select your mood and find a movie that corresponds with your mood. This app was created by using the amazing TMDB database and their api.";
            }
        }

        public void RateThisApp()
        {
            var reviewTask = new MarketplaceReviewTask();
            reviewTask.Show();
        }

        public void SendAnEmail()
        {
            var emailTask = new EmailComposeTask();
            emailTask.To = "pkalkie@gmail.com";
            emailTask.Show();
        }
    }
}
