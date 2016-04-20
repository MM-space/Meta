using Flattsware;
using Flattsware.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels.Account
{
    public class ForgotPasswordViewModel : BindableBase
    {
        #region Fields

        ICommand _sendEmailCommand;
        bool? _dialogResult;
        User _user;
        Dictionary<string, User> _users = User.GetDictionary();        

        #endregion

        #region Constructors



        #endregion

        #region Properties

        public ICommand SendEmailCommand => _sendEmailCommand ?? (_sendEmailCommand = new DelegateCommand(() => SendEmail()));
        public virtual bool? DialogResult { get { return _dialogResult; } set { SetProperty(ref _dialogResult, value); } }
        public User User { get { return _user; } set { SetProperty(ref _user, value); } }
        public Dictionary<string, User> Users { get { return _users; } set { SetProperty(ref _users, value); } }

        #endregion

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
    }
}
