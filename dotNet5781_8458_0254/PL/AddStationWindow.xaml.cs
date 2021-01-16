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
        ObservableCollection<BO.BOStation> bOStations;
        public AddStationWindow(ObservableCollection<BO.BOStation> collection)
        {
            InitializeComponent();
            bOStations = collection;
        }

        private void btnAddStation_Click(object sender, RoutedEventArgs e)
        {
            BO.BOStation bOStation = new BO.BOStation
            {
                Code = Convert.ToInt32(tbCodeStation.Text),
                Name = tbName.Text,
                Address = tbAddress.Text,
                Longitude = Convert.ToDouble(tbLongitude.Text),
                Latitude = Convert.ToDouble(tbLatitude.Text)
            };
            try
            {
                bl.CreateStation(bOStation);
                this.Close();
            }
            catch(BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
