using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzMove.Contracts;

namespace EzMove.DataAcess
{
    public static class DataMapper
    {
        public static Trip ConvertTripFromDataSet(DataSet ds)
        {
            Trip trip = null;

            DataTable dtTrip = ds.Tables[0];
            DataTable dtPersonInfo = ds.Tables[1];

            if( dtTrip.Rows.Count > 0 && dtPersonInfo.Rows.Count > 0)
            {
                trip = new Trip();
                DataRow tripRow = dtTrip.Rows[0];
                trip.TripID = tripRow["TripID"].ToString();
                trip.StartTime = tripRow["TripStartTime"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(tripRow["TripStartTime"]);
                trip.EndTime = tripRow["TripEndTime"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(tripRow["TripEndTime"]);
                trip.ActualStartTime = tripRow["ActualTripStartTime"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(tripRow["ActualTripStartTime"]);
                trip.ActualEndTime = tripRow["ActualTripEndTime"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(tripRow["ActualTripEndTime"]);
                trip.TotalTime = tripRow["TotalTime"].ToString();
                trip.TotalDistance = tripRow["Distance"].ToString();
                trip.Status = tripRow["CurrentStatus"].ToString();
                trip.ISPickUpTrip = Convert.ToBoolean(tripRow["IsPickUpTrip"]);
                trip.OfficeAddr = new EZMoveCoordinates();
                trip.OfficeAddr.Latitude = Convert.ToDouble(tripRow["OfficeLat"]);
                trip.OfficeAddr.Longitude = Convert.ToDouble(tripRow["OfficeLong"]);
                trip.CurrentLocation = new EZMoveAddressExt();
                trip.CurrentLocation.Latitude = Convert.ToDouble(tripRow["CurrentLat"]);
                trip.CurrentLocation.Longitude = Convert.ToDouble(tripRow["CurrentLong"]);
                trip.VechileData = new TripVechile();
                trip.VechileData.VechileNumber = tripRow["VechileNo"].ToString();
                trip.VechileData.VechileModel = tripRow["VechileName"].ToString();
                trip.DriverData = new TripDriver();
                trip.DriverData.DriverName = tripRow["FirstName"].ToString() + " " + tripRow["LastName"].ToString();
                trip.DriverData.DriverPhoneNumber = tripRow["Phone"].ToString();

                trip.PassengarInfo = new Dictionary<int, TripPerson>();
                foreach ( DataRow dr in dtPersonInfo.Rows)
                {
                    TripPerson pInfo = new TripPerson();
                    pInfo.BoardedTime = dr["PickDropTime"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["PickDropTime"]);
                    pInfo.ActualBoardedTime = dr["ActualPickDropTime"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["ActualPickDropTime"]);
                    pInfo.Order = Convert.ToInt32(dr["PersonOrder"]);
                    pInfo.ID = Convert.ToInt32(dr["PersonID"]);
                    pInfo.Status = dr["CurrentStatus"].ToString();
                    pInfo.Name = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                    pInfo.Phone = dr["Phone"].ToString();
                    pInfo.Email = dr["email"].ToString();
                    pInfo.PersonLocation = new EZMoveCoordinates();
                    pInfo.PersonLocation.Latitude = Convert.ToDouble(dr["Latitude"]);
                    pInfo.PersonLocation.Longitude = Convert.ToDouble(dr["Longitude"]);
                    trip.PassengarInfo.Add(pInfo.ID, pInfo);
                }
            }
            return trip;
        }
    }
}
