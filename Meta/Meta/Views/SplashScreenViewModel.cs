using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flattsware;
using Meta.Properties;
using Meta.Views.Account;

namespace Meta.Views
{
    public class SplashScreenViewModel : BindableBase
    {
        #region Fields

        private string _title =
            $"{Application.ProductName} - Version {Application.ProductVersion} - Jason Flatford {DateTime.Now.Year}";

        private string _text = "Initializing...";

        #endregion

        #region Properties

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        #endregion

        #region Methods

        public async Task<bool> OnLoad()
        {
            // Setup the database connection using settings.
            var database = GetDatabaseFromSettings();
            NHibernateHelper.CurrentDatabase = database.IsValid() ? database : new Database();

            //TODO: Check for updates.

            //TODO: Load any pre-loaded pages.

            //TODO: Load any pre-loaded information.

            await Task.Delay(1000); //TODO: Remove.

            // Show the login window.
            var form = new LoginWindow();
            form.Show();

            return true;
        }

        public Database GetDatabaseFromSettings()
        {
            var properties = Settings.Default;

            return new Database(
                properties.ServerIP,
                properties.DatabaseName,
                properties.DatabasePassword,
                properties.DatabaseUserID
                );
        }

        #endregion
    }
}