using KeyPressMaster.Controllers;
using KeyPressMaster.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Runtime.InteropServices;

namespace KeyPressMaster.View.Controls
{
    public partial class ContextModalForm : UserControl
    {
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public ContextModalForm()
        {
            InitializeComponent();

            AppController.instance.ContextModal.Opened += ContextModalOpened;
            AppController.instance.ContextModal.Closed += ContextModalClosed;
        }

        private void ContextModalOpened(object? sender, EventArgs e)
        {
            MainForm.Visibility = Visibility.Visible;

            if (sender is ContextModalParams param)
            {
                ModalBorder.VerticalAlignment = param.VerticalAlignment;
                ModalBorder.HorizontalAlignment = param.HorizontalAlignment;

                var thickness = new Thickness();
                
                switch (param.VerticalAlignment)
                {
                    case VerticalAlignment.Top: thickness.Top = param.Y; break;
                    case VerticalAlignment.Bottom: thickness.Bottom = param.Y; break;
                }

                switch (param.HorizontalAlignment)
                {
                    case HorizontalAlignment.Left: thickness.Left = param.X; break;
                    case HorizontalAlignment.Right: thickness.Right = param.X; break;
                }

                ModalBorder.Margin = thickness;

                ModalContent.Content = param.Content;
                ModalBorder.RenderTransformOrigin = param.RenderTransformOrigin;

                ShowStoryboard_BeginStoryboard.Storyboard.Begin();
              
            }
        }

        private void ContextModalClosed(object? sender, EventArgs e)
        {
            MainForm.Visibility = Visibility.Collapsed;
        }

        private void BackMouseDown(object sender, MouseButtonEventArgs e)
        {
            AppController.instance.ContextModal.Close();

            if (e.GetPosition(this).Y <= 65)
            {
                if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                {
                    IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(App.Current.MainWindow).Handle;
                    SendMessage(hwnd, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
                }
            }
        }
    }
}
