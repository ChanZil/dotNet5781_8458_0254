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
        ObservableCollection<PO.POLines> pOLines = new ObservableCollection<PO.POLines>();
        public LinesWindow()
        {
            InitializeComponent();
            try
            {
                foreach (BO.BOLine line in bl.GetAllBOLines())
                {
                    PO.POLines pOLine = new PO.POLines
                    {
                        Id = line.Id,
                        Code = line.Code,
                        Area = line.Area,
                        StartAt = line.StartAt,
                        FinishAt = line.FinishAt,
                        Frequency = line.Frequency
                    };
                    foreach (BO.BOStationInLine stationInLine in bl.GetAllStationInLineByCodeLine(line.Id))
                    {
                        PO.POStationInLine pOStationInLine = new PO.POStationInLine
                        {
                            Code = stationInLine.Code,
                            Name = stationInLine.Name,
                            Address = stationInLine.Address,
                            Distance = stationInLine.Distance,
                            Time = stationInLine.Time
                        };
                        pOLine.ListOfStationInLine.Add(pOStationInLine);
                    }
                    pOLines.Add(pOLine);
                }
                pOLinesDataGrid.DataContext = pOLines;
            }
            catch(BO.BadLineIdExeption ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(BO.BadAdjacentStationsIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pOLinesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOLinesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOLinesViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource pOStationInLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOStationInLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOStationInLineViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnShowStations_Click(object sender, RoutedEventArgs e)
        {
            PO.POLines pOLine = pOLinesDataGrid.SelectedValue as PO.POLines;
            pOStationInLineDataGrid.ItemsSource = pOLine.ListOfStationInLine;
        }
        private void btnDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            PO.POLines pOLine = pOLinesDataGrid.SelectedValue as PO.POLines;
            BO.BOLine bOLine = new BO.BOLine
            {
                Id = pOLine.Id,
                Code = pOLine.Code,
                Area = pOLine.Area,
                StartAt = pOLine.StartAt,
                FinishAt = pOLine.FinishAt,
                Frequency = pOLine.Frequency
            };
            var bOStationInLine = from stationInLine in pOLine.ListOfStationInLine
                                  select new BO.BOStationInLine
                                  {
                                      Code = stationInLine.Code,
                                      Name = stationInLine.Name,
                                      Address = stationInLine.Address,
                                      Distance = stationInLine.Distance,
                                      Time = stationInLine.Time
                                  };
            bOLine.ListOfStationInLine = bOStationInLine;
            if (MessageBox.Show("האם למחוק תחנה זו?", "מחיקת תחנת אוטובוס", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bl.DeleteLine(bOLine);
                    pOLines.Remove(pOLine);
                }
                catch (BO.BadLineIdExeption ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddLine_Click(object sender, RoutedEventArgs e)
        {
            LineDetailsWindow detailsWindow = new LineDetailsWindow(pOLines);
            detailsWindow.Show();
        }
        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)
        {
            PO.POLines pOLine = pOLinesDataGrid.SelectedValue as PO.POLines;
            LineDetailsWindow lineDetailsWindow = new LineDetailsWindow(pOLines, pOLine);
            lineDetailsWindow.Show();
        }
    }
}
