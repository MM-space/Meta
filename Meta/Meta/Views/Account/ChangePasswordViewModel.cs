using System.Windows.Input;
using Flattsware;

namespace Meta.Views.Account
{
    public class ChangePasswordViewModel : BindableBase
    {
        #region Methods

        private void Save()
        {
            User.Password = Password;
            User.PasswordAgain = PasswordAgain;

            if (User.UpdatePassword())
            {
                DialogResult = true;
            }
        }

        #endregion

        #region Fields

        private ICommand _saveCommand;
        private bool? _dialogResult;
        private User _user;
        private string _password;
        private string _passwordAgain;

        #endregion

        #region Constructors

        #endregion

        #region Properties

        public virtual ICommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(() => Save()));

        public virtual bool? DialogResult
        {
            get { return _dialogResult; }
            set { SetProperty(ref _dialogResult, value); }
        }

        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public virtual string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public virtual string PasswordAgain
        {
            get { return _passwordAgain; }
            set { SetProperty(ref _passwordAgain, value); }
        }

        #endregion
    }
}