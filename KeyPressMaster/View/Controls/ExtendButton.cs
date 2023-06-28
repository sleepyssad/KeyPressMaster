using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KeyPressMaster.View.Controls
{
    public class ExtendButton : Button
    {
        public static readonly DependencyProperty BackgroundHoverProperty = DependencyProperty.Register("BackgroundHover", typeof(SolidColorBrush), typeof(ExtendButton), new PropertyMetadata(null));
        public SolidColorBrush BackgroundHover
        {
            get { return (SolidColorBrush)GetValue(BackgroundHoverProperty); }
            set { SetValue(BackgroundHoverProperty, value); }
        }

        public static readonly DependencyProperty ForegroundHoverProperty = DependencyProperty.Register("ForegroundHover", typeof(SolidColorBrush), typeof(ExtendButton), new PropertyMetadata(null));
        public SolidColorBrush ForegroundHover
        {
            get { return (SolidColorBrush)GetValue(ForegroundHoverProperty); }
            set { SetValue(ForegroundHoverProperty, value); }
        }

        public static readonly DependencyProperty IconColorProperty = DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(ExtendButton), new PropertyMetadata(null));
        public SolidColorBrush IconColor
        {
            get { return (SolidColorBrush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public static readonly DependencyProperty IconColorHoverProperty = DependencyProperty.Register("IconColorHover", typeof(SolidColorBrush), typeof(ExtendButton), new PropertyMetadata(null));
        public SolidColorBrush IconColorHover
        {
            get { return (SolidColorBrush)GetValue(IconColorHoverProperty); }
            set { SetValue(IconColorHoverProperty, value); }
        }

        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register("IconSource", typeof(object), typeof(ExtendButton), new PropertyMetadata(null));
        public object IconSource
        {
            get { return (object)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register("IconSize", typeof(double), typeof(ExtendButton), new PropertyMetadata((double)0));
        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty SeparationProperty = DependencyProperty.Register("Separation", typeof(double), typeof(ExtendButton), new PropertyMetadata((double)0));
        public double Separation
        {
            get { return (double)GetValue(SeparationProperty); }
            set { SetValue(SeparationProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExtendButton), new PropertyMetadata(null));
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty DisabledProperty = DependencyProperty.Register("Disabled", typeof(bool), typeof(ExtendButton), new PropertyMetadata(false));
        public bool Disabled
        {
            get { return (bool)GetValue(DisabledProperty); }
            set { SetValue(DisabledProperty, value); }
        }

        public ExtendButton()
        {

        }


    }
}
