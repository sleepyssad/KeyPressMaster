using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KeyPressMaster.Model.Enums;
using KeyPressMaster.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeyPressMaster.ViewModel
{
    public partial class MoreContentViewModel : ObservableObject
    {
        [ObservableProperty]
        AppTheme theme;

        [ObservableProperty]
        bool autoRun;

        public ICommand ThemeChangeCommand { get; set; }

        public ICommand AutoRunSwitchCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public MoreContentViewModel()
        {
            ThemeChangeCommand = new RelayCommand<AppTheme>(ThemeChange);
            AutoRunSwitchCommand = new RelayCommand<bool>(AutoRunSwitch);
            ExitCommand = new RelayCommand(Exit);

            Theme = Storage.Default.CurrentTheme;
            AutoRun = Storage.Default.AutoRun;

            ThemeManager.Changed += ThemeManager_ThemeChanged;
        }

        private void ThemeManager_ThemeChanged(object? sender, EventArgs e)
        {
            if (sender is AppTheme newTheme)
            {
                Theme = newTheme;
            }
        }

        void ThemeChange(AppTheme newTheme)
        {
            ThemeManager.Update(newTheme);
        }

        void AutoRunSwitch(bool state)
        {
            Storage.Default.AutoRun = state;
        }

        void Exit()
        {
            App.Current.MainWindow.Close();
        }
    }
}
