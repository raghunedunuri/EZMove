using System.Collections.Generic;
using System.Data;
using EzMove.Contracts;
using System;

namespace EzMove.DataAcess.Repositories
{
    public class TripRepository : ITripRepository
    {
        private IDbHelper dbHelper = null;
        public TripRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public void StartTrip(string TripID, int LoginID) {
            dbHelper.CreateCommand("starttrip", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("CurrTripID", TripID);
            dbHelper.AddParameter("PersonID", LoginID);

            dbHelper.ExecuteNonQuery();
        }

        public void StopTrip(string TripID, int LoginID)
        {
            dbHelper.CreateCommand("stoptrip", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("CurrTripID", TripID);
            dbHelper.AddParameter("PersonID", LoginID);

            dbHelper.ExecuteNonQuery();
        }

        public void UpdateLocation(string TripID, EZMoveCoordinates TripCoordinates, int LoginID)
        {
            dbHelper.CreateCommand("updatetriplocation", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("CurrTripID", TripID);
            dbHelper.AddParameter("PersonID", LoginID);
            dbHelper.AddParameter("Lat", TripCoordinates.Latitude);
            dbHelper.AddParameter("Lon", TripCoordinates.Longitude);
            dbHelper.ExecuteNonQuery();
        }

        public void UpdateTripReview(string TripID, int EmployeeID, int Rating)
        {
            //TripPerson

        }

        public void UpdateTripPersonStatus(string TripID, int EmployeeID, string Status, int UpdateUserId) 
        {
            dbHelper.CreateCommand("updatepersonstatus", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("CurrTripID", TripID);
            dbHelper.AddParameter("PersonID", EmployeeID);
            dbHelper.AddParameter("UpdatePersonID", UpdateUserId);
            dbHelper.AddParameter("personstatus", Status);
            dbHelper.ExecuteNonQuery();
        }

        public void UpdateTripStatus(string TripID, int LoginID, string Status) //NOSHOW, SHOW
        {
           
        }
        
        public Trip GetTripInfo(string TripID)
        {
            dbHelper.CreateCommand("gettripdetails", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("CurrTripID", TripID);
            DataSet ds = dbHelper.ExecuteDataSet();
            return DataMapper.ConvertTripFromDataSet(ds);
        }
    }
}
