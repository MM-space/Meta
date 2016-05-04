using System.Windows.Input;
using Flattsware;

namespace Meta.Views.Setup
{
    public class LedgerViewModel : BindableBase, IPageViewModel
    {
        #region Fields

        private ICommand _createNewLedgerCommand;
        private ICommand _reconcileLedgerCommand;
        private Ledger _ledger;

        #endregion

        #region Constructors

        public LedgerViewModel()
        {
        }

        public LedgerViewModel(int ordinal)
        {
            Label = GetType().Name.Replace("ViewModel", string.Empty);
            HotKeyLabel = $"Ctrl-{ordinal}";
        }

        #endregion

        #region Properties

        public ICommand CreateNewLedgerCommand
            => _createNewLedgerCommand ?? (_createNewLedgerCommand = new DelegateCommand(CreateLedger));

        public ICommand ReconcileLedgerCommand
            => _reconcileLedgerCommand ?? (_reconcileLedgerCommand = new DelegateCommand(ReconcileLedger));

        public Event Event => App.CurrentEvent;
        //TODO: Make dynamic.
        public Ledger Ledger
        {
            get { return _ledger; }
            set { SetProperty(ref _ledger, value); }
        }

        public string Label { get; set; }
        public string HotKeyLabel { get; set; }

        #endregion

        #region Methods

        private void CreateLedger()
        {
            Ledger = new Ledger(Enums.LedgerStatuses.Open, 0, App.CurrentUser, new Event {Name = "Test Event"});
        }

        private void ReconcileLedger()
        {
            Ledger = null;
        }

        #endregion
    }
}