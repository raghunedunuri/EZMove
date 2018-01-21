using System.Collections.Generic;
using System.Data;
using EzMove.Contracts;
using System;
using EzMove.DataAcess;
using EzMove.MQUtilities;
using EzMove.Cache;

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
            CacheImplementor.UpdateTrip(TripID, EventDef.STARTTRIP);
            tripRepos.StartTrip(TripID, LoginID);
            MQManager.PushTripStatus(TripID, EventDef.STARTTRIP);
        }

        public void StopTrip(string TripID, int LoginID)
        {
            CacheImplementor.UpdateTrip(TripID, EventDef.STOPTRIP);
            tripRepos.StopTrip(TripID, LoginID);
            MQManager.PushTripStatus(TripID, EventDef.STOPTRIP);
        }

        public void UpdateLocation(string TripID, EZMoveCoordinates TripCoordinates, int LoginID)
        {
            CacheImplementor.UpdateTripLocation(TripID, TripCoordinates);
            //tripRepos.UpdateLocation(TripID, TripCoordinates, LoginID);
        }

        public void UpdateTripReview(string TripID, int EmployeeID, int Rating)
        {

        }

        public void UpdateTripStatus(string TripID, int EmployeeID, string Status, int UpdateuserId)
        {
            tripRepos.UpdateTripPersonStatus(TripID, EmployeeID, Status, UpdateuserId);
        }

        public void UpdateTripPersonStatus(string TripID, int EmployeeID, string Status, int UpdateUserId)
        {
            EventDef eventDef = EventDef.EMPLOYEESHOW;
            switch (Status.ToUpper().Trim())
            {
                case "NOSHOW":
                    eventDef = EventDef.EMPLOYEENOSHOW;
                    break;
            }
            CacheImplementor.UpdateTripShows(TripID, eventDef, EmployeeID);
            tripRepos.UpdateTripPersonStatus(TripID, EmployeeID, Status, UpdateUserId);
            MQManager.PushTripInfo(TripID, EmployeeID, eventDef);
        }

        public Trip GetTripInfo(string TripID)
        {
            return CacheImplementor.GetTrip(TripID);
        }
    }
}
