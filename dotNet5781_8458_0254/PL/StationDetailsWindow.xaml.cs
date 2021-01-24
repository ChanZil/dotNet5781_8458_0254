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
    /// Interaction logic for StationDetailsWindow.xaml
    /// </summary>
    public partial class StationDetailsWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        PO.POStation station;
        ObservableCollection<PO.POStation> pOStations;
        public StationDetailsWindow(ObservableCollection<PO.POStation> collection) //add station ctor
        {
            InitializeComponent();
            pOStations = collection;
            btnUpdateStation.Visibility = Visibility.Hidden;
        }
        public StationDetailsWindow(PO.POStation pOStation) //update station ctor
        {
            InitializeComponent();
            tbName.Text = pOStation.Name;
            tbAddress.Text = pOStation.Address;
            tbLongitude.Text = pOStation.Longitude.ToString();
            tbLatitude.Text = pOStation.Latitude.ToString();
            station = pOStation;
            btnAddStation.Visibility = Visibility.Hidden;
            lblCodeStation.Visibility = Visibility.Hidden;
            tbCodeStation.Visibility = Visibility.Hidden;
        }
        private void btnAddStation_Click(object sender, RoutedEventArgs e)
        {
            if (tbCodeStation.Text == "" || tbName.Text == "" || tbAddress.Text == "" || tbLongitude.Text == "" || tbLatitude.Text == "")
                MessageBox.Show("מלאו את כל הפרטים");
            else
            {
                PO.POStation pOStation = new PO.POStation
                {
                    Code = Convert.ToInt32(tbCodeStation.Text),
                    Name = tbName.Text,
                    Address = tbAddress.Text,
                    Longitude = Convert.ToDouble(tbLongitude.Text),
                    Latitude = Convert.ToDouble(tbLatitude.Text)
                };
                BO.BOStation bOStation = new BO.BOStation
                {
                    Code = pOStation.Code,
                    Name = pOStation.Name,
                    Address = pOStation.Address,
                    Longitude = pOStation.Longitude,
                    Latitude = pOStation.Latitude
                };
                try
                {
                    bl.CreateStation(bOStation);
                    pOStations.Add(pOStation);
                    this.Close();
                }
                catch (BO.BadStationIdException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdateStation_Click(object sender, RoutedEventArgs e)
        {
            station.Name = tbName.Text;
            station.Address = tbAddress.Text;
            station.Longitude = Convert.ToDouble(tbLongitude.Text);
            station.Latitude = Convert.ToDouble(tbLatitude.Text);
            BO.BOStation bOStation = new BO.BOStation
            {
                Code = station.Code,
                Name = station.Name,
                Address = station.Address,
                Longitude = station.Longitude,
                Latitude = station.Latitude
            };
            try
            {
                bl.UpdateStation(bOStation);
                this.Close();
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
