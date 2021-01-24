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
            var x = dl.GetAllLines();
            return from line in dl.GetAllLines()
                   select GetLine(line.Id);
        }
        public BO.BOLine GetLine(int id)
        {
            try 
            {
                var line = dl.GetLine(id);
                var lineTrip = dl.GetLineTrip(id);
                var x = GetAllStationInLineByCodeLine(id);
                return new BO.BOLine
                {
                    Id = line.Id,
                    Code = line.Code,
                    Area = (BO.Areas)line.Area,
                    StartAt = lineTrip.StartAt,
                    FinishAt = lineTrip.FinishAt,
                    Frequency = lineTrip.Frequency,
                    ListOfStationInLine = GetAllStationInLineByCodeLine(id)
                };
            } 
            catch (DO.BadLineIdException ex) 
            {
                throw new BO.BadLineIdExeption(ex.Message, ex);
            }
        }
        public int CreateLine(int code, BO.Areas area, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency, IEnumerable<BO.BOStationInLine> listOfStationInLine)
        {
            try
            {
                int id = dl.CreateLine(code, (DO.Areas)area, listOfStationInLine.First().Code, listOfStationInLine.Last().Code);
                dl.CreateLineTrip(id, startAt, finishAt, frequency);
                int i = 0;
                foreach (BO.BOStationInLine bOStationInLine in listOfStationInLine)
                {
                    int prev = 0, next = 0;
                    if (bOStationInLine.Code != listOfStationInLine.First().Code)
                        prev = listOfStationInLine.ElementAt(i - 1).Code;
                    if (bOStationInLine.Code != listOfStationInLine.Last().Code)
                        prev = listOfStationInLine.ElementAt(i + 1).Code;
                    CreateStationInLine(id, bOStationInLine.Code, bOStationInLine.Distance, bOStationInLine.Time, i, prev, next);
                    i++;
                }
                return id;
            } 
            catch (DO.BadLineIdException ex) 
            {
                throw new BO.BadLineIdExeption(ex.Message, ex);
            }
        }
        public void UpdateLine(BO.BOLine line)
        {
            BO.BOLine bOLine = line;
            DeleteLine(line);
            CreateLine(bOLine.Code, bOLine.Area, bOLine.StartAt, bOLine.FinishAt, bOLine.Frequency, bOLine.ListOfStationInLine);
        }
        public void DeleteLine(BO.BOLine bOLine)
        {
            try
            {
                var listStationsInLine = bOLine.ListOfStationInLine.ToList();
                var pointer = listStationsInLine.FirstOrDefault();
                while (pointer != null)
                {
                    DeleteStationInLine(pointer, bOLine.Id);
                    listStationsInLine.RemoveAt(0);
                    pointer = listStationsInLine.FirstOrDefault();
                }
                dl.DeleteLine(bOLine.Id);
                dl.DeleteLineTrip(bOLine.Id);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdExeption(ex.Message, ex);
            }
        }
        #endregion Line
        #region StationInLine
        public IEnumerable<BO.BOStationInLine> GetAllStationInLine()
        {
            return from lineStatiion in dl.GetAllLineStations()
                   select GetStationInLine(lineStatiion.LineId, lineStatiion.Station);
        }
        public IEnumerable<BO.BOStationInLine> GetAllStationInLineByCodeLine(int code) 
        {
            return from lineStatiion in dl.GetAllLineStationsBy(l => l.LineId == code)
                   select GetStationInLine(code, lineStatiion.Station);
        }
        public BO.BOStationInLine GetStationInLine(int lineId, int stationId)
        {
            try
            {
                DO.LineStation lineStation = dl.GetLineStation(lineId, stationId);
                DO.Station station = dl.GetStation(stationId);
                double distance = 0;
                TimeSpan time = new TimeSpan(0, 0, 0);
                if (lineStation.NextStation != 0)
                {
                    DO.AdjacentStations adjacentStation = dl.GetAdjacentStations(lineId, stationId, lineStation.NextStation);
                    distance = adjacentStation.Distance;
                    time = adjacentStation.Time;
                }
                return new BO.BOStationInLine
                {
                    Code = station.Code,
                    Name = station.Name,
                    Address = station.Address,
                    Distance = distance,
                    Time = time
                };
            }
            catch(DO.BadLineStationException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
            }
            catch(DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
            }
            catch(DO.BadAdjacentStationsException ex)
            {
                throw new BO.BadAdjacentStationsIdException(ex.Message, ex);
            }
        }
        public void DeleteStationInLine(BO.BOStationInLine stationInLine, int lineId)
        {
            try 
            {
                DO.LineStation lineStation = dl.GetLineStation(lineId, stationInLine.Code);
                if (lineStation.PrevStation != 0)
                {
                    var updatedLineStation = dl.GetLineStation(lineStation.LineId, lineStation.PrevStation);
                    updatedLineStation.NextStation = lineStation.NextStation;
                    dl.UpdateLineStation(updatedLineStation);
                }
                if (lineStation.NextStation != 0)
                {
                    var updatedLineStation = dl.GetLineStation(lineStation.LineId, lineStation.NextStation);
                    updatedLineStation.PrevStation = lineStation.PrevStation;
                    dl.UpdateLineStation(updatedLineStation);
                }
                DO.LineStation pointerLineStation = dl.GetLineStation(lineId, stationInLine.Code);
                while (pointerLineStation.NextStation != 0)
                {
                    pointerLineStation = dl.GetLineStation(lineStation.LineId, pointerLineStation.NextStation);
                    pointerLineStation.LineStationIndex--;
                }
                if (lineStation.PrevStation != 0)
                    dl.DeleteAdjacentStations(lineStation.LineId, lineStation.PrevStation, lineStation.Station);
                if (lineStation.NextStation != 0)
                    dl.DeleteAdjacentStations(lineStation.LineId, lineStation.Station, lineStation.NextStation);
                if (lineStation.PrevStation != 0 && lineStation.NextStation != 0)
                    dl.CreateAdjacentStations(lineStation.LineId, lineStation.PrevStation, lineStation.NextStation, 0, new TimeSpan(0, 0, 0));
                dl.DeleteLineStation(lineStation.LineId, lineStation.Station);
            }
            catch(DO.BadLineStationException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
            }
            catch(DO.BadAdjacentStationsException ex)
            {
                throw new BO.BadAdjacentStationsIdException(ex.Message, ex);
            }
        }
        public void CreateStationInLine(int lineId, int stationId, double distance, TimeSpan time, int index, int prev, int next)
        {
            try
            {
                dl.CreateLineStation(lineId, stationId, index, prev, next);
                if (next != 0)
                    dl.CreateAdjacentStations(lineId, stationId, next, distance, time);
            }
            catch(DO.BadLineStationException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
            }
            catch (DO.BadAdjacentStationsException ex)
            {
                throw new BO.BadAdjacentStationsIdException(ex.Message, ex);
            }
        }
        public void UpdateStationInLine(BO.BOStationInLine stationInLine, int lineId, int index, int prev, int next)
        {
            DeleteStationInLine(stationInLine, lineId);
            CreateStationInLine(lineId, stationInLine.Code, stationInLine.Distance, stationInLine.Time, index, prev, next);
        }
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
        public void CreateStation(BO.BOStation station)
        {
            try
            {
                dl.CreateStation(station.Code, station.Name, station.Longitude, station.Latitude, station.Address);
            }
            catch(DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
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
                throw new BO.BadStationIdException(ex.Message, ex);
            }
        }
        public void DeleteStation(int id)
        {
            try
            {
                DO.LineStation lineStationPointer = dl.GetAllLineStationsBy(s => s.Station == id).FirstOrDefault();
                while(lineStationPointer != null)
                {
                    if (lineStationPointer.PrevStation != 0)
                    {
                        var x = dl.GetLineStation(lineStationPointer.LineId, lineStationPointer.PrevStation);
                        x.NextStation = lineStationPointer.NextStation;
                        dl.UpdateLineStation(x);
                    }
                    if (lineStationPointer.NextStation != 0)
                    {
                        var x = dl.GetLineStation(lineStationPointer.LineId, lineStationPointer.NextStation);
                        x.PrevStation = lineStationPointer.PrevStation;
                        dl.UpdateLineStation(x);
                    }
                    DO.LineStation pointer = lineStationPointer;
                    while(pointer.NextStation != 0)
                    {
                        pointer = dl.GetLineStation(lineStationPointer.LineId, pointer.NextStation);
                        pointer.LineStationIndex--;
                    }
                    if (lineStationPointer.PrevStation != 0)
                        dl.DeleteAdjacentStations(lineStationPointer.LineId, lineStationPointer.PrevStation, lineStationPointer.Station);
                    if (lineStationPointer.NextStation != 0)
                        dl.DeleteAdjacentStations(lineStationPointer.LineId, lineStationPointer.Station, lineStationPointer.NextStation);
                    if (lineStationPointer.PrevStation != 0 && lineStationPointer.NextStation != 0)
                        dl.CreateAdjacentStations(lineStationPointer.LineId, lineStationPointer.PrevStation, lineStationPointer.NextStation, 0, new TimeSpan(0, 0, 0));
                    dl.DeleteLineStation(lineStationPointer.LineId, lineStationPointer.Station);
                    lineStationPointer = dl.GetAllLineStationsBy(s => s.Station == id).FirstOrDefault();
                }
                dl.DeleteStation(id);
            }
            catch (DO.BadLineStationException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
            }
            catch (DO.BadAdjacentStationsException ex)
            {
                throw new BO.BadAdjacentStationsIdException(ex.Message, ex);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException(ex.Message, ex);
            }
        }
        #endregion Station
        #region  LineStation
        public IEnumerable<BO.BOLineStation> GetAllLineStationByStationId(int stationId)
        {
            try
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
            catch(DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdExeption(ex.Message, ex);
            }
        }
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
        public BO.BOBus GetBus(int id)
        {
            try
            {
                var dOBus = dl.GetBus(id);
                return BusDoBoAdapter(dOBus);
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException(ex.Message, ex);
            }
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
                throw new BO.BadBusIdException(ex.Message, ex);
            }
        }
        public void UpdateBus(BO.BOBus bus)
        {
            BO.BOBus temp = bus;
            DeleteBus(bus);
            CreateBus(temp.LicenseNum, temp.FromDate, temp.TotalTrip, temp.FuelRemain, temp.Status);
        }
        public void DeleteBus(BO.BOBus bOBus)
        {
            try
            {
                dl.DeleteBus(bOBus.LicenseNum);
            }
            catch(DO.BadBusIdException ex)
            {
                throw new BO.BadBusIdException(ex.Message, ex);
            }
        }
        #endregion Bus
    }
}


