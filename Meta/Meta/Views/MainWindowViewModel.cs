using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Input;
using Flattsware;
using Meta.Views.Setup;

namespace Meta.Views
{
    public class MainWindowViewModel : BindableBase
    {
        #region Constructors

        public MainWindowViewModel()
        {
            App.MainWindowViewModel = this;

            // Set the starting page.
            CurrentPageViewModel = new HomeViewModel();
        }

        #endregion

        #region Fields

        private IPageViewModel _currentPageViewModel;
        private IUserControlViewModel _currentUserControlViewModel;
        private ICommand _changePageCommand;
        private ICommand _changeUserControlCommand;
        private ICommand _setupClickCommand;
        private ICommand _eventsClickCommand;
        private ICommand _tournamentsClickCommand;
        private ICommand _itemsClickCommand;
        private ICommand _enrollmentClickCommand;
        private ICommand _reconciliationClickCommand;
        private ICommand _ctrl1ClickCommand;
        private ICommand _ctrl2ClickCommand;
        private ICommand _ctrl3ClickCommand;
        private ICommand _ctrl4ClickCommand;
        private ICommand _ctrl5ClickCommand;
        private ICommand _ctrl6ClickCommand;
        private ICommand _ctrl7ClickCommand;
        private ICommand _ctrl8ClickCommand;
        private ICommand _ctrl9ClickCommand;

        private string _title =
            $"{Application.ProductName} - Version {Application.ProductVersion} - {FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright}";

        private List<IPageViewModel> _pageViewModels;

        #endregion

        #region Properties

        public IPageViewModel CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set
            {
                SetProperty(ref _currentPageViewModel, value);
                CurrentUserControlViewModel = null;
            }
        }

        public IUserControlViewModel CurrentUserControlViewModel
        {
            get { return _currentUserControlViewModel; }
            set { SetProperty(ref _currentUserControlViewModel, value); }
        }

        public ICommand ChangePageCommand
            =>
                _changePageCommand ??
                (_changePageCommand =
                    new DelegateCommand<IPageViewModel>(ChangePageViewModel, x => x != null));

        public ICommand ChangeUserControlCommand
            =>
                _changeUserControlCommand ??
                (_changeUserControlCommand =
                    new DelegateCommand<IUserControlViewModel>(ChangeUserControlViewModel, x => x != null));

        public ICommand SetupClickCommand
            => _setupClickCommand ?? (_setupClickCommand = new DelegateCommand(SetupClick));

        public ICommand EventsClickCommand
            => _eventsClickCommand ?? (_eventsClickCommand = new DelegateCommand(EventsClick));

        public ICommand TournamentsClickCommand
            => _tournamentsClickCommand ?? (_tournamentsClickCommand = new DelegateCommand(TournamentsClick));

        public ICommand ItemsClickCommand
            => _itemsClickCommand ?? (_itemsClickCommand = new DelegateCommand(ItemsClick));

        public ICommand EnrollmentClickCommand
            => _enrollmentClickCommand ?? (_enrollmentClickCommand = new DelegateCommand(EnrollmentClick));

        public ICommand ReconciliationClickCommand
            =>
                _reconciliationClickCommand ??
                (_reconciliationClickCommand = new DelegateCommand(ReconciliationClick));

        public ICommand Ctrl1ClickCommand
            => _ctrl1ClickCommand ?? (_ctrl1ClickCommand = new DelegateCommand(Ctrl1Click));

        public ICommand Ctrl2ClickCommand
            => _ctrl2ClickCommand ?? (_ctrl2ClickCommand = new DelegateCommand(Ctrl2Click));

        public ICommand Ctrl3ClickCommand
            => _ctrl3ClickCommand ?? (_ctrl3ClickCommand = new DelegateCommand(Ctrl3Click));

        public ICommand Ctrl4ClickCommand
            => _ctrl4ClickCommand ?? (_ctrl4ClickCommand = new DelegateCommand(Ctrl4Click));

        public ICommand Ctrl5ClickCommand
            => _ctrl5ClickCommand ?? (_ctrl5ClickCommand = new DelegateCommand(Ctrl5Click));

        public ICommand Ctrl6ClickCommand
            => _ctrl6ClickCommand ?? (_ctrl6ClickCommand = new DelegateCommand(Ctrl6Click));

        public ICommand Ctrl7ClickCommand
            => _ctrl7ClickCommand ?? (_ctrl7ClickCommand = new DelegateCommand(Ctrl7Click));

        public ICommand Ctrl8ClickCommand
            => _ctrl8ClickCommand ?? (_ctrl8ClickCommand = new DelegateCommand(Ctrl8Click));

        public ICommand Ctrl9ClickCommand
            => _ctrl9ClickCommand ?? (_ctrl9ClickCommand = new DelegateCommand(Ctrl9Click));

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string WelcomeString => $"Welcome, {App.CurrentUser.First_Name}!";

        public List<IPageViewModel> PageViewModels
        {
            get { return _pageViewModels; }
            set
            {
                SetProperty(ref _pageViewModels, value);
                CurrentUserControlViewModel = null;
            }
        }

        #endregion

        #region Methods

        private void ChangePageViewModel(IPageViewModel viewModel)
        {
            if (PageViewModels.Contains(viewModel) == false)
            {
                PageViewModels.Add(viewModel);
            }

            CurrentPageViewModel = PageViewModels.First(vm => vm == viewModel);
        }

        public void ChangeUserControlViewModel(IUserControlViewModel viewModel)
        {
            CurrentUserControlViewModel = viewModel;
        }

        private void SetupClick()
        {
            var viewModels = new List<IPageViewModel>
            {
                new AccountViewModel(1, App.CurrentUser),
                new DatabaseViewModel(2),
                new LedgerViewModel(3)
            };

            if (App.CurrentUser.IsSuperUser)
            {
                viewModels.Add(new AdminViewModel(4));
            }

            PageViewModels = viewModels;
        }

        private void EventsClick()
        {
            PageViewModels = new List<IPageViewModel>();
        }

        private void TournamentsClick()
        {
            PageViewModels = new List<IPageViewModel>();
        }

        private void ItemsClick()
        {
            PageViewModels = new List<IPageViewModel>();
        }

        private void EnrollmentClick()
        {
            PageViewModels = new List<IPageViewModel>();
        }

        private void ReconciliationClick()
        {
            PageViewModels = new List<IPageViewModel>();
        }

        private void Ctrl1Click()
        {
            const int page = 1;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl2Click()
        {
            const int page = 2;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl3Click()
        {
            const int page = 3;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl4Click()
        {
            const int page = 4;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl5Click()
        {
            const int page = 5;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl6Click()
        {
            const int page = 6;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl7Click()
        {
            const int page = 7;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl8Click()
        {
            const int page = 8;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        private void Ctrl9Click()
        {
            const int page = 9;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        #endregion
    }
}