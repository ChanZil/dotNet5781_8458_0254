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
    /// Interaction logic for UpdateStationWindow.xaml
    /// </summary>
    public partial class UpdateStationWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        PO.POStation station;
        public UpdateStationWindow(PO.POStation pOStation)
        {
            InitializeComponent();
            tbName.Text = pOStation.Name;
            tbAddress.Text = pOStation.Address;
            tbLongitude.Text = pOStation.Longitude.ToString();
            tbLatitude.Text = pOStation.Latitude.ToString();
            station = pOStation;
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
            catch(BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
