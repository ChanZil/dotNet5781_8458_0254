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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LinesWindow linesWindow = new LinesWindow();
            linesWindow.Show();
        }

        private void btnShowStations_Click(object sender, RoutedEventArgs e)
        {
            StationsWindow stationsWindow = new StationsWindow();
            stationsWindow.Show();
        }

        private void btnShowBus_Click(object sender, RoutedEventArgs e)
        {
            BusWindow busWindow = new BusWindow();
            busWindow.Show();
        }
    }
}
