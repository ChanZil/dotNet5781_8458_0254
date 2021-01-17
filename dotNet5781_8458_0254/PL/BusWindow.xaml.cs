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
    /// Interaction logic for BusWindow.xaml
    /// </summary>
    public partial class BusWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public ObservableCollection<PO.POBus> pOBuses = new ObservableCollection<PO.POBus>();
        public BusWindow()
        {
            InitializeComponent();
            var bOBuses = bl.GetAllBOBuses();
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
            AddBusWindow addBusWindow = new AddBusWindow(pOBuses);
            addBusWindow.Show();
        }

        private void btnUpdateBus_Click(object sender, RoutedEventArgs e)
        {
            PO.POBus pOBus = pOBusDataGrid.SelectedItem as PO.POBus;
            UpdateBusWindow sendDrive = new UpdateBusWindow(pOBus);
            sendDrive.ShowDialog();
        }

        private void btnDeleteBus_Click(object sender, RoutedEventArgs e)
        {
            PO.POBus pOBus = pOBusDataGrid.SelectedItem as PO.POBus;
            BO.BOBus bOBus = new BO.BOBus()
            {
                LicenseNum = pOBus.LicenseNum,
                FromDate = pOBus.FromDate,
                TotalTrip = pOBus.TotalTrip,
                FuelRemain = pOBus.FuelRemain,
                Status = pOBus.Status
            };
            if (MessageBox.Show("האם למחוק אוטובוס זה?", "מחיקת אוטובוס", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bl.DeleteBus(bOBus);
                    pOBuses.Remove(pOBus);
                }
                catch (BO.BadBusIdException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pOBusDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
