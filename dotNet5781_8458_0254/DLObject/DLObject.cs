using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DLAPI;
using DS;
using DO;

namespace DL
{
    sealed class DLObject : IDL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion singelton
        #region Bus
        public IEnumerable<DO.Bus> GetAllBuses()
        {
            return from bus in DataSource.listBuses
                   select bus.Clone();
        }
        public IEnumerable<DO.Bus> GetAllBusesBy(Predicate<DO.Bus> predicate)
        {
            throw new NotImplementedException();
        }
        public void CreateBus(DO.Bus bus)
        {
            if (DataSource.listBuses.FirstOrDefault(p => p.LicenseNum == bus.LicenseNum) != null)
                throw new DO.BadBusIdException(bus.LicenseNum, "Duplicate bus ID");
            DataSource.listBuses.Add(bus.Clone());
        }
        public DO.Bus GetBus(int id)
        {
            DO.Bus bus = DataSource.listBuses.Find(p => p.LicenseNum == id);
            if (bus != null)
                return bus.Clone();
            else
                throw new DO.BadBusIdException(id, $"bad bus id: {id}");
        }
        public void UpdateBus(DO.Bus bus)
        {
            DO.Bus b = DataSource.listBuses.Find(p => p.LicenseNum == bus.LicenseNum);
            if (b != null)
            {
                DataSource.listBuses.Remove(b);
                DataSource.listBuses.Add(bus.Clone());
            }
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus id: {bus.LicenseNum}");
        }
        public void UpdateBus(int id, Action<DO.Bus> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteBus(int id)
        {
            DO.Bus bus = DataSource.listBuses.Find(p => p.LicenseNum == id);
            if (bus != null)
                DataSource.listBuses.Remove(bus);
            else
                throw new DO.BadBusIdException(id, $"bad bus id: {id}");
        }
        #endregion Bus
        #region Station
        public IEnumerable<DO.Station> GetAllStations()
        {
            return from station in DataSource.listStations
                   select station.Clone();
        }
        public IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate)
        {
            return from station in DataSource.listStations
                   where predicate(station)
                   select station.Clone();
        }
        public void CreateStation(int code, string name, double longitude, double latitude, string address)
        {
            Station station = new Station { Code = code, Name = name, Longitude = longitude, Latitude = latitude, Address = address };
            if (DataSource.listStations.FirstOrDefault(p => p.Code == station.Code) != null)
                throw new DO.BadStationIdException(station.Code, "Duplicate station ID");
            DataSource.listStations.Add(station.Clone());
        }
        public DO.Station GetStation(int id)
        {
            DO.Station station = DataSource.listStations.Find(p => p.Code == id);
            if (station != null)
                return station.Clone();
            else
                throw new DO.BadStationIdException(id, $"bad station id: {id}");
        }
        public void UpdateStation(DO.Station station)
        {
            DO.Station b = DataSource.listStations.Find(p => p.Code == station.Code);
            if (b != null)
            {
                DataSource.listStations.Remove(b);
                DataSource.listStations.Add(station.Clone());
            }
            else
                throw new DO.BadStationIdException(station.Code, $"bad person id: {station.Code}");
        }
        public void UpdateStation(int id, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int id)
        {
            DO.Station station = DataSource.listStations.Find(p => p.Code == id);
            if (station != null)
                DataSource.listStations.Remove(station);
            else
                throw new DO.BadStationIdException(id, $"bad station id: {id}");
        }
        #endregion Station
        #region Line
        public IEnumerable<DO.Line> GetAllLines()
        {
            return from line in DataSource.listLines
                   select line.Clone();
        }
        public IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate)
        {
            throw new NotImplementedException();
        }
        public void CreateLine(int code, Areas area, int firstS, int lastS)
        {
            Line line = new Line { Id = DORunNumbers.RunIdLine, Code = code, Area = area, FirstStation = firstS, LastStation = lastS };
            DORunNumbers.RunIdLine++;
            DataSource.listLines.Add(line.Clone());
        }
        public DO.Line GetLine(int id)
        {
            DO.Line line = DataSource.listLines.Find(p => p.Id == id);
            if (line != null)
                return line.Clone();
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line b = DataSource.listLines.Find(p => p.Id == line.Id);
            if (b != null)
            {
                DataSource.listLines.Remove(b);
                DataSource.listLines.Add(line.Clone());
            }
            else
                throw new DO.BadLineIdException(line.Id, $"bad line id: {line.Id}");
        }
        public void UpdateLine(int id, Action<DO.Line> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int id)
        {
            DO.Line line = DataSource.listLines.Find(p => p.Id == id);
            if (line != null)
                DataSource.listLines.Remove(line);
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        #endregion Line
        #region LineStation
        public IEnumerable<DO.LineStation> GetAllLineStations()
        {
            return from lineStation in DataSource.listLineStations
                   select lineStation.Clone();
        }
        public IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.LineStation> predicate)
        {
            return from lineStation in DataSource.listLineStations
                   where predicate(lineStation)
                   select lineStation.Clone();
        }
        public void CreateAllLineStations(int lineId, int stationId, int index, int prev, int next)
        {
            if (DataSource.listLineStations.FirstOrDefault(p => p.LineId == lineId && p.Station == stationId) != null)
                throw new DO.BadLineStationException(lineId, stationId, "Duplicate LineStation");
            DO.LineStation lineStation = new DO.LineStation() { LineId = lineId, Station = stationId, LineStationIndex = index, PrevStation = prev, NextStation = next };
            DataSource.listLineStations.Add(lineStation.Clone());
        }
        public DO.LineStation GetLineStation(int lineId, int stationId)
        {
            DO.LineStation lineStation = DataSource.listLineStations.Find(p => p.LineId == lineId && p.Station == stationId);
            if (lineStation != null)
                return lineStation.Clone();
            else
                throw new DO.BadLineStationException(lineId, stationId, $", bad line station. code line: {lineId}, code station: {stationId}");
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            DO.LineStation b = DataSource.listLineStations.Find(p => p.LineId == lineStation.LineId && p.Station == lineStation.Station);
            if (b != null)
            {
                DataSource.listLineStations.Remove(b);
                DataSource.listLineStations.Add(lineStation.Clone());
            }
            else
                throw new DO.BadLineStationException(lineStation.LineId, lineStation.Station, "Duplicate LineStation");
        }
        public void UpdateLineStations(int lineId, int stationId, Action<DO.LineStation> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineStation(int lineId, int stationId)
        {
            DO.LineStation lineStations = DataSource.listLineStations.Find(p => p.LineId == lineId && p.Station == stationId);
            if (lineStations != null)
                DataSource.listLineStations.Remove(lineStations);
            else
                throw new DO.BadLineStationException(lineId, stationId, $", bad line station. code line: {lineId}, code station: {stationId}");
        }
        #endregion LineStation
        #region AdjacentStations
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            return from adjacentStations in DataSource.listAdjacentStations
                   select adjacentStations.Clone();
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate)
        {
            return from adjacentStations in DataSource.listAdjacentStations
                   where predicate(adjacentStations)
                   select adjacentStations.Clone();
        }
        public void CreateAdjacentStations(int codeStation1, int codeStation2, double distance, TimeSpan time)
        {
            if (DataSource.listAdjacentStations.FirstOrDefault(p => p.Station1 == codeStation1 && p.Station2 == codeStation2) != null)
                throw new DO.BadAdjacentStationsException(codeStation1, codeStation2, "Duplicate adjacentStations");
            DO.AdjacentStations adjacentStations = new DO.AdjacentStations() { Station1 = codeStation1, Station2 = codeStation2, Distance = distance, Time = time };
            DataSource.listAdjacentStations.Add(adjacentStations.Clone());
        }
        public DO.AdjacentStations GetAdjacentStations(int station1, int station2)
        {
            DO.AdjacentStations adjacentStations = DataSource.listAdjacentStations.Find(p => p.Station1 == station1 && p.Station2 == station2);
            if (adjacentStations != null)
                return adjacentStations.Clone();
            else
                throw new DO.BadAdjacentStationsException(station1, station2, $"bad adjacentStations. code station 1: {station1}, code station 2: {station2}");
        }
        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            DO.AdjacentStations b = DataSource.listAdjacentStations.Find(p => p.Station1 == adjacentStations.Station1 && p.Station2 == adjacentStations.Station2);
            if (b != null)
            {
                DataSource.listAdjacentStations.Remove(b);
                DataSource.listAdjacentStations.Add(adjacentStations.Clone());
            }
            else
                throw new DO.BadAdjacentStationsException(adjacentStations.Station1, adjacentStations.Station2, "Duplicate adjacentStations");
        }
        public void UpdateAdjacentStations(int codeStation1, int codeStation2, Action<DO.AdjacentStations> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteAdjacentStations(int codeStation1, int codeStation2)
        {
            DO.AdjacentStations adjacentStations = DataSource.listAdjacentStations.Find(p => p.Station1 == codeStation1 && p.Station2 == codeStation2);
            if (adjacentStations != null)
                DataSource.listAdjacentStations.Remove(adjacentStations);
            else
                throw new DO.BadAdjacentStationsException(codeStation1, codeStation2, $"bad adjacentStations. code station 1: {codeStation1}, code station 2: {codeStation2}");
        }
        #endregion AdjacentStations
        #region LineTrip

        public IEnumerable<DO.LineTrip> GetAllLineTrip()
        {
            return from lineTrip in DataSource.listLineTrip
                   select lineTrip.Clone();
        }
        public IEnumerable<DO.LineTrip> GetAllLineTripBy(Predicate<DO.LineTrip> predicate)
        {
            throw new NotImplementedException();
        }
        public void CreateLineTrip(int code, TimeSpan startAt, TimeSpan finishAt, TimeSpan frequency)
        {
            LineTrip lineTrip = new LineTrip { LineId = code, StartAt = startAt, FinishAt = finishAt, Frequency = frequency };
            if (DataSource.listLineTrip.FirstOrDefault(p => p.LineId == lineTrip.LineId) != null)
                throw new DO.BadLineIdException(lineTrip.LineId, $"bad line id: {lineTrip.LineId}");
            DataSource.listLineTrip.Add(lineTrip.Clone());
        }
        public DO.LineTrip GetLineTrip(int id)
        {
            DO.LineTrip lineTrip = DataSource.listLineTrip.Find(p => p.LineId == id);
            if (lineTrip != null)
                return lineTrip.Clone();
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public void UpdateLineTrip(DO.LineTrip lineTrip)
        {
            DO.LineTrip b = DataSource.listLineTrip.Find(p => p.LineId == lineTrip.LineId);
            if (b != null)
            {
                DataSource.listLineTrip.Remove(b);
                DataSource.listLineTrip.Add(lineTrip.Clone());
            }
            else
                throw new DO.BadLineIdException(lineTrip.LineId, $"bad line id: {lineTrip.LineId}");
        }
        public void UpdateLineTrip(int id, Action<DO.LineTrip> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineTrip(int id)
        {
            DO.LineTrip lineTrip = DataSource.listLineTrip.Find(p => p.LineId == id);
            if (lineTrip != null)
                DataSource.listLineTrip.Remove(lineTrip);
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }

        #endregion LineTrip
    }
}
