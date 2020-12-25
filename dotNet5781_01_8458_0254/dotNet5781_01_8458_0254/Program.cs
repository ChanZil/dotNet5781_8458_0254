using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_8458_0254
{
    enum Menu { add, travel, treat, showKL, exit}
    class Program
    {
        static public Random rand = new Random();

        /*get a list of buses and number of bus and return true if the number exist in the list. if it does,
        return another variable with the bus that found*/
        static public bool CheckIfBusExist(List<Bus> buses, string numBus, out Bus bus)
        
        {
            bus = null;
            for (int i = 0; i < buses.Count(); i++) //pass the list of the buses and try to find the number of the bus that has recieved
            {
                if (numBus == buses[i].NumBus) //check if the number of the bus equals to the one at the list
                {
                    bus = buses[i]; //if it equals, save the bus
                    return true;
                }
            }
            return false;
        }

        /*get a bus and amount of kilometers and activate a travel on the bus if its possible
         */
        static public void Travel(Bus bus, int kilo)
        {
            TimeSpan t = DateTime.Now - bus.dateOfLastTreat; //the span of time since the last treatment
            if (bus.TreatmentKM > 20000 || bus.GasKM + kilo > 1200 || t.Days > 365)
                /*if the kilometers since the last treatment are bigger than 2000, or the bus doesnt 
                have enough gas, or its been over a year since the last treatment- the bus can't drive*/
                Console.WriteLine("Can't drive");
            else //if the bus is able to drive
            {
                bus.Kilometers += kilo; //add the kilometers to the bus's mileage
                bus.GasKM += kilo; //add the kilometers to the kilometers sice last refuling
            }
        }

        /* get a bus to treat or reful and do it
         */
        static public void RefulAndTreat(Bus busToTreat)
        {
            Console.WriteLine("Enter 0 to reful and 1 to treat");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0) //if the user picked 0, reful
                busToTreat.GasKM = 0; //update the kilometers since last refuled
            else 
            {
                if (choice == 1) //if the user picked 1, treatment
                {
                    busToTreat.dateOfLastTreat = DateTime.Now; //update the date of the last treatment
                    busToTreat.TreatmentKM = 0; //update the kilometers since last treatment
                }
                else //if the user picked something else
                    Console.WriteLine("ERROR");
            }
        }

        /* get a list of buses and print the bus number and date of start of all of them
         */
        static public void PrintBuses(List<Bus> buses)
        {
            for (int i = 0; i < buses.Count(); i++) //pass all the buses in the list and print their details
            {
                char[] c = buses[i].NumBus.ToCharArray(); //convert the number of the bus to an array of chars
                if (buses[i].DateOfStart.Year < 2018) //if the date of start of the bus is before 2018
                {
                    Console.WriteLine("The number of the bus " + c[0] + c[1] + "-" + c[2] + c[3] + c[4] + "-" + c[5] + c[6]); //print the number in 7-digits format
                }
                else //if the date of start of the bus is after 2018
                {
                    Console.WriteLine("The number of the bus " + c[0] + c[1] + c[2] + "-" + c[3] + c[4] + "-" + c[5] + c[6] + c[7]); //print the number in 8-digits format
                }
                Console.WriteLine("The mileage " + buses[i].Kilometers); //print the mileage of the bus
            }
        }
        static void Main(string[] args)
        {
            int option;
            List<Bus> buses = new List<Bus>(); 
            do
            {
                Console.WriteLine("Enter a number");
                option = int.Parse(Console.ReadLine());
                Menu op = (Menu)option;
                Bus bus = new Bus();
                switch (op)
                {
                    case Menu.add:
                        {
                            Console.WriteLine("Enter number of bus and date of start");
                            string numBus1 = Console.ReadLine();
                            DateTime dateOfStart = DateTime.Parse(Console.ReadLine());
                            int convertNum;
                            bool check1 = int.TryParse(numBus1, out convertNum); //try to convert the number of bus to int to see if its legal
                            if(check1) //if the number is legal
                            {
                                if ((dateOfStart.Year < 2018 && numBus1.Length == 7) || (dateOfStart.Year >= 2018 && numBus1.Length == 8))
                                {//check if the lengh of the number is legal according the year
                                    Bus addBus = new Bus(numBus1, dateOfStart); //if its legal, create a new bus
                                    buses.Add(addBus); //add the new bus to the list
                                }
                            }
                            else
                                Console.WriteLine("ERROR num of bus");
                            break;
                        }
                    case Menu.travel:
                        {
                            Console.WriteLine("Enter number of bus");
                            string numBus2 = Console.ReadLine(); 
                            int kilo = rand.Next(); //equals a random number
                            bool check2 = CheckIfBusExist(buses, numBus2, out bus); //call CheckIfBusExist function to check if the bus exist in the list
                            if (!check2) //if the bus is not in the list
                                Console.WriteLine("Number of bus doesn't exist");
                            else //if the bus exist in the list
                                Travel(bus, kilo); //call Travel function to complete the travel
                            break;
                        }
                    case Menu.treat:
                            Console.WriteLine("Enter number of bus");
                            string numBus = Console.ReadLine();
                            bool check = CheckIfBusExist(buses, numBus, out bus); //call CheckIfBusExist function to check if the bus exist in the list
                            if (!check) //if the bus is not exist in the list
                                Console.WriteLine("Number of bus doesn't exist");
                            else //if the bus exist in the list
                                RefulAndTreat(bus); //call RefulAndTreat function to treat the bus
                        break;
                    case Menu.showKL:
                            PrintBuses(buses); //call PrintBuses function to print the details of the buses
                            break;
                    case Menu.exit:
                            break;
                    default:
                        break;
                }
            } while (option != 4); //run as long as the user doesn't pick 4- exit
        }
    }
}
