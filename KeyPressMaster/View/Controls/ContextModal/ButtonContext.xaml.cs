using KeyPressMaster.Controllers;
using KeyPressMaster.Model;
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

    public partial class ButtonContext : UserControl
    {

        public static readonly DependencyProperty ButtonProperty = DependencyProperty.Register("Button", typeof(ExtendButton), typeof(ButtonContext), new PropertyMetadata(null));
        public ExtendButton Button
        {
            get { return (ExtendButton)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        public static readonly DependencyProperty IsOpenedProperty = DependencyProperty.Register("IsOpened", typeof(bool), typeof(ButtonContext), new PropertyMetadata(false));
        public bool IsOpened
        {
            get { return (bool)GetValue(IsOpenedProperty); }
            set { SetValue(IsOpenedProperty, value); }
        }

        public static readonly DependencyProperty ModalContentProperty = DependencyProperty.Register("ModalContent", typeof(object), typeof(ButtonContext), new PropertyMetadata(null));
        public object ModalContent
        {
            get { return (object)GetValue(ModalContentProperty); }
            set { SetValue(ModalContentProperty, value); }
        }

        public static readonly DependencyProperty ModalCoordinateXProperty = DependencyProperty.Register("ModalCoordinateX", typeof(double), typeof(ButtonContext), new PropertyMetadata((double)0));
        public double ModalCoordinateX
        {
            get { return (double)GetValue(ModalCoordinateXProperty); }
            set { SetValue(ModalCoordinateXProperty, value); }
        }

        public static readonly DependencyProperty ModalCoordinateYProperty = DependencyProperty.Register("ModalCoordinateY", typeof(double), typeof(ButtonContext), new PropertyMetadata((double)0));
        public double ModalCoordinateY
        {
            get { return (double)GetValue(ModalCoordinateYProperty); }
            set { SetValue(ModalCoordinateYProperty, value); }
        }

        public static readonly DependencyProperty AnimationPointProperty = DependencyProperty.Register("AnimationPoint", typeof(Point), typeof(ButtonContext), new PropertyMetadata(new Point(1, 0)));
        public Point AnimationPoint
        {
            get { return (Point)GetValue(AnimationPointProperty); }
            set { SetValue(AnimationPointProperty, value); }
        }



        Brush defaultBackground;
        Brush activeBackground;

        public ButtonContext()
        {
            InitializeComponent();
            AppController.instance.ContextModal.Closed += ContextModal_Closed;
        }

        private void ContextModal_Closed(object? sender, EventArgs e)
        {
            Button.Background = defaultBackground;
            IsOpened = false;
        }

        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {
            Button.Click += ButtonClick;
            defaultBackground = Button.Background;
            activeBackground = Button.BackgroundHover;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            IsOpened = !IsOpened;

            Button.Background = IsOpened ? activeBackground : defaultBackground;

            if(IsOpened)
            {
                AppController.instance.ContextModal.Open(new ContextModalParams
                {
                    X = ModalCoordinateX, 
                    Y = ModalCoordinateY,
                    Content = ModalContent,
                    RenderTransformOrigin = AnimationPoint
                });
            }
            else
            {
                AppController.instance.ContextModal.Close();
            }
        }
    }
}
