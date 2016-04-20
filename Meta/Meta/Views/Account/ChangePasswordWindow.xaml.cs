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
using Flattsware;

namespace Meta.Views.Account
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        ViewModels.Account.ChangePasswordViewModel viewModel = new ViewModels.Account.ChangePasswordViewModel();

        public ChangePasswordWindow(User user)
        {
            InitializeComponent();
            viewModel.User = user;
            DataContext = viewModel;
        }
    }
}
