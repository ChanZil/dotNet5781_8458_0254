using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DLAPI;
using BLAPI;

namespace BL
{
    public class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public IEnumerable<BO.BOLine> GetAllBOLines()
        {
            return from item in dl.GetAllLines()
                   select GetLine(item.Id);
        }
        //public IEnumerable<BO.BOLine> GetAllLinesBy(Predicate<BO.BOLine> predicate)
        //{

        ////}
        public BO.BOLine GetLine(int id)
        {
            DO.Line line = dl.GetLine(id);
            DO.LineTrip lineTrip = dl.GetLineTrip(id);
            IEnumerable<DO.LineStation> lineStations = from lineStation in dl.GetAllLineStations()
                                                       where lineStation.LineId == id
                                                       select lineStation; //a collection of all lineStations of the recieved line id from DL
            IEnumerable<DO.Station> DOstations = from lineStation in lineStations //a collection of all stations from DL, according the collection of the lineStations
                                                 select dl.GetStation(lineStation.Station);
            IEnumerable<BO.BOStationInLine> BOstations = from station in DOstations //convert the collection of the DOstations to BOStationInLine
                                                 select StationDoBoAdapter(station);
            BO.BOLine boline = new BO.BOLine { Id = line.Id, Code = line.Code, Area = (BO.Areas)line.Area, StartAt = lineTrip.StartAt, FinishAt = lineTrip.FinishAt, Frequency = lineTrip.Frequency, ListOfStationInLine = BOstations };
            return boline;
        }
        public void CreateLine(int code, DO.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfStationInLine)
        {
            BO.BOLine bl = new BO.BOLine { Code = code, Area = (BO.Areas)area, StartAt = startAt, FinishAt = finishAt, Frequency = frequency, ListOfStationInLine = listOfStationInLine };
            dl.CreateLine(bl.Code, area, listOfStationInLine.First().Code, listOfStationInLine.Last().Code);
            try
            {
                dl.CreateLineTrip(bl.Code, bl.StartAt, bl.FinishAt, bl.Frequency);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdExeption("Bad line id", ex);
            }
        }

        //public void UpdateLine(BO.BOLine line)
        //{

        //}

        //public void DeleteLine(BO.BOLine bOLine)
        //{
        //    //foreach (BO.BOStationInLine item in bOLine.ListOfStationInLine)
        //    //{
        //    //    DeleteStationInLine(item); //delete adStation linestation
        //    //}
        //    //try
        //    //{
        //    //    dl.DeleteLine(bOLine.Id);
        //    //    dl.DeleteLineTrip(bOLine.Id);
        //    //}
        //    //catch (DO.BadLineIdException ex)
        //    //{
        //    //    throw new BO.BadLineIdExeption("Bad line id", ex);
        //    //}
        //    ////remove from list
        //}
        #endregion Line
        #region StationInLine
        BO.BOStationInLine StationDoBoAdapter(DO.Station stationInLineDO)
        {
            BO.BOStationInLine stationBO = new BO.BOStationInLine();
            DO.Station stationDO;
            int id = stationInLineDO.Code;
            try
            {
                stationDO = dl.GetStation(id);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
            stationBO.Code = stationDO.Code;
            stationBO.Name = stationDO.Name;
            stationBO.Longitude = stationDO.Longitude;
            stationBO.Latitude = stationDO.Latitude;
            stationBO.Address = stationDO.Address;
            return stationBO;
        }
        public IEnumerable<BO.BOStationInLine> GetAllStationInLine()
        {
            var listOfStations = dl.GetAllStations();
            return from item in listOfStations
                   select StationDoBoAdapter(item);
        }
        public IEnumerable<BO.BOStationInLine> GetAllStationInLineByCodeLine(int code)
        {
            var listOfLineStations = dl.GetAllLineStationsBy(s=> s.LineId==code);
            var listOfStations = from lineStation in listOfLineStations
                                 from station in dl.GetAllStations()
                                 where station.Code == lineStation.Station
                                 select station;
            return from item in listOfStations
                   select StationDoBoAdapter(item);
        }

        public BO.BOStationInLine GetStationInLine(int id)
        {
            try
            {
                DO.Station station = dl.GetStation(id);
                return StationDoBoAdapter(station);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("bad station id", ex);
            }
        }
        //public void CreateStationInLine(int code, string name, double longitude, double latitude, string address)
        //{
        //    try
        //    {
        //        dl.CreateStation(code, name, longitude, latitude, address);
        //    }
        //    catch (DO.BadStationIdException ex)
        //    {
        //        throw new BO.BadStationIdException("bad station id", ex);
        //    }
        //}
        //public void UpdateStationInLine(BO.BOStationInLine stationInLine)
        //{
        //    try
        //    {
        //        dl.UpdateStation(dl.GetStation(stationInLine.Code));
        //    }
        //    catch (DO.BadStationIdException ex)
        //    {
        //        throw new BO.BadStationIdException("bad station id", ex);
        //    }
        //}
        //public void DeleteStationInLine(BO.BOStationInLine stationInLine)
        //{
        //    try
        //    {
        //        dl.DeleteStation(stationInLine.Code);
        //    }
        //    catch (DO.BadStationIdException ex)
        //    {
        //        throw new BO.BadStationIdException("bad station id", ex);
        //    }
        //}
        #endregion StationInLine
        #region Station
        public IEnumerable<BO.BOStation> GetAllStations()
        {
            return from station in dl.GetAllStations()
                   select new BO.BOStation
                   {
                       Code = station.Code,
                       Name = station.Name,
                       Address = station.Address,
                       Longitude = station.Longitude,
                       Latitude = station.Latitude,
                       ListOfLines = GetAllLineStationByStationId(station.Code)
                   };
        }
        //public IEnumerable<BO.BOStation> GetAllGetAllStationsBy(Predicate<BO.BOStation> predicate)
        //{

        //}
        //public BO.BOLine GetStation(int id)
        //{

        //}
        public void CreateStation(BO.BOStation station)
        {
            try
            {
                dl.CreateStation(station.Code, station.Name, station.Longitude, station.Latitude, station.Address);
            }
            catch(DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("קוד תחנה כבר קיים", ex);
            }
        }
        public void UpdateStation(BO.BOStation station)
        {
            DO.Station doStation = new DO.Station
            {
                Code = station.Code,
                Name = station.Name,
                Address = station.Address,
                Longitude = station.Longitude,
                Latitude = station.Latitude
            };
            try
            {
                dl.UpdateStation(doStation);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("תחנה לא קיימת", ex);
            }
        }
        public void DeleteStation(int id)
        { 
            var lineStations = dl.GetAllLineStationsBy(s => s.Station == id);
            foreach (DO.LineStation lineStation in lineStations)
            {
                if (lineStation.PrevStation != 0)
                    dl.GetLineStation(lineStation.LineId, lineStation.PrevStation).NextStation = lineStation.NextStation;
                if (lineStation.NextStation != 0)
                    dl.GetLineStation(lineStation.LineId, lineStation.NextStation).PrevStation = lineStation.PrevStation;
                DO.LineStation pointerLineStation = lineStation;
                while (pointerLineStation.NextStation != 0)
                {
                    pointerLineStation = dl.GetLineStation(lineStation.LineId, pointerLineStation.NextStation);
                    pointerLineStation.LineStationIndex--;
                }
                if (lineStation.PrevStation != 0)
                    dl.DeleteAdjacentStations(lineStation.PrevStation, lineStation.Station);
                if (lineStation.NextStation != 0)
                    dl.DeleteAdjacentStations(lineStation.Station, lineStation.NextStation);
                if (lineStation.PrevStation != 0 && lineStation.NextStation != 0)
                    dl.CreateAdjacentStations(lineStation.PrevStation, lineStation.NextStation, 0, new TimeSpan(0, 0, 0));
                //dl.DeleteLineStation(lineStation.LineId, lineStation.Station);
            }
            DO.LineStation pointer = dl.GetAllLineStationsBy(s => s.Station == id).First();
            while(pointer!=null)
            {
                
                try
                {
                    dl.DeleteLineStation(pointer.LineId, pointer.Station);
                    pointer = dl.GetAllLineStationsBy(s => s.Station == id).First();
                }
                catch(Exception ex)
                {
                    break;
                }
                
            }
            dl.DeleteStation(id);
        }
        #endregion Station
        #region  LineStation
        public IEnumerable<BO.BOLineStation> GetAllLineStationByStationId(int stationId)
        {
            return from lineStation in dl.GetAllLineStationsBy(l => l.Station == stationId)
                   let line = dl.GetLine(lineStation.LineId)
                   select new BO.BOLineStation
                   {
                       Id = line.Id,
                       Code = line.Code,
                       Area = (BO.Areas)line.Area,
                       LineStationIndex = lineStation.LineStationIndex
                   };
        }
        //public BO.BOLineStation GetLineStation(int id)
        //{

        //}
        //public void CreateLineStation(DO.Line line)
        //{

        //}
        //public void DeleteLineStation(DO.Line line)
        //{

        //}
        #endregion  LineStation
        #region Bus
        BO.BOBus BusDoBoAdapter(DO.Bus busDO)
        {
            BO.BOBus busBO = new BO.BOBus();
            busBO.LicenseNum = busDO.LicenseNum;
            busBO.FromDate = busDO.FromDate;
            busBO.TotalTrip = busDO.TotalTrip;
            busBO.FuelRemain = busDO.FuelRemain;
            busBO.Status = (BO.BusStatus)busDO.Status;
            return busBO;
        }
        public IEnumerable<BO.BOBus> GetAllBOBuses()
        {
            var busDl = dl.GetAllBuses();
            return from item in busDl
                   select BusDoBoAdapter(item);
        }
        //public IEnumerable<BO.BOBus> GetAllBusesBy(Predicate<BO.BOBus> predicate)
        //{

        //}
        public BO.BOBus GetBus(int id)
        {
            var dOBus = dl.GetBus(id);
            return BusDoBoAdapter(dOBus);
        }
        public void CreateBus(int id, DateTime fromDate, double total, double fuelRemain, BO.BusStatus status)
        {
            DO.Bus dOBus = new DO.Bus
            {
                LicenseNum = id,
                FromDate = fromDate,
                TotalTrip = total,
                FuelRemain = fuelRemain,
                Status = (DO.BusStatus)status
            };
            try
            {
                dl.CreateBus(dOBus);
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("מספר אוטובוס קיים", ex);
            }
        }
        public void UpdateBus(BO.BOBus bus)
        {
            DO.Bus dOBus = new DO.Bus
            {
                LicenseNum = bus.LicenseNum,
                FromDate = bus.FromDate,
                TotalTrip = bus.TotalTrip,
                FuelRemain = bus.FuelRemain,
                Status = (DO.BusStatus)bus.Status
            };
            try
            {
                dl.UpdateBus(dOBus);
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("מספר הרישוי כבר קיים במערכת", ex);
            }
            
        }
        public void DeleteBus(BO.BOBus bOBus)
        {
            try
            {
                dl.DeleteBus(bOBus.LicenseNum);
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException("אוטובוס לא קיים", ex);
            }
            
        }
        #endregion Bus
    }
}


