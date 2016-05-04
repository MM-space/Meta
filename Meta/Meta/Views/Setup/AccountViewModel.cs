using System.Windows.Input;
using Flattsware;

namespace Meta.Views.Setup
{
    public class AccountViewModel : BindableBase, IPageViewModel
    {
        #region Fields

        private ICommand _updatePasswordCommand;
        private ICommand _updateDetailsCommand;
        private User _user;

        #endregion

        #region Constructors

        public AccountViewModel()
        {
        }

        public AccountViewModel(int ordinal, User user)
        {
            User = user;
            Label = GetType().Name.Replace("ViewModel", string.Empty);
            HotKeyLabel = $"Ctrl-{ordinal}";
        }

        #endregion

        #region Properties

        public virtual ICommand UpdatePasswordCommand
            => _updatePasswordCommand ?? (_updatePasswordCommand = new DelegateCommand(UpdatePassword));

        public virtual ICommand UpdateDetailsCommand
            => _updateDetailsCommand ?? (_updateDetailsCommand = new DelegateCommand(UpdateDetails));

        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public string Label { get; set; }
        public string HotKeyLabel { get; set; }

        #endregion

        #region Methods

        private void UpdatePassword()
        {
            User.UpdatePassword();
        }

        private void UpdateDetails()
        {
            User.UpdateDetails();

            App.CurrentUser = User;
        }

        #endregion
    }
}