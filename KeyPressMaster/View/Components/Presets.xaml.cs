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
    /// <summary>
    /// Interaction logic for Presets.xaml
    /// </summary>
    public partial class Presets : UserControl
    {
        public Presets()
        {
            InitializeComponent();
        }

        private void ExtendButton_Click(object sender, RoutedEventArgs e)
        {
            AppController.instance.Router.Route(new Header());
        }
    }
}
