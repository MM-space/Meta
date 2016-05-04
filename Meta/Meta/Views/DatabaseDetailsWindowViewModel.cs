using System.Windows.Input;
using Flattsware;
using Flattsware.Helpers;
using Meta.Views.Account;
using Meta.Views.Setup;

namespace Meta.Views
{
    public class DatabaseDetailsWindowViewModel : DatabaseViewModel
    {
        #region Constructors

        #endregion

        #region Fields

        private ICommand _closeCommand;
        private bool? _dialogResult;

        #endregion

        #region Properties

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(Close));

        public virtual bool? DialogResult
        {
            get { return _dialogResult; }
            set { SetProperty(ref _dialogResult, value); }
        }

        #endregion

        #region Methods

        public override void UpdateDetails()
        {
            if (Database.IsValid() == false)
            {
                Dialog.ShowDefaultErrorMessage("Input is not valid.");
                return;
            }

            SaveDatabaseToSettings();
            NHibernateHelper.CurrentDatabase = Database;

            Dialog.ShowInformation("Database information saved.");

            Close();
        }

        public void Close()
        {
            var window = new LoginWindow();

            window.Show();
            CloseAction();
        }

        #endregion
    }
}