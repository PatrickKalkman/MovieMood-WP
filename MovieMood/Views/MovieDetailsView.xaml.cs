using System.ComponentModel;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using MyToolkit.Multimedia;

namespace MovieMood.Views
{
    public partial class MovieDetailsView : PhoneApplicationPage
    {
        public MovieDetailsView()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (YouTube.CancelPlay()) // used to abort current youtube download
                e.Cancel = true;

            base.OnBackKeyPress(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            YouTube.CancelPlay(); // used to reenable page
            base.OnNavigatedTo(e);
        }


    }
}