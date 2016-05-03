using Flattsware;

namespace Meta.Views.Account
{
    /// <summary>
    ///     Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private readonly LoginWindowViewModel _viewModel = new LoginWindowViewModel();

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
            if (_viewModel.CloseAction.IsNull())
            {
                _viewModel.CloseAction = Close;
            }
        }
    }
}