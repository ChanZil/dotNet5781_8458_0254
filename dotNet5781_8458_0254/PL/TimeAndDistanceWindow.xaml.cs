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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for TimeAndDistanceWindow.xaml
    /// </summary>
    public partial class TimeAndDistanceWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        PO.POStationInLine station1, station2;
        public TimeAndDistanceWindow(PO.POStationInLine pOStationInLine1, PO.POStationInLine pOStationInLine2)
        {
            InitializeComponent();
            lblCurrentStation.Content = pOStationInLine1.Name;
            lblNextStation.Content = pOStationInLine2.Name;
            txbDistance.Text = pOStationInLine1.Distance.ToString();
            tbTimeH.Text = pOStationInLine1.Time.Hours.ToString();
            tbTimeM.Text = pOStationInLine1.Time.Minutes.ToString();
            tbTimeS.Text = pOStationInLine1.Time.Seconds.ToString();
            station1 = pOStationInLine1;
            station2 = pOStationInLine2;
        }

        private void btnAddTimeDistance_Click(object sender, RoutedEventArgs e)
        {
            station1.Distance = Convert.ToDouble(txbDistance.Text);
            station1.Time = new TimeSpan(Convert.ToInt32(tbTimeH.Text), Convert.ToInt32(tbTimeM.Text), Convert.ToInt32(tbTimeS.Text));
            BO.BOStationInLine bOStationInLine = new BO.BOStationInLine
            {
                Code = station1.Code,
                Name = station1.Name,
                Address = station1.Address,
                Distance = station1.Distance,
                Time = station1.Time
            };
            this.Close();
        }
    }
}
