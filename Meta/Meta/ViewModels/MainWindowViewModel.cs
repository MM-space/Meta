using Flattsware;
using Flattsware.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Meta.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields

        IPageViewModel _currentPageViewModel;
        IUserControlViewModel _currentUserControlViewModel;
        ICommand _changePageCommand;
        ICommand _changeUserControlCommand;
        ICommand _setupClickCommand;
        ICommand _eventsClickCommand;
        ICommand _tournamentsClickCommand;
        ICommand _itemsClickCommand;
        ICommand _enrollmentClickCommand;
        ICommand _reconciliationClickCommand;
        ICommand _ctrl1ClickCommand;
        ICommand _ctrl2ClickCommand;
        ICommand _ctrl3ClickCommand;
        ICommand _ctrl4ClickCommand;
        ICommand _ctrl5ClickCommand;
        ICommand _ctrl6ClickCommand;
        ICommand _ctrl7ClickCommand;
        ICommand _ctrl8ClickCommand;
        ICommand _ctrl9ClickCommand;
        string _title = $"{System.Windows.Forms.Application.ProductName} - Version {System.Windows.Forms.Application.ProductVersion} - {FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright}";
        List<IPageViewModel> _pageViewModels;

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            App.MainWindowViewModel = this;

            // Set the starting page.
            CurrentPageViewModel = new HomeViewModel();
        }

        #endregion

        #region Properties

        public IPageViewModel CurrentPageViewModel { get { return _currentPageViewModel; } set { SetProperty(ref _currentPageViewModel, value); CurrentUserControlViewModel = null; } }
        public IUserControlViewModel CurrentUserControlViewModel { get { return _currentUserControlViewModel; } set { SetProperty(ref _currentUserControlViewModel, value); } }
        public ICommand ChangePageCommand => _changePageCommand ?? (_changePageCommand = new DelegateCommand<IPageViewModel>(x => ChangePageViewModel(x), x => x is IPageViewModel));
        public ICommand ChangeUserControlCommand => _changeUserControlCommand ?? (_changeUserControlCommand = new DelegateCommand<IUserControlViewModel>(x => ChangeUserControlViewModel(x), x => x is IUserControlViewModel));
        public ICommand SetupClickCommand => _setupClickCommand ?? (_setupClickCommand = new DelegateCommand(() => SetupClick()));
        public ICommand EventsClickCommand => _eventsClickCommand ?? (_eventsClickCommand = new DelegateCommand(() => EventsClick()));
        public ICommand TournamentsClickCommand => _tournamentsClickCommand ?? (_tournamentsClickCommand = new DelegateCommand(() => TournamentsClick()));
        public ICommand ItemsClickCommand => _itemsClickCommand ?? (_itemsClickCommand = new DelegateCommand(() => ItemsClick()));
        public ICommand EnrollmentClickCommand => _enrollmentClickCommand ?? (_enrollmentClickCommand = new DelegateCommand(() => EnrollmentClick()));
        public ICommand ReconciliationClickCommand => _reconciliationClickCommand ?? (_reconciliationClickCommand = new DelegateCommand(() => ReconciliationClick()));
        public ICommand Ctrl1ClickCommand => _ctrl1ClickCommand ?? (_ctrl1ClickCommand = new DelegateCommand(() => Ctrl1Click()));
        public ICommand Ctrl2ClickCommand => _ctrl2ClickCommand ?? (_ctrl2ClickCommand = new DelegateCommand(() => Ctrl2Click()));
        public ICommand Ctrl3ClickCommand => _ctrl3ClickCommand ?? (_ctrl3ClickCommand = new DelegateCommand(() => Ctrl3Click()));
        public ICommand Ctrl4ClickCommand => _ctrl4ClickCommand ?? (_ctrl4ClickCommand = new DelegateCommand(() => Ctrl4Click()));
        public ICommand Ctrl5ClickCommand => _ctrl5ClickCommand ?? (_ctrl5ClickCommand = new DelegateCommand(() => Ctrl5Click()));
        public ICommand Ctrl6ClickCommand => _ctrl6ClickCommand ?? (_ctrl6ClickCommand = new DelegateCommand(() => Ctrl6Click()));
        public ICommand Ctrl7ClickCommand => _ctrl7ClickCommand ?? (_ctrl7ClickCommand = new DelegateCommand(() => Ctrl7Click()));
        public ICommand Ctrl8ClickCommand => _ctrl8ClickCommand ?? (_ctrl8ClickCommand = new DelegateCommand(() => Ctrl8Click()));
        public ICommand Ctrl9ClickCommand => _ctrl9ClickCommand ?? (_ctrl9ClickCommand = new DelegateCommand(() => Ctrl9Click()));
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }
        public string WelcomeString => $"Welcome, {App.CurrentUser.GivenName}!";
        public List<IPageViewModel> PageViewModels { get { return _pageViewModels; } set { SetProperty(ref _pageViewModels, value); CurrentUserControlViewModel = null; } } 

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

        void SetupClick()
        {
            var viewModels = new List<IPageViewModel>();

            viewModels.Add(new Setup.AccountViewModel(1, App.CurrentUser));
            viewModels.Add(new Setup.DatabaseViewModel(2));
            viewModels.Add(new Setup.LedgerViewModel(3));
            if (App.CurrentUser.IsSuperUser) { viewModels.Add(new Setup.AdminViewModel(4)); }

            PageViewModels = viewModels;
        }

        void EventsClick()
        {
            PageViewModels = new List<IPageViewModel>()
            {

            };
        }

        void TournamentsClick()
        {
            PageViewModels = new List<IPageViewModel>()
            {

            };
        }

        void ItemsClick()
        {
            PageViewModels = new List<IPageViewModel>()
            {

            };
        }

        void EnrollmentClick()
        {
            PageViewModels = new List<IPageViewModel>()
            {

            };
        }

        void ReconciliationClick()
        {
            PageViewModels = new List<IPageViewModel>()
            {

            };
        }

        void Ctrl1Click()
        {
            int page = 1;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl2Click()
        {
            int page = 2;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl3Click()
        {
            int page = 3;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl4Click()
        {
            int page = 4;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl5Click()
        {
            int page = 5;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl6Click()
        {
            int page = 6;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl7Click()
        {
            int page = 7;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl8Click()
        {
            int page = 8;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        void Ctrl9Click()
        {
            int page = 9;

            if (PageViewModels.IsNotNull() && PageViewModels.Count >= page)
            {
                ChangePageViewModel(PageViewModels[page - 1]);
            }
        }

        #endregion
    }
}
