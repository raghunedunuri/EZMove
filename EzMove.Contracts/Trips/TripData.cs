using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class TripRequest
    {
        public string TripID { get; set; }
        public EZMoveCoordinates location { get; set; }
    }

    public class TripPersonUpdate
    {
        public string TripID { get; set; }
        public int EmployeeID { get; set; }
        public string Status { get; set; }
    }

    public class TripDates
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class TripPerson
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public string Status { get; set; } //SHOW, NOSHOW, YETTOBOARD, DROPPED 
        public DateTime BoardedTime { get; set; }
        public DateTime ActualBoardedTime { get; set; }
        public EZMoveCoordinates PersonLocation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class EZMoveCoordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public String Key
        {
            get
            {
                return Latitude.ToString() + "-" + Longitude.ToString();
            }
        }
    }

    public class EZMoveAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string LandMark { get; set; }
        public EZMoveCoordinates Coordinates { get; set; }
    }

    public class EZMoveMatrix
    {
        public EZMoveCoordinates SourceCoordinates { get; set; }
        public EZMoveCoordinates DestinationCoordinates { get; set; }
        public double Distance { get; set; }
        public double Time { get; set; }
        public String Key
        {
            get
            {
                return SourceCoordinates.Key + "_" + DestinationCoordinates.Key;
            }
        }
    }
    public class EZMoveAddressExt : EZMoveCoordinates
    {
        public double DistanceToDest { get; set; }
        public DateTime TimeToDest { get; set; }
    }

    public class Route
    {
        public EZMoveCoordinates Source { get; set; }
        public EZMoveCoordinates Destination { get; set; }
        public Dictionary<int, EZMoveAddressExt> Routes { get; set; }
        public double TotalDistance { get; set; }
        public double TimeForTrip { get; set; }
    }

    public class TripDriver
    {
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public double Rating { get; set; }
    }

    public class TripVechile
    {
        public string VechileNumber { get; set; }
        public string VechileModel { get; set; }
    }

    public class Trip
    {
        public string TripID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ActualStartTime { get; set; }
        public DateTime ActualEndTime { get; set; }
        public TripVechile VechileData { get; set; }
        public TripDriver DriverData { get; set; }
        public EZMoveCoordinates OfficeAddr { get; set; }
        public string Status { get; set; } //STARTED, INPROGRESS, FAILED
        public string Reason { get; set; } //InCase of failed
        public Dictionary<int, TripPerson> PassengarInfo { get; set; }
        public EZMoveAddressExt CurrentLocation { get; set; }
        public String TripURL { get; set; }
        public string TotalDistance { get; set; }
        public string TotalTime { get; set; }
        public bool ISPickUpTrip { get; set; }
    }
}
