using System;
using System.ComponentModel;
using System.Windows.Controls;
using Flattsware;

namespace Meta.Views.UserControls
{
    /// <summary>
    ///     Interaction logic for ViewObjectsView.xaml
    /// </summary>
    public partial class ViewObjectsView : UserControl
    {
        public ViewObjectsView()
        {
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var attri = new Editable();
            if (((PropertyDescriptor) e.PropertyDescriptor).Attributes.Contains(attri) == false) e.Cancel = true;
        }
    }
}