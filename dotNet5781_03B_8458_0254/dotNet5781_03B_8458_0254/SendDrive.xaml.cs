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
using System.Text.RegularExpressions;

namespace dotNet5781_03B_8458_0254
{
    /// <summary>
    /// Interaction logic for SendDrive.xaml
    /// </summary>
    public partial class SendDrive : Window
    {
        Bus bus; //the bus to send to drive
        public SendDrive(object b) //ctor. get the bus to send to drive
        {
            InitializeComponent();
            bus = (Bus)b; //save the bus
        }

        private void tbKilometers_KeyDown(object sender, KeyEventArgs e) //check every letter typed in the txtbox
        {
            
            if (e.Key == Key.Enter) //if the user clicked enter
            {
                TimeSpan t = DateTime.Now - bus.dateOfLastTreat; //save the time span of the bus to send since last treatment
                //check if the bus can be send to drive- if the status is not isReady to drive or there is not enough gas or there is more
                //then 20000 kilometers since last treatment or its been a year since last treatment- the bus can't drive.
                if ((bus.Status != Status.isReady) || (1200 - bus.GasKM < Convert.ToDouble(tbKilometers.Text))
                    || (bus.TreatmentKM + Convert.ToDouble(tbKilometers.Text) > 20000) || (t.Days > 365))
                {
                    MessageBox.Show("אוטובוס לא יכול לצאת לנסיעה"); //show a message that the bus can't drive 
                    this.Close(); //close the current window
                }
                else //if the bus can be send to drive
                {
                    bus.Kilometers += Convert.ToDouble(tbKilometers.Text); //add the kilometers to the kilometers of the bus
                    bus.GasKM += Convert.ToDouble(tbKilometers.Text); //add the kilometers to the kilometers since last refull of the bus
                    bus.TreatmentKM += Convert.ToDouble(tbKilometers.Text); //add the kilometers to the kilometers since last treatment of the bus
                    bus.Status = Status.isMid; //update the status of the bus to isMid
                    this.Close(); //close the current window
                }
            }
        }

        private void tbKilometers_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbKilometers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
