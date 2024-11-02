using SOS_NET_MAUI.Views;

namespace SOS_NET_MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // setup start page as Game Page
            MainPage = new AppShell();
            MainPage = new SOSGamePage();
            // Not sure why the below line was omitted from sol'n
            //MainPage = new AppShell();
        }
    }
}
