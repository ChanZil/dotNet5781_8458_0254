using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO
{
    public class POStationInLine : DependencyObject
    {
        public int Code
        {
            get { return (int)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code",
            typeof(int), typeof(POStationInLine));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name",
            typeof(string), typeof(POStationInLine));

        public double Longitude
        {
            get { return (double)GetValue(LongitudeProperty); }
            set { SetValue(LongitudeProperty, value); }
        }
        public static readonly DependencyProperty LongitudeProperty =
            DependencyProperty.Register("Longitude",
            typeof(double), typeof(POStationInLine));

        public double Latitude
        {
            get { return (double)GetValue(LatitudeProperty); }
            set { SetValue(LatitudeProperty, value); }
        }
        public static readonly DependencyProperty LatitudeProperty =
            DependencyProperty.Register("Latitude",
            typeof(double), typeof(POStationInLine));

        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }
        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address",
            typeof(string), typeof(POStationInLine));
    }
}
