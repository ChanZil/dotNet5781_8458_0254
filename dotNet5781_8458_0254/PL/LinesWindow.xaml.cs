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
    /// Interaction logic for LinesWindow.xaml
    /// </summary>
    public partial class LinesWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public LinesWindow()
        {
            InitializeComponent();
            var bOLines = bl.GetAllBOLines();
            var pOLines = from line in bOLines
                          select new PO.POLines
                          {
                              Id = line.Id,
                              Code = line.Code,
                              Area = line.Area,
                              StartAt = line.StartAt,
                              FinishAt = line.FinishAt,
                              Frequency = line.Frequency,
                          };
            foreach(PO.POLines line in pOLines)
            {
                foreach (BO.BOStationInLine stationInLine in bl.GetAllStationInLineByCodeLine(line.Id))
                    line.ListOfStationInLine.Add(new PO.POStationInLine
                    {
                        Code = stationInLine.Code,
                        Name = stationInLine.Name,
                        Longitude = stationInLine.Longitude,
                        Latitude = stationInLine.Latitude,
                        Address = stationInLine.Address
                    });
            }
            pOLinesDataGrid.DataContext = pOLines;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pOLinesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOLinesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOLinesViewSource.Source = [generic data source]
        }
    }
}
