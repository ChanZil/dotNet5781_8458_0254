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
    /// Interaction logic for AddBusWindow.xaml
    /// </summary>
    public partial class AddBusWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        ObservableCollection<PO.POBus> pOBuses;
        public AddBusWindow(ObservableCollection<PO.POBus> collection)
        {
            InitializeComponent();
            cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));
            pOBuses = collection;
        }

        private void btnAddBus_Click(object sender, RoutedEventArgs e)
        {
            PO.POBus pOBus = new PO.POBus()
            {
                LicenseNum = Convert.ToInt32(txbLicenseNum.Text),
                FromDate = Convert.ToDateTime(dpFromDate.Text),
                TotalTrip = Convert.ToDouble(txbTotalTrip.Text),
                FuelRemain = Convert.ToDouble(txbFuelRemain.Text),
                Status = (BO.BusStatus)cbStatus.SelectedIndex
            };
            try
            {
                bl.CreateBus(pOBus.LicenseNum, pOBus.FromDate, pOBus.TotalTrip, pOBus.FuelRemain, pOBus.Status);
                var bOBuses = bl.GetAllBOBuses();
                foreach (BO.BOBus bus in bOBuses)
                {
                    PO.POBus busPO = new PO.POBus()
                    {
                        LicenseNum = bus.LicenseNum,
                        FromDate = bus.FromDate,
                        TotalTrip = bus.TotalTrip,
                        FuelRemain = bus.FuelRemain,
                        Status = bus.Status
                    };
                    pOBuses.Add(busPO);
                }
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

        private void txbLicenseNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
