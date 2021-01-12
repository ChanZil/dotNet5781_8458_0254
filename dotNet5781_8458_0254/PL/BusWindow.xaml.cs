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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for BusWindow.xaml
    /// </summary>
    public partial class BusWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public BusWindow()
        {
            InitializeComponent();
            var bOBuses = bl.GetAllBOBuses();
            List<PO.POBus> pOBuses=new List<PO.POBus>();
            foreach (BO.BOBus bus in bOBuses)
            {
                PO.POBus pOBus = new PO.POBus()
                {
                    LicenseNum = bus.LicenseNum,
                    FromDate=bus.FromDate,
                    TotalTrip=bus.TotalTrip,
                    FuelRemain=bus.FuelRemain,
                    Status=bus.Status
                };
                pOBuses.Add(pOBus);
            }
            pOBusDataGrid.DataContext = pOBuses;
        }

        private void dgBuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txbLicenseNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddBus_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
