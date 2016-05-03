using System.Windows;
using log4net.Config;

namespace Meta.Views
{
    /// <summary>
    ///     Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView
    {
        private readonly SplashScreenViewModel _viewModel = new SplashScreenViewModel();

        public SplashScreenView()
        {
            InitializeComponent();
            DataContext = _viewModel;

            XmlConfigurator.Configure();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var loaded = await _viewModel.OnLoad();

            if (loaded)
            {
                Close();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}