using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace PO
{
    public class POLineStation : DependencyObject
    {
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id",
            typeof(int), typeof(POLineStation));
        public int Code
        {
            get { return (int)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code",
            typeof(int), typeof(POLineStation));
        public int LineStationIndex
        {
            get { return (int)GetValue(LineStationIndexProperty); }
            set { SetValue(LineStationIndexProperty, value); }
        }
        public static readonly DependencyProperty LineStationIndexProperty =
            DependencyProperty.Register("Id",
            typeof(int), typeof(POLineStation));
    }
}
