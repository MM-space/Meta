using Flattsware;
using Flattsware.Helpers;
using Meta.ViewModels.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels
{
    public class DatabaseDetailsWindowViewModel : DatabaseViewModel
    {
        #region Fields
        
        ICommand _closeCommand;
        bool? _dialogResult;

        #endregion

        #region Constructors

        public DatabaseDetailsWindowViewModel() : base() { }

        #endregion

        #region Properties

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(() => Close()));
        public virtual bool? DialogResult { get { return _dialogResult; } set { SetProperty(ref _dialogResult, value); } }

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
            var window = new Views.Account.LoginWindow();

            window.Show();
            CloseAction();
        }

        #endregion
    }
}
