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

namespace Meta.Views.Account
{
    /// <summary>
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        ViewModels.Account.ForgotPasswordViewModel viewModel = new ViewModels.Account.ForgotPasswordViewModel();

        public ForgotPasswordWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
