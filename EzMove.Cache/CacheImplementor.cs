using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Implementors;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using EzMove.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Cache
{
    public class CacheImplementor
    {
        public static Dictionary<string, LoginResponse> UserLogins;
        public static Dictionary<string, Trip> Trips;
        public static IDbHelper dbHelper;
        public static TripRepository tripRepository;
        public static LoginRepository loginRepository;

        static CacheImplementor()
        {
            UserLogins = new Dictionary<string, LoginResponse>();
            dbHelper = new MySqlDbHelper(new MySqlConnectionManager());
            tripRepository = new TripRepository(dbHelper);
            loginRepository = new LoginRepository(dbHelper);
        }

        public static void UpdateUser(LoginResponse lr)
        {
            UserLogins[lr.Token.ToString().ToLower()] = lr;
        }

        public static LoginResponse GetUserInfo(string Token)
        {
            if (!UserLogins.ContainsKey(Token))
            {
                LoginResponse lr = loginRepository.GetUser(Token);
                UserLogins[Token.ToString().ToLower()] = lr;
            }
            return UserLogins[Token.ToString().ToLower()];
        }

        public static Trip UpdateTrip(string TripID, EventDef actualEvent)
        {
            Trip trip = GetTrip(TripID);

            if (trip != null)
            {
                switch (actualEvent)
                {
                    case EventDef.STARTTRIP:
                        trip.Status = "TRIPSTARTED";
                        break;
                    case EventDef.STOPTRIP:
                        trip.Status = "TRIPSTOPPED";
                        break;
                }
            }
            return trip;
        }

        public static Trip UpdateTripShows(string TripID, EventDef actualEvent, int LoginID)
        {
            Trip trip = GetTrip(TripID);

            if (trip != null && trip.PassengarInfo != null &&
                trip.PassengarInfo.ContainsKey(LoginID))
            {
                switch (actualEvent)
                {
                    case EventDef.EMPLOYEENOSHOW:
                        trip.PassengarInfo[LoginID].Status = "NOSHOW";
                        break;
                    case EventDef.EMPLOYEESHOW:
                        trip.PassengarInfo[LoginID].Status = "SHOW";
                        break;
                }
            }
            return trip;
        }

        public static Trip UpdateTripLocation(string TripID, EZMoveCoordinates ezMoveCoordinates)
        {
            Trip trip = GetTrip(TripID);

            if (trip != null )
            {
                trip.CurrentLocation.Latitude = ezMoveCoordinates.Latitude;
                trip.CurrentLocation.Longitude = ezMoveCoordinates.Longitude;
            }
            return trip;
        }

        public static Trip GetTrip( string TripID )
        {
            Trip trip = null;
            if (!Trips.ContainsKey(TripID))
                trip = tripRepository.GetTripInfo(TripID);
            else
                trip = Trips[TripID];

            return trip;
        }
    }
}
