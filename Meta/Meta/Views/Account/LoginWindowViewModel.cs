using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using Flattsware;
using Flattsware.Helpers;
using Meta.Properties;

namespace Meta.Views.Account
{
    public class LoginWindowViewModel : BindableBase
    {
        #region Constructors

        public LoginWindowViewModel()
        {
            User = GetUserFromSettings();
        }

        #endregion

        #region Fields

        private ICommand _logInCommand;
        private ICommand _forgotPasswordCommand;
        private ICommand _createAccountCommand;
        private ICommand _showDatabaseDetailsCommand;
        private string _title = $"Login - {Application.ProductName}";
        private User _user;
        private string _password;

        private Dictionary<string, User> _users = IsDatabaseConnectionAvailable()
            ? User.GetDictionary()
            : new Dictionary<string, User>();

        #endregion

        #region Properties

        public ICommand LogInCommand => _logInCommand ?? (_logInCommand = new DelegateCommand(Login));

        public ICommand ForgotPasswordCommand
            => _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(ForgotPassword));

        public ICommand CreateAccountCommand
            => _createAccountCommand ?? (_createAccountCommand = new DelegateCommand(CreateAccount));

        public ICommand ShowDatabaseDetailsCommand
            =>
                _showDatabaseDetailsCommand ??
                (_showDatabaseDetailsCommand = new DelegateCommand(ShowDatabaseDetails));

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public User User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public Dictionary<string, User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        #endregion

        #region Methods

        private void Login()
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
            var hashedPassword = Passwords.HashString(Password);

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
                var window = new ChangePasswordWindow(User);

                // Return if the window returns false.
                if (window.ShowDialog() == false)
                {
                    return;
                }
            }

            // Save the user in the app settings.
            Settings.Default.LastUser = User.ToString();
            Settings.Default.Save();

            // Show the main window.
            var mainWindow = new MainWindow();
            mainWindow.Show();

            CloseAction();
        }

        private void ForgotPassword()
        {
            // Show the forgot password window.
            var window = new ForgotPasswordWindow();

            // Return if the window returns false.
            if (window.ShowDialog() == false)
            {
            }
            else
            {
                Users = User.GetDictionary();
            }
        }

        private void CreateAccount()
        {
            // Show the create account window.
            var window = new CreateAccountWindow();

            // Return if the window returns false.
            if (window.ShowDialog() == false)
            {
            }
            else
            {
                Users = User.GetDictionary();
            }
        }

        private void ShowDatabaseDetails()
        {
            var window = new DatabaseDetails();

            window.Show();
            CloseAction();
        }

        private static bool IsDatabaseConnectionAvailable()
        {
            var isAvailable = Databases.IsServerConnected(NHibernateHelper.CurrentDatabase);

            if (isAvailable == false)
            {
                Dialog.ShowDefaultErrorMessage(
                    "There was an error trying to connect to the server using the information provided. Please check your server details.");
            }

            return isAvailable;
        }

        private User GetUserFromSettings()
        {
            User user = null;

            if (Users.IsNotNull())
            {
                Users.TryGetValue(Settings.Default.LastUser, out user);
            }

            return user;
        }

        #endregion
    }
}