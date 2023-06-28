using KeyPressMaster.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyPressMaster.View.Components
{
    public partial class MainPageRouter : UserControl
    {
        public MainPageRouter()
        {
            InitializeComponent();

            AppController.instance.Router.Routed += Router_Routed;
        }

        private void Router_Routed(object? sender, EventArgs e)
        {
            if (sender is null)
            {
                MessageBox.Show("Routed sender is null");
                return;
            }

            try
            {
                Container.Content = sender;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppController.instance.Router.Current is null)
            {
                return;
            }

            try
            {
                Container.Content = AppController.instance.Router.Current;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
