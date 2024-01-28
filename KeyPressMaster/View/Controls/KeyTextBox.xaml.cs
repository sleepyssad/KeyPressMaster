using Gma.System.MouseKeyHook;
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

namespace KeyPressMaster.View.Controls
{
    public partial class KeyTextBox : UserControl
    {
        private IKeyboardMouseEvents globalMouseHook;

        private bool isActive = false;

        public KeyTextBox()
        {
            InitializeComponent();
            this.Loaded += KeyTextBox_Loaded;
            this.Unloaded += KeyTextBox_Unloaded;
            AppController.instance.KeyboardDetector.KeyDetected += KeyboardDetector_KeyDetected1;
        }

  

        private void KeyTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            SetStatus(false);
            globalMouseHook = Hook.GlobalEvents();
            globalMouseHook.MouseDownExt += GlobalMouseHook_MouseDownExt;
        }

        private void KeyTextBox_Unloaded(object sender, RoutedEventArgs e)
        {
            globalMouseHook.MouseDownExt -= GlobalMouseHook_MouseDownExt;
            globalMouseHook.Dispose();
        }

        private void GlobalMouseHook_MouseDownExt(object sender, MouseEventExtArgs e)
        {
          
            Point clickPoint = PointFromScreen(new Point(e.X, e.Y));

          
            if (clickPoint.X < 0 || clickPoint.Y < 0 || clickPoint.X >= ActualWidth || clickPoint.Y >= ActualHeight)
            {
                SetStatus(false);
            }
        }

        private void KeyboardDetector_KeyDetected1(object? sender, System.Windows.Forms.Keys e)
        {
            if (isActive)
            {
                KeyName.Text = Enum.GetName(typeof(System.Windows.Forms.Keys), e);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetStatus(true);
        }

        private void SetStatus(bool active)
        {
            Form.IsEnabled = active;
            KeyName.IsEnabled = active;
            isActive = active;
        }
    }
}
