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
    /// Interaction logic for AddBus.xaml
    /// </summary>
    public partial class AddBus : Window
    {
        Status selectedStatus = Status.isReady;
        public AddBus()
        {
            InitializeComponent();
            List<string> busStatus = new List<string>();
            busStatus.Add("מוכן לנסיעה");
            busStatus.Add("באמצע נסיעה");
            busStatus.Add("בתדלוק");
            busStatus.Add("בטיפול");
            cbStatus.ItemsSource = busStatus;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bus b = new Bus(tbNumBus.Text, Convert.ToDateTime(dpDateStart.DataContext), Convert.ToDouble(tbKilometers.Text)
           , Convert.ToDouble(tbKMgas.Text), Convert.ToDouble(tbKMtreat.Text),
            Convert.ToDateTime(dpDateLastTreat.DataContext), selectedStatus);
            BusList.buses.Add(b);
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void tbKilometers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbStatus.SelectedIndex).ToString() == "מוכן לנסיעה")
                selectedStatus = Status.isReady;
            if ((cbStatus.SelectedIndex).ToString() == "מוכן לנסיעה")
                selectedStatus = Status.isMid;
            if ((cbStatus.SelectedIndex).ToString() == "מוכן לנסיעה")
                selectedStatus = Status.inGas;
            if ((cbStatus.SelectedIndex).ToString() == "מוכן לנסיעה")
                selectedStatus = Status.inTreat;
        }
    }
}
