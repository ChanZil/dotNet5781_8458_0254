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

namespace dotNet5781_03B_8458_0254
{
    /// <summary>
    /// Interaction logic for BusDetails.xaml
    /// </summary>
    public partial class BusDetails : Window
    {
        Bus bus;
        public BusDetails(object b) //ctor. gets a bus and show its details
        {
            InitializeComponent();
            bus = (Bus)b; //convert the object we got to a bus
            //write the details of the bus in their labels
            lblNumBus.Content = bus.NumBus; 
            lblDateOfStart.Content = bus.DateOfStart;
            lblKilometers.Content = bus.Kilometers;
            lblGasKm.Content = bus.GasKM;
            lblTreatmentKm.Content = bus.TreatmentKM;
            lblDateTreat.Content = bus.DateOfLastTreat;
            lblStatus.Content = bus.Status;
        }

        private void btnSendTreat_Click(object sender, RoutedEventArgs e) //click send bus to treatment
        {
            if (bus.Status==Status.isReady)
            {
                bus.dateOfLastTreat = DateTime.Now; //update the date of the last treatment to be now
                bus.Status = Status.inTreat; //update the status of the bus to be in treatment
                bus.TreatmentKM = 0; //update the number of kilometers since last treatment to be 0
                //update the labels with the new details of the bus
                lblTreatmentKm.Content = bus.TreatmentKM;
                lblDateTreat.Content = bus.DateOfLastTreat;
                lblStatus.Content = bus.Status;
            }
        }

        private void btnSendGas_Click(object sender, RoutedEventArgs e) //click refull the bus
        {
            if (bus.Status == Status.isReady)
            {
                bus.GasKM = 0; //update the kilometers since last refull of the bus to be 0
                bus.Status = Status.inGas; //update the status of the bus to be in gas
                //update the labels with the new details of the bus
                lblGasKm.Content = bus.GasKM;
                lblStatus.Content = bus.Status;
            }
        }
    }
}
