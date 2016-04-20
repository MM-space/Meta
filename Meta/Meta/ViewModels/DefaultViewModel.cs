using Flattsware;
using Flattsware.Helpers;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meta.ViewModels
{
    public class DefaultViewModel : BindableBase
    {
        #region Fields

        string _title = $"DefaultViewModel - {System.Windows.Forms.Application.ProductName}";

        #endregion

        #region Constructors



        #endregion

        #region Properties

        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }

        #endregion

        #region Methods



        #endregion
    }
}
