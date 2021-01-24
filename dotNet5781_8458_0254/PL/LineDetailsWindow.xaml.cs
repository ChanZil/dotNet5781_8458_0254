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
    /// Interaction logic for LineDetailsWindow.xaml
    /// </summary>
    public partial class LineDetailsWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        PO.POLines pOLine;
        ObservableCollection<PO.POStationInLine> pOAllStationInLines = new ObservableCollection<PO.POStationInLine>();
        ObservableCollection<PO.POStationInLine>  pOStationInLines = new ObservableCollection<PO.POStationInLine>();
        ObservableCollection<PO.POLines> pOLines = new ObservableCollection<PO.POLines>();
        public LineDetailsWindow(ObservableCollection<PO.POLines> collection) //add line ctor
        {
            InitializeComponent();
            presentStations();
            pOLines = collection;
            cbArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            lbLineStations.ItemsSource = pOStationInLines;
            btnUpdateLine.Visibility = Visibility.Hidden;
            tbStartH.Text = "00";
            tbStartM.Text = "00";
            tbStartS.Text = "00";
            tbFinishH.Text = "00";
            tbFinishM.Text = "00";
            tbFinishS.Text = "00";
            tbFrequencyH.Text = "00";
            tbFrequencyM.Text = "00";
            tbFrequencyS.Text = "00";
            cbArea.SelectedIndex = 0;
        }
        public LineDetailsWindow(ObservableCollection<PO.POLines> collection, PO.POLines line) //update line ctor
        {
            InitializeComponent();
            presentStations();
            pOLines = collection;
            cbArea.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            tbCode.Text = line.Code.ToString();
            tbStartH.Text = line.StartAt.Hours.ToString();
            tbStartM.Text = line.StartAt.Minutes.ToString();
            tbStartS.Text = line.StartAt.Seconds.ToString();
            tbFinishH.Text = line.FinishAt.Hours.ToString();
            tbFinishM.Text = line.FinishAt.Minutes.ToString();
            tbFinishS.Text = line.FinishAt.Seconds.ToString();
            tbFrequencyH.Text = line.Frequency.Hours.ToString();
            tbFrequencyM.Text = line.Frequency.Minutes.ToString();
            tbFrequencyS.Text = line.Frequency.Seconds.ToString();
            pOStationInLines = line.ListOfStationInLine;
            cbArea.SelectedIndex = Convert.ToInt32(line.Area);
            lbLineStations.ItemsSource = pOStationInLines;
            pOLine = line;
            btnAddLine.Visibility = Visibility.Hidden;

            //var x = (DataGridRow)pOStationInLineDataGrid.ItemContainerGenerator.ContainerFromIndex(3);
            
            //foreach(PO.POStationInLine item1 in pOAllStationInLines)
            //    foreach(PO.POStationInLine item2 in pOStationInLines)
            //        if(item1.Code == item2.Code)
            //        {

            //            var x =(DataGridRow)pOStationInLineDataGrid.ItemContainerGenerator.ContainerFromIndex(3);
            //            x.
            //        }
        }
        private void presentStations()
        {
            foreach (BO.BOStation stationInLine in bl.GetAllStations())
            {
                PO.POStationInLine pOStationInLine = new PO.POStationInLine
                {
                    Code = stationInLine.Code,
                    Name = stationInLine.Name,
                    Address = stationInLine.Address,
                    
                };
                pOAllStationInLines.Add(pOStationInLine);
            }
            pOStationInLineDataGrid.DataContext = pOAllStationInLines;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pOStationInLineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pOStationInLineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pOStationInLineViewSource.Source = [generic data source]
        }

        private void checkedAddStation_Checked(object sender, RoutedEventArgs e)
        {
            PO.POStationInLine pOStationInLine = pOStationInLineDataGrid.SelectedValue as PO.POStationInLine;
            pOStationInLines.Add(pOStationInLine);
        }

        private void btnAddLine_Click(object sender, RoutedEventArgs e)
        {
            if (tbCode.Text == "")
                MessageBox.Show("מלאו את כל הפרטים");
            else 
            {
                if (lbLineStations.Items.Count < 2)
                {
                    MessageBox.Show("הכנס לפחות שתי תחנות");
                }
                else
                {
                    try
                    {
                        PO.POLines pOLine = GetPoLine();
                        int id = bl.CreateLine(pOLine.Code, pOLine.Area, pOLine.StartAt, pOLine.FinishAt, pOLine.Frequency, ConvertPoBo(pOLine.ListOfStationInLine));
                        pOLine.Id = id;
                        pOLines.Add(pOLine);
                        this.Close();
                    }
                    catch (BO.BadLineIdExeption ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbLineStations.SelectedIndex == -1)
                MessageBox.Show("יש לבחור תחנה");
            else
            {
                if (lbLineStations.SelectedIndex == lbLineStations.Items.Count - 1)
                {
                    MessageBox.Show("לא ניתן להוסיף זמן ומרחק לתחנה אחרונה בקו");
                }
                else
                {
                    PO.POStationInLine station1 = lbLineStations.SelectedValue as PO.POStationInLine;
                    int index = pOStationInLines.IndexOf(station1);
                    PO.POStationInLine station2 = pOStationInLines.ElementAt(index + 1);
                    TimeAndDistanceWindow timeAndDistanceWindow = new TimeAndDistanceWindow(station1, station2);
                    timeAndDistanceWindow.Show();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void checkedAddStation_UnChecked(object sender, RoutedEventArgs e)
        {
            PO.POStationInLine pOStationInLine = pOStationInLineDataGrid.SelectedValue as PO.POStationInLine;
            pOStationInLines.Remove(pOStationInLine);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (lbLineStations.SelectedIndex == -1)
                MessageBox.Show("יש לבחור תחנה");
            else
            {
                PO.POStationInLine pOStationInLine = lbLineStations.SelectedValue as PO.POStationInLine;
                if (pOStationInLines.First().Code != pOStationInLine.Code)
                {
                    int index = pOStationInLines.IndexOf(pOStationInLine);
                    pOStationInLines.Remove(pOStationInLine);
                    pOStationInLines.Insert(index - 1, pOStationInLine);
                    pOStationInLines.ElementAt(index).Time = new TimeSpan(0, 0, 0);
                    pOStationInLines.ElementAt(index).Distance = 0;
                    pOStationInLines.ElementAt(index - 1).Time = new TimeSpan(0, 0, 0);
                    pOStationInLines.ElementAt(index - 1).Distance = 0;
                }
            }
        }

        private void lbLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (lbLineStations.SelectedIndex == -1)
                MessageBox.Show("יש לבחור תחנה");
            else
            {
                PO.POStationInLine pOStationInLine = lbLineStations.SelectedValue as PO.POStationInLine;
                if (pOStationInLines.Last().Code != pOStationInLine.Code)
                {
                    int index = pOStationInLines.IndexOf(pOStationInLine);
                    pOStationInLines.Remove(pOStationInLine);
                    pOStationInLines.Insert(index + 1, pOStationInLine);
                    pOStationInLines.ElementAt(index).Time = new TimeSpan(0, 0, 0);
                    pOStationInLines.ElementAt(index).Distance = 0;
                    pOStationInLines.ElementAt(index + 1).Time = new TimeSpan(0, 0, 0);
                    pOStationInLines.ElementAt(index + 1).Distance = 0;
                }
            }
        }

        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)
        {
            if (lbLineStations.Items.Count < 2)
            {
                MessageBox.Show("הכנס לפחות שתי תחנות");
            }
            else
            {
                PO.POLines oldLine = pOLine;
                pOLine = GetPoLine();
                pOLine.Id = oldLine.Id;
                BO.BOLine bOLine = new BO.BOLine
                {
                    Id = pOLine.Id,
                    Code = pOLine.Code,
                    Area = pOLine.Area,
                    StartAt = pOLine.StartAt,
                    FinishAt = pOLine.FinishAt,
                    Frequency = pOLine.Frequency,
                    ListOfStationInLine = ConvertPoBo(pOLine.ListOfStationInLine)
                };
                try
                {
                    bl.UpdateLine(bOLine);
                    pOLines.Remove(oldLine);
                    pOLines.Add(pOLine);
                    this.Close();
                }
                catch(BO.BadLineIdExeption ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// create a new PO.POLine from the input from the user
        /// </summary>
        /// <returns></returns>
        private PO.POLines GetPoLine()
        {
            TimeSpan startAt = new TimeSpan(Convert.ToInt32(tbStartH.Text), Convert.ToInt32(tbStartM.Text), Convert.ToInt32(tbStartS.Text));
            TimeSpan finishAt = new TimeSpan(Convert.ToInt32(tbFinishH.Text), Convert.ToInt32(tbFinishM.Text), Convert.ToInt32(tbFinishS.Text));
            TimeSpan frequency = new TimeSpan(Convert.ToInt32(tbFrequencyH.Text), Convert.ToInt32(tbFrequencyM.Text), Convert.ToInt32(tbFrequencyS.Text));
            PO.POLines pOLine = new PO.POLines
            {
                Code = Convert.ToInt32(tbCode.Text),
                Area = (BO.Areas)cbArea.SelectedIndex,
                StartAt = startAt,
                FinishAt = finishAt,
                Frequency = frequency,
                ListOfStationInLine = pOStationInLines
            };
            return pOLine;
        }
        /// <summary>
        /// convert the ObservableCollection from the PO.POStationInLine to Ienumerable of BO.BOStationInLine
        /// </summary>
        /// <param name="pOStationInLine">the observableCollection to conbert to Ienumerable</param>
        /// <returns>the converted Ienumerable</returns>
        private IEnumerable<BO.BOStationInLine> ConvertPoBo(ObservableCollection<PO.POStationInLine> pOStationInLine)
        {
            return from station in pOStationInLine
                   select new BO.BOStationInLine
                   {
                       Code = station.Code,
                       Name = station.Name,
                       Address = station.Address,
                       Distance = station.Distance,
                       Time = station.Time
                   };
        }
    }
}
