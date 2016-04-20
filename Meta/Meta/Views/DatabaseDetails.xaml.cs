using Flattsware;
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
    /// Interaction logic for DatabaseDetails.xaml
    /// </summary>
    public partial class DatabaseDetails : Window
    {
        ViewModels.DatabaseDetailsWindowViewModel viewModel = new ViewModels.DatabaseDetailsWindowViewModel();

        public DatabaseDetails()
        {
            InitializeComponent();
            DataContext = viewModel;
            if (viewModel.CloseAction.IsNull())
            {
                viewModel.CloseAction = new Action(() => Close());
            }
        }
    }
}
