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
    /// Interaction logic for StationsWindow.xaml
    /// </summary>
    public partial class StationsWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        ObservableCollection<PO.POStation> pOStations = new ObservableCollection<PO.POStation>();
        public StationsWindow()
        {
            InitializeComponent();

            foreach (BO.BOStation station in bl.GetAllStations())
            {
                PO.POStation pOStation = new PO.POStation
                {
                    Code = station.Code,
                    Name = station.Name,
                    Address = station.Address,
                    Longitude = station.Longitude,
                    Latitude = station.Latitude
                };
                foreach (BO.BOLineStation bOLineStation in bl.GetAllLineStationByStationId(station.Code))
                {
                    PO.POLineStation pOLineStation = new PO.POLineStation
                    {
                        Id = bOLineStation.Id,
                        Code = bOLineStation.Code,
                        LineStationIndex = bOLineStation.LineStationIndex
                    };
                    pOStation.ListOfLineStations.Add(pOLineStation);
                }
                pOStations.Add(pOStation);
            }
            pOStationDataGrid.DataContext = pOStations;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pOStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOStationViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource bOLineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bOLineStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bOLineStationViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource pOLineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOLineStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOLineStationViewSource.Source = [generic data source]
        }

        private void pOStationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void btnShowLines_Click(object sender, RoutedEventArgs e)
        {
            PO.POStation pOStation = pOStationDataGrid.SelectedValue as PO.POStation;
            pOLineStationDataGrid.ItemsSource = pOStation.ListOfLineStations;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            PO.POStation pOStation = pOStationDataGrid.SelectedItem as PO.POStation;
            BO.BOStation bOStation = new BO.BOStation
            {
                Code = pOStation.Code,
                Name = pOStation.Name,
                Address = pOStation.Address,
                Longitude = pOStation.Longitude,
                Latitude = pOStation.Latitude
            };
            var bOLineStations = from lineStation in pOStation.ListOfLineStations
                                 select new BO.BOLineStation
                                 {
                                     Id = lineStation.Id,
                                     Code = lineStation.Code,
                                     LineStationIndex = lineStation.LineStationIndex
                                 };
            bOStation.ListOfLines = bOLineStations;
            if (MessageBox.Show("האם למחוק תחנה זו?", "מחיקת תחנת אוטובוס", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bl.DeleteStation(bOStation.Code);
                    pOStations.Remove(pOStation);
                }
                catch (BO.BadStationIdException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnUpdateStation_Click(object sender, RoutedEventArgs e)
        {
            PO.POStation pOStation = pOStationDataGrid.SelectedItem as PO.POStation;
            UpdateStationWindow updateStationWindow = new UpdateStationWindow(pOStation);
            updateStationWindow.Show();

        }

        private void btnAddStation_Click(object sender, RoutedEventArgs e)
        {
            AddStationWindow stationWindow = new AddStationWindow(pOStations);
            stationWindow.Show();
        }
    }
}
