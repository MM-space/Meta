using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meta.ViewModels
{
    public class HomeViewModel : IPageViewModel
    {
        public string Label { get; set; } = "Home";
        public string HotKeyLabel { get; set; } = "";
    }
}
