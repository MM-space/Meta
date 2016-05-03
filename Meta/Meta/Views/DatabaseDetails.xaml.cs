using Flattsware;

namespace Meta.Views
{
    /// <summary>
    ///     Interaction logic for DatabaseDetails.xaml
    /// </summary>
    public partial class DatabaseDetails
    {
        private readonly DatabaseDetailsWindowViewModel _viewModel = new DatabaseDetailsWindowViewModel();

        public DatabaseDetails()
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