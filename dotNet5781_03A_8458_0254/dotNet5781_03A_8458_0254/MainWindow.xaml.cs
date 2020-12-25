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
using dotNet5781_02_8458_0254;

namespace dotNet5781_03A_8458_0254
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BusLine currentDisplayBusLine;
        private BusLineCollection busLines = new BusLineCollection();
        public MainWindow()
        {
            InitializeComponent();
            List<BusStopLine> stations = new List<BusStopLine>(); //list of all stations
            for (int i = 0; i < 40; i++) //pass the array of the stations 
            {
                BusStopLine b = new BusStopLine();
                stations.Add(b);
            }
            for (int i = 0; i < 10; i++) //create 10 new lines
            {
                List<BusStopLine> b = new List<BusStopLine>(); //new list of stations for each line
                for (int j = 0; j < 4; j++) //each line gets 4 stations
                    b.Add(stations[i * 4 + j]); //add a station from the array to the list
                BusLine busLine = new BusLine(i, b, "center"); //create a new line with the list
                busLines.AddBusLine(busLine); //add the new line to the collection
            }
            cbBusLines.ItemsSource = busLines.busLines;
            cbBusLines.DisplayMemberPath = "busLineCode";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(0);
            lbBusLineStations.ItemsSource = busLines; //the source of the listbox is the list of the buses 
        }
        private void ShowBusLine(int index)
        {
            currentDisplayBusLine = busLines[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.stations;
        }
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as BusLine).BusLineCode);
        }

        private void cbBusLines_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
