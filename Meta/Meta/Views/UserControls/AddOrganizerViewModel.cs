using System.Windows.Input;
using Flattsware;
using Flattsware.Helpers;

namespace Meta.Views.UserControls
{
    public class AddOrganizerViewModel : BindableBase, IUserControlViewModel
    {
        #region Constructors

        public AddOrganizerViewModel()
        {
            Organizer.MailingAddress = new Address();
            Organizer.PhysicalAddress = new Address();
        }

        #endregion

        #region Fields

        private ICommand _cancelCommand;
        private ICommand _addOrganizerCommand;
        private Organizer _organizer = new Organizer();

        #endregion

        #region Properties

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new DelegateCommand(Cancel));

        public ICommand AddOrganizerCommand
            => _addOrganizerCommand ?? (_addOrganizerCommand = new DelegateCommand(AddOrganizer));

        public Organizer Organizer
        {
            get { return _organizer; }
            set { SetProperty(ref _organizer, value); }
        }

        #endregion

        #region Methods

        private static void Cancel()
        {
            App.MainWindowViewModel.ChangeUserControlViewModel(null);
        }

        private void AddOrganizer()
        {
            if (!Organizer.ValidateAndSave()) return;
            Dialog.ShowInformation("Organizer Saved Successfully.");
            Cancel();
        }

        #endregion
    }
}