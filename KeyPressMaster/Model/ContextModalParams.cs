using KeyPressMaster.View.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeyPressMaster.Model
{
    public class ContextModalParams
    {
        public double X {  get; set; }

        public double Y { get; set; }

        public Point RenderTransformOrigin { get; set; }

        public object Content { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }
    }
}
