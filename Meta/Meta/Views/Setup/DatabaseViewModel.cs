using System.Windows;
using System.Windows.Input;
using Flattsware;
using Flattsware.Helpers;
using Meta.Properties;

namespace Meta.Views.Setup
{
    public class DatabaseViewModel : BindableBase, IPageViewModel
    {
        #region Fields

        private ICommand _updateDetailsCommand;
        private Database _database;

        #endregion

        #region Constructors

        public DatabaseViewModel()
        {
            GetDatabase();
        }

        public DatabaseViewModel(int ordinal)
        {
            Label = GetType().Name.Replace("ViewModel", string.Empty);
            HotKeyLabel = $"Ctrl-{ordinal}";

            GetDatabase();
        }

        #endregion

        #region Properties

        public ICommand UpdateDetailsCommand
            => _updateDetailsCommand ?? (_updateDetailsCommand = new DelegateCommand(UpdateDetails));

        public Database Database
        {
            get { return _database; }
            set { SetProperty(ref _database, value); }
        }

        public string Label { get; set; }
        public string HotKeyLabel { get; set; }

        #endregion

        #region Methods

        public virtual void UpdateDetails()
        {
            if (Database.IsValid() == false)
            {
                Dialog.ShowDefaultErrorMessage("Input is not valid.");
                return;
            }

            SaveDatabaseToSettings();

            Dialog.ShowInformation("Database information saved. Meta will now close.");

            Application.Current.Shutdown();
        }

        public void GetDatabase()
        {
            Database database;

            if (TryParseDatabaseFromSettings(out database))
            {
                Database = database;
            }
            else
            {
                Database = NHibernateHelper.CurrentDatabase.IsValid() ? NHibernateHelper.CurrentDatabase : new Database();

                SaveDatabaseToSettings();
            }
        }

        public bool TryParseDatabaseFromSettings(out Database database)
        {
            var properties = Settings.Default;

            if (properties.ServerIP.IsNullOrEmpty())
            {
                database = null;
                return false;
            }
            database = new Database(
                properties.ServerIP,
                properties.DatabaseName,
                properties.DatabasePassword,
                properties.DatabaseUserID
                );

            return true;
        }

        public void SaveDatabaseToSettings()
        {
            var properties = Settings.Default;

            properties.ServerIP = Database.ServerIp;
            properties.DatabaseName = Database.Name;
            properties.DatabasePassword = Database.Password;
            properties.DatabaseUserID = Database.UserID;

            properties.Save();
        }

        #endregion
    }
}