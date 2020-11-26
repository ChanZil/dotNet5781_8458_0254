using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8458_0254
{
    class Program
    {
        enum Menu { add, remove, search, print, exit}
        static void Main(string[] args)
        {
            BusLineCollection busLines = new BusLineCollection();
            List<BusStopLine> stations = new List<BusStopLine>(); //contains 40 stations
            for (int i = 0; i < 40; i++) //pass the array of the stations 
            {
                BusStopLine b = new BusStopLine();
                stations.Add(b);
            }
            for (int i = 0; i < 10; i++) //create 10 new lines
            {
                List<BusStopLine> b = new List<BusStopLine>(); //new list of station for each line
                for (int j = 0; j < 4; j++) //each line gets 4 stations
                    b.Add(stations[i * 4 + j]); //add a station from the array to the list
                BusLine busLine = new BusLine(i, b, "center"); //create a new line with the list
                busLines.AddBusLine(busLine); //add the new line to the collection
            }
        int option;
            do
            {
                Console.WriteLine("Enter a number");
                option = int.Parse(Console.ReadLine());
                Menu op = (Menu)option;
                switch (op)
                {
                    case Menu.add:
                        {
                            Console.WriteLine("Enter 0 to add a bus line, 1 to add a station to a bus line");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 0) 
                            {
                                Console.WriteLine("Enter bus line");
                                int line = int.Parse(Console.ReadLine());
                                BusLine b = new BusLine(line);
                                busLines.AddBusLine(b);
                            }
                            if (choice == 1) 
                            {
                                Console.WriteLine("Enter bus line");
                                int line = int.Parse(Console.ReadLine());
                                BusStopLine b = new BusStopLine();
                                stations.Add(b);
                                foreach(BusLine item in busLines)
                                    if(item.BusLineCode==line)
                                    {
                                        item.AddStation(b);
                                        break;
                                    }
                            }
                            break;
                        }
                    case Menu.remove:
                        {
                            Console.WriteLine("Enter 0 to remove a bus line, 1 to remove a station from a bus line");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 0)
                            {
                                Console.WriteLine("Enter a bus line to remove");
                                int line = int.Parse(Console.ReadLine());
                                foreach (BusLine item in busLines)
                                    if (item.BusLineCode == line)
                                    {
                                        busLines.RemoveBusLine(item);
                                        break;
                                    }
                            }
                            if (choice == 1)
                            {
                                Console.WriteLine("Enter a bus line and a station");
                                int line = int.Parse(Console.ReadLine());
                                int station = int.Parse(Console.ReadLine());
                                foreach (BusLine item1 in busLines)
                                    if (item1.BusLineCode == line)
                                        foreach (BusStopLine item2 in item1.Stations)
                                            if (item2.BusStationKey == station)
                                            {
                                                item1.RemoveStation(item2);
                                                break;
                                            }
                            }
                            break;
                        }
                    case Menu.search:
                        {
                            Console.WriteLine("");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 0)
                            {
                                Console.WriteLine("");
                                int station = int.Parse(Console.ReadLine());
                                foreach(BusLine item1 in busLines)
                                    foreach(BusStopLine item2 in item1.Stations)
                                        if(item2.BusStationKey==station)
                                        {
                                            Console.WriteLine(item1.ToString());
                                            break;
                                        }
                            }
                            if (choice == 1)
                            {
                                Console.WriteLine("Enter 2 stations");
                                int station1 = int.Parse(Console.ReadLine());
                                int station2 = int.Parse(Console.ReadLine());
                                BusLineCollection b = new BusLineCollection();
                                foreach (BusLine item1 in busLines)
                                {
                                    bool flag = false;
                                    foreach (BusStopLine item2 in item1.Stations)
                                    {
                                        if (item2.BusStationKey == station1)
                                            flag = true;
                                        if (item2.BusStationKey == station2 && flag)
                                        {
                                            b.AddBusLine(item1);
                                            break;
                                        }
                                    }
                                }
                                List<BusLine> l = b.TimeOfLines();
                                foreach(BusLine item in l)
                                    Console.WriteLine(item.ToString());

                            }
                                break;
                        }
                    case Menu.print:
                        {
                            Console.WriteLine("Enter 0 to print the bus lines and 1 to print the stations");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 0)
                            {
                                foreach(BusLine item in busLines)
                                    Console.WriteLine(item.ToString());
                            }
                            if (choice == 1)
                            {
                                foreach(BusStopLine item1 in stations)
                                {
                                    Console.WriteLine(item1.ToString() + '\n');
                                    foreach (BusLine item2 in busLines)
                                        if (item2.IsExist(item1))
                                            Console.WriteLine(item2.BusLineCode + " ");
                                    Console.WriteLine('\n');
                                }
                            }
                                break;
                        }
                    case Menu.exit:
                        {
                            break;
                        }
                    default:
                        break;
                }
            } while (option != 4);
        }
    }
}
