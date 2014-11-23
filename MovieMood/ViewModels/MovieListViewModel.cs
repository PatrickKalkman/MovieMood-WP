using System;
using System.Collections.ObjectModel;

using Caliburn.Micro;

using Microsoft.Phone.Shell;

using MovieMood.Common;
using MovieMood.Netflix;
using MovieMood.Services;
using MovieMood.Views;

using NTmdb;

namespace MovieMood.ViewModels
{
    public class MovieListViewModel : MovieMoodViewModel, IHandle<RouletteResponse>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly MovieService movieService;
        private readonly FlipTileCreator flipTileCreator;

        public MovieListViewModel(BackgroundImageBrush backgroundImageBrush, INavigationService navigationService, ILog logger, IEventAggregator eventAggregator, MovieService movieService, FlipTileCreator flipTileCreator) : base(backgroundImageBrush, navigationService, logger)
        {
            this.eventAggregator = eventAggregator;
            this.movieService = movieService;
            this.flipTileCreator = flipTileCreator;
            eventAggregator.Subscribe(this);
            EmptyContent = "Loading.....";
        }

        private MovieListView view;

        private ProgressIndicator progressIndicator;

        protected override void OnViewLoaded(object view)
        {
            this.view = view as MovieListView;
            base.OnViewLoaded(view);
            RefreshList(null);
        }

        public async void RefreshList(EventArgs args)
        {
            progressIndicator = new ProgressIndicator();
            progressIndicator.IsIndeterminate = true;
            SystemTray.SetProgressIndicator(view, progressIndicator);
            progressIndicator.IsVisible = true;

            Movies = new ObservableCollection<TmdbMovie>(await movieService.GetSuggestedMovies(Mood));

            if (Movies.Count == 0)
            {
                EmptyContent = "No content available";
            }
            else
            {
                string contentLarge = string.Format("Feeling {0}? Why don't you watch {1}", Mood, Movies[0].Title);
                string content = string.Format("Feeling {0}? Watch {1}", Mood, Movies[0].Title);
                flipTileCreator.UpdateDefaultTile(content, contentLarge);
            }

            progressIndicator.IsVisible = false;
            this.view.MovieListBox.StopPullToRefreshLoading(true, true);
        }

        private ObservableCollection<TmdbMovie> movies;

        public ObservableCollection<TmdbMovie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                this.NotifyOfPropertyChange(() => Movies);
            }
        }

        private TmdbMovie selectedMovie;

        public TmdbMovie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                this.NotifyOfPropertyChange(() => SelectedMovie);
                NavigateToDetailView();
            }
        }

        private void NavigateToDetailView()
        {
            if (SelectedMovie != null)
            {
                int movieYear = 0;
                if (!string.IsNullOrWhiteSpace(selectedMovie.ReleaseDateString))
                {
                    movieYear = int.Parse(selectedMovie.ReleaseDateString.Substring(0, 4));
                }
                var uri = navigationService.UriFor<MovieDetailsViewModel>().WithParam(md => md.MovieId, SelectedMovie.Id).WithParam(md => md.MovieTitle, SelectedMovie.Title).WithParam(md => md.MovieYear, movieYear).BuildUri();
                navigationService.Navigate(uri);
            }
        }

        public Mood Mood { get; set; }
        
        public string MoodString
        {
            get { return Mood.ToString().ToUpper(); }
        }

        public void Handle(RouletteResponse message)
        {
            if (!message.error)
            {
                Movies[0].PosterPath = message.poster;
                this.NotifyOfPropertyChange(() => Movies);
            }
        }

        private string emptyContent;

        public string EmptyContent
        {
            get { return emptyContent; }
            set
            {
                emptyContent = value;
                this.NotifyOfPropertyChange(() => EmptyContent);
            }
        }
    }
}
