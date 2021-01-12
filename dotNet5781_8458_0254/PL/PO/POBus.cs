using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO
{
    public class POBus : DependencyObject
    {
        public int LicenseNum
        {
            get { return (int)GetValue(LicenseNumProperty); }
            set { SetValue(LicenseNumProperty, value); }
        }
        public static readonly DependencyProperty LicenseNumProperty =
            DependencyProperty.Register("LicenseNum",
            typeof(int), typeof(POBus));

        public DateTime FromDate
        {
            get { return (DateTime)GetValue(FromDateProperty); }
            set { SetValue(FromDateProperty, value); }
        }
        public static readonly DependencyProperty FromDateProperty =
            DependencyProperty.Register("FromDate",
            typeof(DateTime), typeof(POBus));

        public double TotalTrip
        {
            get { return (double)GetValue(TotalTripProperty); }
            set { SetValue(TotalTripProperty, value); }
        }
        public static readonly DependencyProperty TotalTripProperty =
            DependencyProperty.Register("TotalTrip",
            typeof(double), typeof(POBus));

        public double FuelRemain
        {
            get { return (double)GetValue(FuelRemainProperty); }
            set { SetValue(FuelRemainProperty, value); }
        }
        public static readonly DependencyProperty FuelRemainProperty =
            DependencyProperty.Register("FuelRemain",
            typeof(double), typeof(POBus));

        public BO.BusStatus Status
        {
            get { return (BO.BusStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status",
            typeof(BO.BusStatus), typeof(POBus));
    }
}
