using KeyPressMaster.Controllers;
using KeyPressMaster.Model;
using KeyPressMaster.Resources;
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

        public static readonly DependencyProperty ModalPointProperty = DependencyProperty.Register("ModalPoint", typeof(Point), typeof(ButtonContext), new PropertyMetadata(new Point(0, 0)));
        public Point ModalPoint
        {
            get { return (Point)GetValue(ModalPointProperty); }
            set { SetValue(ModalPointProperty, value); }
        }

        public static readonly DependencyProperty AnimationPointProperty = DependencyProperty.Register("AnimationPoint", typeof(Point), typeof(ButtonContext), new PropertyMetadata(new Point(1, 0)));
        public Point AnimationPoint
        {
            get { return (Point)GetValue(AnimationPointProperty); }
            set { SetValue(AnimationPointProperty, value); }
        }

        public static readonly DependencyProperty ModalVerticalAlignmentProperty = DependencyProperty.Register("ModalVerticalAlignment", typeof(VerticalAlignment), typeof(ButtonContext), new PropertyMetadata(VerticalAlignment.Top));
        public VerticalAlignment ModalVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(ModalVerticalAlignmentProperty); }
            set { SetValue(ModalVerticalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty ModalHorizontalAlignmentProperty = DependencyProperty.Register("ModalHorizontalAlignment", typeof(HorizontalAlignment), typeof(ButtonContext), new PropertyMetadata(HorizontalAlignment.Left));
        public HorizontalAlignment ModalHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(ModalHorizontalAlignmentProperty); }
            set { SetValue(ModalHorizontalAlignmentProperty, value); }
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
            ThemeManager.Changed += ThemeManager_Changed;
        }

        private void ThemeManager_Changed(object? sender, EventArgs e)
        {
            if (IsOpened)
            {
                Button.Background = Button.BackgroundHover; 
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            defaultBackground = Button.Background;
            activeBackground = Button.BackgroundHover;

            IsOpened = !IsOpened;

            Button.Background = IsOpened ? activeBackground : defaultBackground;

            if (IsOpened)
            {
                AppController.instance.ContextModal.Open(new ContextModalParams
                {
                    X = ModalPoint.X,
                    Y = ModalPoint.Y,
                    Content = ModalContent,
                    RenderTransformOrigin = AnimationPoint,
                    VerticalAlignment = ModalVerticalAlignment,
                    HorizontalAlignment = ModalHorizontalAlignment,
                });
            }
            else
            {
                AppController.instance.ContextModal.Close();
            }
        }
    }
}
