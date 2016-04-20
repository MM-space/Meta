using Flattsware;
using Flattsware.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels.UserControls
{
    public class FindPersonViewModel : BindableBase, IUserControlViewModel
    {
        #region Fields

        private ICommand _lookupCommand;
        private string _input;
        private Person _person;

        #endregion

        #region Constructors



        #endregion

        #region Properties

        public ICommand LookupCommand => _lookupCommand ?? (_lookupCommand = new DelegateCommand<string>(x => Lookup(x), x => x is string));
        public string Input { get { return _input; } set { SetProperty(ref _input, value); } }
        public Person Person { get { return _person; } set { SetProperty(ref _person, value); } }

        #endregion

        #region Methods

        private void Lookup(string input)
        {
            Person person;

            if (Person.TryLookup(input, out person) == false)
            {
                Dialog.ShowDefaultErrorMessage("Lookup returned no results.");
            }

            Person = person;
        }

        #endregion
    }
}
