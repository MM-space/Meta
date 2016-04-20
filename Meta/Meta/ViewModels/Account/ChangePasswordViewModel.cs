using Flattsware;
using Flattsware.Helpers;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels.Account
{
    public class ChangePasswordViewModel : BindableBase
    {
        #region Fields

        ICommand _saveCommand;
        bool? _dialogResult;
        User _user;
        string _password;
        string _passwordAgain;

        #endregion

        #region Constructors



        #endregion

        #region Properties

        public virtual ICommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(() => Save()));        
        public virtual bool? DialogResult { get { return _dialogResult; } set { SetProperty(ref _dialogResult, value); } }
        public User User { get { return _user; } set { SetProperty(ref _user, value); } }
        public virtual string Password { get { return _password; } set { SetProperty(ref _password, value); } }
        public virtual string PasswordAgain { get { return _passwordAgain; } set { SetProperty(ref _passwordAgain, value); } }

        #endregion

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
    }
}
