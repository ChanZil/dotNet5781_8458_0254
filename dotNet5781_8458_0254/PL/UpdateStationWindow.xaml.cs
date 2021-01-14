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
        BO.BOStation station;
        public UpdateStationWindow(BO.BOStation bOStation)
        {
            InitializeComponent();
            tbName.Text = bOStation.Name;
            tbAddress.Text = bOStation.Address;
            tbLongitude.Text = bOStation.Longitude.ToString();
            tbLatitude.Text = bOStation.Latitude.ToString();
            station = bOStation;
        }

        private void btnUpdateStation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
