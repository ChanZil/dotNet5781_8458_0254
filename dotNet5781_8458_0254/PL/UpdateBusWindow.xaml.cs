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
    /// Interaction logic for UpdateBusWindow.xaml
    /// </summary>
    public partial class UpdateBusWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        PO.POBus pOBus;
        public UpdateBusWindow(PO.POBus bus)
        {
            InitializeComponent();
            cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));
            txbLicenseNum.Text = bus.LicenseNum.ToString();
            dpFromDate.Text = bus.FromDate.ToString();
            txbTotalTrip.Text = bus.TotalTrip.ToString();
            txbFuelRemain.Text = bus.FuelRemain.ToString();
            pOBus = bus;
        }

        private void txbLicenseNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnUpdateBus_Click(object sender, RoutedEventArgs e)
        {
            pOBus.LicenseNum = Convert.ToInt32(txbLicenseNum.Text);
            pOBus.FromDate = Convert.ToDateTime(dpFromDate.DataContext);
            pOBus.TotalTrip = Convert.ToDouble(txbTotalTrip.Text);
            pOBus.FuelRemain = Convert.ToDouble(txbFuelRemain.Text);
            pOBus.Status = (BO.BusStatus)cbStatus.SelectedIndex;
            BO.BOBus bOBus = new BO.BOBus()
            {
                LicenseNum = pOBus.LicenseNum,
                FromDate = pOBus.FromDate,
                TotalTrip = pOBus.TotalTrip,
                FuelRemain = pOBus.FuelRemain,
                Status = pOBus.Status
            };
            try
            {
                bl.UpdateBus(bOBus);
            }
            catch(BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
