using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Meta.Views
{
    /// <summary>
    /// Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        ViewModels.SplashScreenViewModel viewModel = new ViewModels.SplashScreenViewModel();

        public SplashScreenView()
        {
            InitializeComponent();
            DataContext = viewModel;

            log4net.Config.XmlConfigurator.Configure();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool loaded = await viewModel.OnLoad();

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