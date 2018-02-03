using CachingFramework.Redis;
using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Implementors;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using EzMove.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Cache
{
    public class CacheImplementor
    {
        private const string TRIPHASH = "trip:hash";
        private static IDbHelper dbHelper;
        private static TripRepository tripRepository;
        private static LoginRepository loginRepository;
        private static Context cacheContext;

        static CacheImplementor()
        {
            dbHelper = new MySqlDbHelper(new MySqlConnectionManager());
            tripRepository = new TripRepository(dbHelper);
            loginRepository = new LoginRepository(dbHelper);
            cacheContext = new Context(ConfigurationManager.AppSettings["RedisCache"]);
        }

        public static void UpdateUser(LoginResponse lr)
        {
            string userKey = String.Format("user:{0}", lr.Token.ToString().ToLower());
            cacheContext.Cache.SetObject(lr.Token.ToString().ToLower(), lr, new[] { lr.LoginID, lr.UserID.ToString()});
        }

        public static LoginResponse GetUserInfo(string Token)
        {
            string userKey = String.Format("user:{0}", Token.ToString().ToLower());
            LoginResponse lr = cacheContext.Cache.GetObject<LoginResponse>(userKey);
            if (lr == null)
            {
                lr = loginRepository.GetUser(Token);
                UpdateUser(lr);
            }
            return lr;
        }

        public static LoginResponse GetUserInfoByLoginId(string Id)
        {
            //string userKey = String.Format("user:{0}", Id.ToString().ToLower());
            //IEnumerable< LoginResponse> lr = cacheContext.Cache.GetObjectsByTag<LoginResponse>(Id);
            //if( lr == null )
            //{
            //    lr = loginRepository.GetUserByID(Id);
            //    UpdateUser(lr);
            //}
            return new LoginResponse();
        }

        public static Trip UpdateTrip(string TripID, EventDef actualEvent)
        {
            var trip = GetTrip(TripID);

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
            var trip = GetTrip(TripID);

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
            var trip = GetTrip(TripID);

            if (trip != null )
            {
                trip.CurrentLocation.Latitude = ezMoveCoordinates.Latitude;
                trip.CurrentLocation.Longitude = ezMoveCoordinates.Longitude;
            }
            return trip;
        }

        public static Trip GetTrip( string TripID )
        {
            string tripKey = String.Format("Trip:{0}", TripID.ToLower());
            return cacheContext.Cache.FetchHashed<Trip>(TRIPHASH, tripKey, () => tripRepository.GetTripInfo(TripID));
        }
    }
}
