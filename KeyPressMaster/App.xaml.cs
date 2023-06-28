using KeyPressMaster.Controllers;
using KeyPressMaster.Model.Enums;
using KeyPressMaster.Resources;
using KeyPressMaster.View.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KeyPressMaster
{
    
    public partial class App : Application
    {
        public App() : base()
        {
            App.Current.Startup += Current_Startup;

            AppController.instance.Router.Route(new Presets());
        }

        private void Current_Startup(object sender, StartupEventArgs e)
        {
            // load theme

            if (Storage.Default.CurrentTheme != AppTheme.Blue)
            {
                ThemeManager.Update(Storage.Default.CurrentTheme);
            }
        }
    }
}
