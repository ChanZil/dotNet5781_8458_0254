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

        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }
        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address",
            typeof(string), typeof(POStationInLine));

        public double Distance
        {
            get { return (double)GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }
        public static readonly DependencyProperty DistanceProperty =
            DependencyProperty.Register("Distance",
            typeof(double), typeof(POStationInLine));

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time",
            typeof(TimeSpan), typeof(POStationInLine));
        public override string ToString()
        {
            return Name;
        }
    }
}
