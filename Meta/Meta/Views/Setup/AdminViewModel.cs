using System.Windows.Input;
using Flattsware;
using Meta.Views.UserControls;

namespace Meta.Views.Setup
{
    public class AdminViewModel : BindableBase, IPageViewModel
    {
        #region Fields

        private ICommand _addOrganizerCommand;
        private ICommand _updatePermissionsCommand;

        #endregion

        #region Methods

        private static void AddOrganizer()
        {
            if (App.MainWindowViewModel.IsNotNull())
            {
                App.MainWindowViewModel.ChangeUserControlViewModel(new AddOrganizerViewModel());
            }
        }

        private static void UpdatePermissions()
        {
            if (App.MainWindowViewModel.IsNotNull())
            {
                App.MainWindowViewModel.ChangeUserControlViewModel(new ViewObjectsViewModel<User>(User.GetAll()));
            }
        }

        #endregion

        #region Constructors

        public AdminViewModel()
        {
        }

        public AdminViewModel(int ordinal)
        {
            Label = GetType().Name.Replace("ViewModel", string.Empty);
            HotKeyLabel = $"Ctrl-{ordinal}";
        }

        #endregion

        #region Properties

        public ICommand AddOrganizerCommand
            => _addOrganizerCommand ?? (_addOrganizerCommand = new DelegateCommand(AddOrganizer));

        public ICommand UpdatePermissionsCommand
            => _updatePermissionsCommand ?? (_updatePermissionsCommand = new DelegateCommand(UpdatePermissions));

        public string Label { get; set; }
        public string HotKeyLabel { get; set; }

        #endregion
    }
}