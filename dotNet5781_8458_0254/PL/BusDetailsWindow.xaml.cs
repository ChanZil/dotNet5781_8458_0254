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
    /// Interaction logic for BusDetailsWindow.xaml
    /// </summary>
    public partial class BusDetailsWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        PO.POBus pOBus;
        ObservableCollection<PO.POBus> pOBuses;
        public BusDetailsWindow(ObservableCollection<PO.POBus> collection) //add ctor
        {
            InitializeComponent();
            cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));
            cbStatus.SelectedIndex = 0;
            dpFromDate.SelectedDate = DateTime.Now;
            pOBuses = collection;
            btnUpdateBus.Visibility = Visibility.Hidden;
        }
        public BusDetailsWindow(PO.POBus bus) //update ctor
        {
            InitializeComponent();
            cbStatus.ItemsSource = Enum.GetValues(typeof(BO.BusStatus));
            txbLicenseNum.Text = bus.LicenseNum.ToString();
            dpFromDate.Text = bus.FromDate.ToString();
            txbTotalTrip.Text = bus.TotalTrip.ToString();
            txbFuelRemain.Text = bus.FuelRemain.ToString();
            cbStatus.SelectedIndex = Convert.ToInt32(bus.Status);
            pOBus = bus;
            btnAddBus.Visibility = Visibility.Hidden;
        }
        private void btnAddBus_Click(object sender, RoutedEventArgs e)
        {
            if (txbLicenseNum.Text == "" || txbTotalTrip.Text == "" || txbFuelRemain.Text == "")
                MessageBox.Show("מלאו את כל הפרטים");
            else
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
