using System.Windows;
using Flattsware;
using Meta.Views;

namespace Meta
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public class App : Application
    {
        public static User CurrentUser { get; set; }
        public static Event CurrentEvent { get; set; }
        public static MainWindowViewModel MainWindowViewModel { get; set; }
    }
}