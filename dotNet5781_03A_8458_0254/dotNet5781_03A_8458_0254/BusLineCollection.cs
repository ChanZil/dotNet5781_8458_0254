using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_8458_0254
{
    class BusLineCollection: IEnumerable
    {
        public List<BusLine> busLines = new List<BusLine>();
        public IEnumerator GetEnumerator()
        {
            return busLines.GetEnumerator();
        }
        public void AddBusLine(BusLine busLine) //add a bus line to the collection
        {
            bool flag = false;
            foreach(BusLine item in busLines) //pass busLines list to check if the line is already there
                if (item.BusLineCode == busLine.BusLineCode) //if the line is already there
                    flag = true;
            if (!flag) //if the line is not in the list
                busLines.Add(busLine); //add the line to the list
        }
        public void RemoveBusLine(BusLine busLine) //remove a bus line from the collection
        {
            foreach (BusLine item in busLines) //pass busLines list to find the line
                if (item.BusLineCode == busLine.BusLineCode) //if found the line
                {
                    busLines.RemoveAt(busLines.IndexOf(item)); //remove the line from the list
                    break;
                }
        }
        public List<BusLine> LinesInStation(int codeStation) //get a station code and returns a list of all the lines that pass in this station
        {
            List<BusLine> lines = new List<BusLine>(); //the list of all the lines that pass in the station
            foreach(BusLine item1 in busLines) //pass the list of the lines 
                foreach(BusStopLine item2 in item1.Stations) //pass the list of each line to find the station
                    if (item2.BusStationKey == codeStation) //if found the station
                        lines.Add(item1); //add the line to the list
            if (!lines.Any())
               throw new BusException("No lines in this station");
            else
                return lines;
        }
        public void InsertList(ref List<BusLine> l, BusLine b) //get a number and a list and insert the number in the right place
        {
            foreach(BusLine item in l) //pass the list to find the place of the number
            {
                int compare = b.CompareTo(item); //compare both bus lines according their keys
                if (compare < 0) //if the number is smaller then this item
                {
                    l.Insert(l.IndexOf(item) - 1, b); //insert the number before the item
                    break; 
                }
                l.Add(b); //if didn't find the place of the number, add it to the end of the list
            }
        }
        public List<BusLine> TimeOfLines() //create a list of all the lines ordered by their time from shortest to longest
        {
            List<BusLine> timeLines = new List<BusLine>(); //new list for the lines
            IEnumerable e = busLines;
            IEnumerator enumerator = e.GetEnumerator(); 
            timeLines.Add(busLines[0]); //add a first line to the list
            enumerator.MoveNext(); //move the pointer to the next place in the list
            while (enumerator.MoveNext()) //pass busLines list
            {
                BusLine b = (BusLine)enumerator.Current; //the current line
                InsertList(ref timeLines, b); //insert the current line in the right place in the new list
            }
            return timeLines;
        }
        public BusLine this[int index] //Indexer, return the line by its code
        {
            get {
                foreach (BusLine item in busLines) //pass the list to find the line of the index
                    if (item.BusLineCode == index) //if found the line of the index, return the line
                        return item;
                throw new BusException("Line does not exist"); //if the line is not in this station
            }
        }
    }
}
