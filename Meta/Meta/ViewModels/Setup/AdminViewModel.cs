using Flattsware;
using Flattsware.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels.Setup
{
    public class AdminViewModel : BindableBase, IPageViewModel
    {
        #region Fields

        private ICommand _addOrganizerCommand;

        #endregion

        #region Constructors

        public AdminViewModel() { }

        public AdminViewModel(int ordinal)
        {
            Label = GetType().Name.Replace("ViewModel", string.Empty);
            HotKeyLabel = $"Ctrl-{ordinal}";
        }

        #endregion

        #region Properties

        public ICommand AddOrganizerCommand => _addOrganizerCommand ?? (_addOrganizerCommand = new DelegateCommand(() => AddOrganizer()));
        public string Label { get; set; }
        public string HotKeyLabel { get; set; }

        #endregion

        #region Methods

        private void AddOrganizer()
        {
            if (App.MainWindowViewModel.IsNotNull())
            {
                App.MainWindowViewModel.ChangeUserControlViewModel(new UserControls.AddOrganizerViewModel());
            }
        }

        #endregion
    }
}