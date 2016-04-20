using Flattsware;
using Flattsware.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels.UserControls
{
    public class AddOrganizerViewModel : BindableBase, IUserControlViewModel
    {
        #region Fields

        private ICommand _cancelCommand;
        private Organizer _organizer;
        private AddressViewModel _mailingAddressViewModel = new AddressViewModel();
        private AddressViewModel _physicalAddressViewModel = new AddressViewModel();
        private FindPersonViewModel _mainContactViewModel = new FindPersonViewModel();

        #endregion

        #region Constructors



        #endregion

        #region Properties

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new DelegateCommand(() => Cancel()));
        public Organizer Organizer { get { return _organizer; } set { SetProperty(ref _organizer, value); } }
        public AddressViewModel MailingAddressViewModel { get { return _mailingAddressViewModel; } set { SetProperty(ref _mailingAddressViewModel, value); } }
        public AddressViewModel PhysicalAddressViewModel { get { return _physicalAddressViewModel; } set { SetProperty(ref _physicalAddressViewModel, value); } }
        public FindPersonViewModel MainContactViewModel { get { return _mainContactViewModel; } set { SetProperty(ref _mainContactViewModel, value); } }
        public Address MailingAddress => MailingAddressViewModel.Address;
        public Address PhysicalAddress => PhysicalAddressViewModel.Address;
        public Person Person => MainContactViewModel.Person;

        #endregion

        #region Methods

        private void Cancel()
        {
            App.MainWindowViewModel.ChangeUserControlViewModel(null);
        }

        #endregion
    }
}
