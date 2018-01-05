using System.Collections.Generic;
using System.Data;
using EzMove.Contracts;
using System;
using EzMove.DataAcess;

namespace EzMove.Business
{
    public class TripService : ITripService
    {
        private ITripRepository tripRepos = null;


        public TripService(ITripRepository tripRepos)
        {
            this.tripRepos = tripRepos;
        }

        public void StartTrip(string TripID, int LoginID)
        {
            tripRepos.StartTrip(TripID, LoginID);
        }

        public void StopTrip(string TripID, int LoginID)
        {
            tripRepos.StopTrip(TripID, LoginID);
        }

        public void UpdateLocation(string TripID, EZMoveCoordinates TripCoordinates, int LoginID)
        {
            tripRepos.UpdateLocation(TripID, TripCoordinates, LoginID);
        }

        public void UpdateTripReview(string TripID, int EmployeeID, int Rating)
        {

        }

        public void UpdateTripStatus(string TripID, int EmployeeID, string Status)
        {

        }

        public void UpdateTripPersonStatus(string TripID, int EmployeeID, string Status, int UpdateUserId)
        {
            tripRepos.UpdateTripPersonStatus(TripID, EmployeeID, Status, UpdateUserId);
        }

        public Trip GetTripInfo(string TripID)
        {
            return tripRepos.GetTripInfo(TripID);
        }
    }
}
