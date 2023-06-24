using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressMaster.ViewModel
{
    public partial class HeaderViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        public HeaderViewModel()
        {
            name = "hello";
        }
    }
}
