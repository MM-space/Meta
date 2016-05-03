namespace Meta.Views.Account
{
    /// <summary>
    ///     Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow
    {
        private readonly ForgotPasswordViewModel _viewModel = new ForgotPasswordViewModel();

        public ForgotPasswordWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}