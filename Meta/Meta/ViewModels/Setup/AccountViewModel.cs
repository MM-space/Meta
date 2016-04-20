using Flattsware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels.Setup
{
    public class AccountViewModel : BindableBase, IPageViewModel
    {
        #region Fields

        ICommand _updatePasswordCommand;
        ICommand _updateDetailsCommand;
        User _user;

        #endregion

        #region Constructors

        public AccountViewModel() { }

        public AccountViewModel(int ordinal, User user)
        {
            User = user;
            Label = GetType().Name.Replace("ViewModel", string.Empty);
            HotKeyLabel = $"Ctrl-{ordinal}";
        }

        #endregion

        #region Properties

        public virtual ICommand UpdatePasswordCommand => _updatePasswordCommand ?? (_updatePasswordCommand = new DelegateCommand(() => UpdatePassword()));
        public virtual ICommand UpdateDetailsCommand => _updateDetailsCommand ?? (_updateDetailsCommand = new DelegateCommand(() => UpdateDetails()));
        public User User { get { return _user; } set { SetProperty(ref _user, value); } }
        public string Label { get; set; }
        public string HotKeyLabel { get; set; }

        #endregion

        #region Methods

        void UpdatePassword()
        {
            User.UpdatePassword();
        }

        void UpdateDetails()
        {
            User.UpdateDetails();

            App.CurrentUser = User;
        }

        #endregion
    }
}
