using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_8458_0254
{
    static class BusList
    {
        static public List<Bus> buses = new List<Bus>();
        static public Random rand = new Random();
        static BusList()
        {
            buses.Add(new Bus((rand.Next(1000000, 10000000)).ToString(), new DateTime(2000, 10, 2), 100000, 1190, 10000, new DateTime(2020, 6, 10), 0));
            buses.Add(new Bus((rand.Next(1000000, 10000000)).ToString(), new DateTime(2010, 12, 19), 1030970, 1000, 19990, new DateTime(2020, 12, 14), 0));
            buses.Add(new Bus((rand.Next(1000000, 10000000)).ToString(), new DateTime(2011, 5, 7), 123456, 900, 18000, new DateTime(2019, 6, 10), 0));
            buses.Add(new Bus((rand.Next(1000000, 10000000)).ToString(), new DateTime(2010, 8, 13), 837656, 80, 1000, new DateTime(2020, 7, 14), 0));
            buses.Add(new Bus((rand.Next(1000000, 10000000)).ToString(), new DateTime(2017, 2, 2), 987, 10, 5000, new DateTime(2020, 11, 11), 0));
            buses.Add(new Bus((rand.Next(10000000, 100000000)).ToString(), new DateTime(2019, 6, 26), 143, 56, 6000, new DateTime(2020, 4, 18), 0));
            buses.Add(new Bus((rand.Next(10000000, 100000000)).ToString(), new DateTime(2020, 2, 12), 90000, 345, 700, new DateTime(2020, 9, 9), 0));
            buses.Add(new Bus((rand.Next(10000000, 100000000)).ToString(), new DateTime(2020, 11, 11), 12345, 876, 7865, new DateTime(2020, 1, 1), 0));
            buses.Add(new Bus((rand.Next(10000000, 100000000)).ToString(), new DateTime(2019, 9, 9), 7234, 1100, 1234, new DateTime(2020, 7, 4), 0));
            buses.Add(new Bus((rand.Next(10000000, 100000000)).ToString(), new DateTime(2018, 10, 20), 9825, 1010, 18990, new DateTime(2020, 6, 16), 0));
        }
    }
}
