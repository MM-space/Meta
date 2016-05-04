using System.Windows.Forms;
using Flattsware;

namespace Meta.Views
{
    public class DefaultViewModel : BindableBase
    {
        #region Fields

        private string _title = $"DefaultViewModel - {Application.ProductName}";

        #endregion

        #region Properties

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}