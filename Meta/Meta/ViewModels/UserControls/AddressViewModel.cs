using Flattsware;
using Flattsware.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meta.ViewModels.UserControls
{
    public class AddressViewModel : BindableBase, IUserControlViewModel
    {
        #region Fields

        private Address _address;

        #endregion

        #region Constructors



        #endregion

        #region Properties

        public Address Address { get { return _address; } set { SetProperty(ref _address, value); } }

        #endregion

        #region Methods



        #endregion
    }
}
