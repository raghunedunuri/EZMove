﻿using System;
using System.Collections.Generic;
using EzMove.Contracts;

namespace EzMove.DataAcess
{
    public interface ITripRepository
    {
        void StartTrip(string TripID, int LoginID );

        void StopTrip(string TripID, int LoginID);

        void UpdateLocation( string TripID, EZMoveCoordinates TripCoordinates, int LoginID);

        void UpdateTripReview(string TripID, int EmployeeID, int Rating );

        void UpdateTripStatus(string TripID, int EmployeeID, string Status ); //NOSHOW, SHOW

        void UpdateTripPersonStatus(string TripID, int EmployeeID, string Status, int UpdateUserId);

        Trip GetTripInfo(string TripID );
    }
}
