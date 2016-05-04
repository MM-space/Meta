using System.Collections.Generic;
using System.Windows.Input;
using Flattsware;
using Flattsware.Helpers;

namespace Meta.Views.Account
{
    public class ForgotPasswordViewModel : BindableBase
    {
        #region Methods

        private void SendEmail()
        {
            // Null check.
            if (User.IsNull())
            {
                Dialog.ShowDefaultErrorMessage("Please select a username.");
                return;
            }

            DialogResult = User.SendNewPassword();
        }

        #endregion

        #region Fields

        private ICommand _sendEmailCommand;
        private bool? _dialogResult;
        private User _user;
        private Dictionary<string, User> _users = User.GetDictionary();

        #endregion

        #region Constructors

        #endregion

        #region Properties

        public ICommand SendEmailCommand
            => _sendEmailCommand ?? (_sendEmailCommand = new DelegateCommand(SendEmail));

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

        public Dictionary<string, User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        #endregion
    }
}