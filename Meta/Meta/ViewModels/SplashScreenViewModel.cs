using Flattsware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Meta.ViewModels
{
    public class SplashScreenViewModel : BindableBase
    {
        #region Fields

        string _title = $"{System.Windows.Forms.Application.ProductName} - Version {System.Windows.Forms.Application.ProductVersion} - Jason Flatford {DateTime.Now.Year}";
        string _text = "Initializing...";

        #endregion

        #region Properties

        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }
        public string Text { get { return _text; } set { SetProperty(ref _text, value); } }

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

            await Task.Delay(2000);

            // Show the login window.
            var form = new Views.Account.LoginWindow();
            form.Show();

            return true;
        }

        public Database GetDatabaseFromSettings()
        {
            var properties = Properties.Settings.Default;

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
