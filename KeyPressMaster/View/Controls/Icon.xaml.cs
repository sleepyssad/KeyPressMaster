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
    public partial class Icon : UserControl
    {
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(SolidColorBrush), typeof(Icon), new PropertyMetadata(Brushes.Red));
        public SolidColorBrush Fill
        {
            get { return (SolidColorBrush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(Icon), new PropertyMetadata(new BitmapImage(new Uri(@"pack://application:,,,/Assets/img-failed.png", UriKind.Absolute))));
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public Icon()
        {
            InitializeComponent();

         

        }
    }
}
