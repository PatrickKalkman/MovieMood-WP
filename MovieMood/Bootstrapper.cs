using System;
using System.Collections.Generic;
using System.Windows.Controls;

using Caliburn.Micro;
using Caliburn.Micro.BindableAppBar;

using Microsoft.Phone.Controls;

using MovieMood.Common;
using MovieMood.Netflix;
using MovieMood.Services;
using MovieMood.ViewModels;

using NTmdb;

using Telerik.Windows.Controls;

namespace MovieMood
{
    public class Bootstrapper : PhoneBootstrapper
    {
        private const string TMDBApiKey = "dc59f0c3d6d64422e174da6e111973f5";

        private PhoneContainer container;

        private RadDiagnostics diagnostics;

        public Bootstrapper()
        {
            LogManager.GetLog = type => new DebugLogger(type);
        }

        void diagnostics_ExceptionOccurred(object sender, ExceptionOccurredEventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendException(e.Exception.Message, true);
        }

        protected override PhoneApplicationFrame CreatePhoneApplicationFrame()
        {
            return new TransitionFrame();
        }

        protected override void Configure()
        {
            container = new PhoneContainer();

            container.RegisterPhoneServices(RootFrame);

            container.PerRequest<MainPageViewModel>();
            container.PerRequest<BackgroundImageBrush>();
            container.PerRequest<FlipTileCreator>();
            container.PerRequest<PrivacyPageViewModel>();
            container.PerRequest<CachingService>();
            container.PerRequest<SettingsHelper>();
            container.PerRequest<MovieService>();
            container.PerRequest<HelpPageViewModel>();
            container.PerRequest<SettingsPageViewModel>();
            container.PerRequest<AboutViewModel>();
            container.PerRequest<GenreService>();
            container.PerRequest<MoodService>();
            container.PerRequest<MovieListViewModel>();
            container.PerRequest<MovieDetailsViewModel>();
            container.PerRequest<NetflixRoulette>();

            container.RegisterSingleton(typeof(ILog), "", typeof(DebugLogger));

            TmdbAbstraction tmdbAbstraction = CreateTmdbAbstraction();
            container.RegisterInstance(typeof(TmdbAbstraction), null, tmdbAbstraction);

            AddCustomConventions();
            diagnostics = new RadDiagnostics();
            diagnostics.EmailTo = "pkalkie@gmail.com";
            diagnostics.ExceptionOccurred += diagnostics_ExceptionOccurred;
            diagnostics.Init();
            ApplicationUsageHelper.Init("1.0");
        }

        public TmdbAbstraction CreateTmdbAbstraction()
        {
            var configuration = new ApiConfiguration();
            configuration.RestoreDefaultValues(TMDBApiKey);
            
            var apiWrapper = new ApiWrapper();
            apiWrapper.ApiClient = new ApiClientNet();
            apiWrapper.ApiConfiguration = configuration;

            var abstraction = new TmdbAbstraction(apiWrapper);
            abstraction.Iso639_1LanguageCode = "en";
            return abstraction;
        }

        static void AddCustomConventions()
        {
            ConventionManager.AddElementConvention<BindableAppBarButton>(
                Control.IsEnabledProperty, "DataContext", "Click");
            ConventionManager.AddElementConvention<BindableAppBarMenuItem>(
                Control.IsEnabledProperty, "DataContext", "Click");
        }

        protected override void OnActivate(object sender, Microsoft.Phone.Shell.ActivatedEventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("Bootstrapper", "Activate", null, 0);
            base.OnActivate(sender, e);
        }

        protected override void OnLaunch(object sender, Microsoft.Phone.Shell.LaunchingEventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("Bootstrapper", "Launch", null, 0);
            base.OnLaunch(sender, e);
        }

        protected override void OnDeactivate(object sender, Microsoft.Phone.Shell.DeactivatedEventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("Bootstrapper", "Deactivate", null, 0);
            base.OnDeactivate(sender, e);
        }

        protected override void OnClose(object sender, Microsoft.Phone.Shell.ClosingEventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("Bootstrapper", "Close", null, 0);
            base.OnClose(sender, e);
        }

        protected override void OnUnhandledException(object sender, System.Windows.ApplicationUnhandledExceptionEventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendException(e.ExceptionObject.Message, false);
            base.OnUnhandledException(sender, e);
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new Exception("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
