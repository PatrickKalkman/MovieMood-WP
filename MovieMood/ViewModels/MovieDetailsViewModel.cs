using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

using Caliburn.Micro;

using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

using MovieMood.Common;
using MovieMood.Netflix;
using MovieMood.Resources;
using MovieMood.Services;
using MovieMood.Views;

using MyToolkit.Multimedia;

using NTmdb;

namespace MovieMood.ViewModels
{
    public class MovieDetailsViewModel : MovieMoodViewModel, IHandle<RouletteResponse>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly MovieService movieService;
        private readonly NetflixRoulette netflixRoulette;

        public MovieDetailsViewModel(BackgroundImageBrush backgroundImageBrush, INavigationService navigationService, ILog logger, IEventAggregator eventAggregator, MovieService movieService, NetflixRoulette netflixRoulette)
            : base(backgroundImageBrush, navigationService, logger)
        {
            this.eventAggregator = eventAggregator;
            this.movieService = movieService;
            this.netflixRoulette = netflixRoulette;
            eventAggregator.Subscribe(this);
        }

        private MovieDetailsView view;

        protected override void OnViewLoaded(object view)
        {
            this.view = view as MovieDetailsView;
            base.OnViewLoaded(view);
            StartTrailer();
        }

        ProgressIndicator progressIndicator;

        public async void StartTrailer()
        {
            progressIndicator = new ProgressIndicator();
            progressIndicator.IsIndeterminate = true;
            SystemTray.SetProgressIndicator(view, progressIndicator);
            progressIndicator.IsVisible = true;
            try
            {
                TmdbTrailers trailers = await movieService.GetTrailers(MovieId);
                if (trailers.Youtube != null && trailers.Youtube.Count > 0)
                {
                    await YouTube.PlayWithPageDeactivationAsync(trailers.Youtube[0].Source, true, YouTubeQuality.Quality480P);
                }
            }
            catch (Exception ex)
            {
                SystemTray.ProgressIndicator.IsVisible = false;
                MessageBox.Show(ex.Message);
            }

            progressIndicator.IsVisible = false;
        }

        public void StartNetflix()
        {
            try
            {
                netflixRoulette.CreateRequest(MovieTitle);
            }
            catch (Exception error)
            {
                logger.Error(error);
                ShowMovieNotFoundMessage();
            }
        }

        private void ShowMovieNotFoundMessage()
        {
            MessageBox.Show(string.Format("Could not find the movie \"{0}\" on Netflix", MovieTitle));
        }

        public int MovieId { get; set; }

        public string MovieTitle { get; set; }

        public int MovieYear { get; set; }

        public string PageTitle
        {
            get { return AppResources.TrailerPageTitle; }
        }

        public void Handle(RouletteResponse message)
        {
            if (message != null && message.show_id != 0)
            {
                GotoUrl(string.Format("http://www.netflix.com/WiPlayer?movieid={0}", message.show_id));
            }
            else
            {
                ShowMovieNotFoundMessage();
            }
        }

        public void GotoUrl(string url)
        {
            var wbtask = new WebBrowserTask();
            wbtask.Uri = new Uri(url);
            wbtask.Show();
        }
    }
}
