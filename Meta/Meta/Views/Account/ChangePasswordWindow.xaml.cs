using Flattsware;

namespace Meta.Views.Account
{
    /// <summary>
    ///     Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow
    {
        private readonly ChangePasswordViewModel _viewModel = new ChangePasswordViewModel();

        public ChangePasswordWindow(User user)
        {
            InitializeComponent();
            _viewModel.User = user;
            DataContext = _viewModel;
        }
    }
}