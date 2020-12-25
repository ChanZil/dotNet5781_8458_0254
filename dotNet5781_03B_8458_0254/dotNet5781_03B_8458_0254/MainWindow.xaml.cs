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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5781_03B_8458_0254
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
            lbBuses.ItemsSource = BusList.buses; //the source of the listbox is the list of the buses
        }

        private void btnAddBus_Click(object sender, RoutedEventArgs e) //add bus to the list
        {
            AddBus addBus = new AddBus();
            addBus.Show();
            this.Close();
        }

        private void lbBuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) //
        {
            Button cmd = (Button)sender;
            SendDrive sendDrive = new SendDrive(cmd.DataContext);
            sendDrive.Show();
        }
        private void btnRefull_Click(object sender, RoutedEventArgs e) //refull the bus
        {
            Button cmd = (Button)sender;
            Bus b = (Bus)cmd.DataContext; //the bus to refull
            b.GasKM = 0; //update the kilometers since last refull of the bus
            b.Status = Status.inGas; //update the status of the bus
        }

        private void lbBuses_MouseDoubleClick(object sender, MouseButtonEventArgs e) //double click in an item in the listbox
        {
            BusDetails busDetails = new BusDetails(lbBuses.SelectedItem);
            busDetails.Show(); //open a BusDetails window to show the details of the bus
        }
    }
}
