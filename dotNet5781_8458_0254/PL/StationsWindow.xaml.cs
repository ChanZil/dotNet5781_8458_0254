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
        ObservableCollection<BO.BOStation> bOStations = new ObservableCollection<BO.BOStation>();
        public StationsWindow()
        {
            InitializeComponent();
            foreach (BO.BOStation station in bl.GetAllStations())
                bOStations.Add(station);
            pOStationDataGrid.DataContext = bOStations;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pOStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOStationViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource bOLineStationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bOLineStationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bOLineStationViewSource.Source = [generic data source]
        }

        private void pOStationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void btnShowLines_Click(object sender, RoutedEventArgs e)
        {
            BO.BOStation bOStation = pOStationDataGrid.SelectedValue as BO.BOStation;
            bOLineStationDataGrid.ItemsSource = bl.GetAllLineStationByStationId(bOStation.Code);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
