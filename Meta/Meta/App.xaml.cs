using Flattsware;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Meta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User CurrentUser { get; set; }
        public static Event CurrentEvent { get; set; }
        public static ViewModels.MainWindowViewModel MainWindowViewModel { get; set; }
    }
}
