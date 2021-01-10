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
    /// Interaction logic for PLLines.xaml
    /// </summary>
    public partial class PLLines : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public PLLines()
        {
            InitializeComponent();
            var listOfStations = bl.GetAllStationInLine();
            var stations = from item in listOfStations
                           select new
                           {
                               Code = item.Code,
                               Name = item.Name,
                               Address = item.Address
                           };
            dgStationInLIne.ItemsSource = stations;
            var listOfLine = bl.GetAllBOLines();
            var lines = from item in listOfLine
                           select new
                           {
                              Id=item.Id,
                              Code=item.Code,
                              Area= item.Area,
                              StartAt=item.StartAt,
                              FinishAt=item.FinishAt,
                              Frequency=item.Frequency,
                              ListOfStationInLine=item.ListOfStationInLine
                           };
            lbLines.ItemsSource = lines;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgStationInLIne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lbLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
