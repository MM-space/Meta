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
    public class LoginWindowViewModel : BindableBase
    {
        #region Fields

        ICommand _logInCommand;
        ICommand _forgotPasswordCommand;
        ICommand _createAccountCommand;
        ICommand _showDatabaseDetailsCommand;
        string _title = $"Login - {System.Windows.Forms.Application.ProductName}";
        User _user;
        string _password;
        Dictionary<string, User> _users = IsDatabaseConnectionAvailable() ? User.GetDictionary() : new Dictionary<string, User>();

        #endregion

        #region Constructors

        public LoginWindowViewModel()
        {
            User = GetUserFromSettings();
        }

        #endregion

        #region Properties

        public ICommand LogInCommand => _logInCommand ?? (_logInCommand = new DelegateCommand(() => Login()));
        public ICommand ForgotPasswordCommand => _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(() => ForgotPassword()));
        public ICommand CreateAccountCommand => _createAccountCommand ?? (_createAccountCommand = new DelegateCommand(() => CreateAccount()));
        public ICommand ShowDatabaseDetailsCommand => _showDatabaseDetailsCommand ?? (_showDatabaseDetailsCommand = new DelegateCommand(() => ShowDatabaseDetails()));
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }
        public User User { get { return _user; } set { SetProperty(ref _user, value); } }
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }
        public Dictionary<string, User> Users { get { return _users; } set { SetProperty(ref _users, value); } }

        #endregion

        #region Methods

        void Login()
        {
            // Null check.
            if (User.IsNull())
            {
                Dialog.ShowDefaultErrorMessage("Please select a valid username before trying to log in.");
                return;
            }

            if (Password.IsNullOrEmpty())
            {
                Dialog.ShowDefaultErrorMessage("Please enter a password before trying to log in.");
                return;
            }

            // Hash the password.
            string hashedPassword = Passwords.HashString(Password);

            // Validate the password.
            if (User.PasswordHashed != hashedPassword)
            {
                Dialog.ShowDefaultErrorMessage("You entered an incorrect password.");
                return;
            }

            // Set the current user and current events.
            App.CurrentUser = User;
            App.CurrentEvent = Event.GetCurrentOrNextEvent();

            // If a password change is required, show the change password form.
            if (User.IsPasswordResetRequired)
            {
                // Force the user to change their password.
                var window = new Views.Account.ChangePasswordWindow(User);

                // Return if the window returns false.
                if (window.ShowDialog() == false) { return; };
            }

            // Save the user in the app settings.
            Properties.Settings.Default.LastUser = User.ToString();
            Properties.Settings.Default.Save();

            // Show the main window.
            var mainWindow = new Views.MainWindow();
            mainWindow.Show();

            CloseAction();
        }

        void ForgotPassword()
        {
            // Show the forgot password window.
            var window = new Views.Account.ForgotPasswordWindow();

            // Return if the window returns false.
            if (window.ShowDialog() == false)
            {
                return;
            }
            else
            {
                Users = User.GetDictionary();
            }
        }

        void CreateAccount()
        {
            // Show the create account window.
            var window = new Views.Account.CreateAccountWindow();

            // Return if the window returns false.
            if (window.ShowDialog() == false)
            {
                return;
            }
            else
            {
                Users = User.GetDictionary();
            }
        }

        void ShowDatabaseDetails()
        {
            var window = new Views.DatabaseDetails();

            window.Show();
            CloseAction();
        }

        static bool IsDatabaseConnectionAvailable()
        {
            bool isAvailable = Databases.IsServerConnected(NHibernateHelper.CurrentDatabase);

            if (isAvailable == false)
            {
                Dialog.ShowDefaultErrorMessage("There was an error trying to connect to the server using the information provided. Please check your server details.");
            }

            return isAvailable;
        }

        User GetUserFromSettings()
        {
            User user = null;

            if (Users.IsNotNull())
            { 
                Users.TryGetValue(Properties.Settings.Default.LastUser, out user);         
            }

            return user;
        }

        #endregion
    }
}
