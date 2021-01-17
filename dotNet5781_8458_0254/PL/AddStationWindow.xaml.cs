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
    /// Interaction logic for AddStationWindow.xaml
    /// </summary>
    public partial class AddStationWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        ObservableCollection<PO.POStation> pOStations;
        public AddStationWindow(ObservableCollection<PO.POStation> collection)
        {
            InitializeComponent();
            pOStations = collection;
        }

        private void btnAddStation_Click(object sender, RoutedEventArgs e)
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
            catch(BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
