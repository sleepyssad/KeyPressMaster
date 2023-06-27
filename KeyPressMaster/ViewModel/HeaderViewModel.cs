using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace KeyPressMaster.ViewModel
{
    public partial class HeaderViewModel : ObservableObject
    {
        public ICommand CloseCommand { get; set; }

        public HeaderViewModel()
        {
            CloseCommand = new RelayCommand(Close);
        }

        void Close()
        {
            App.Current.MainWindow.Close();
        }
    }
}
