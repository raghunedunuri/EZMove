using System.Collections.Generic;
using EzMove.Contracts;

namespace EzMove.Business
{
    public interface IDriverService
    {
        DriverInfo GetDriverInfo(int LoginID);

        Trip GetDriverCurrentTrip(int LoginID);

        List<Trip> GetPreviousTrips(int LoginID);

        void UpdateDriverPhoneNumber(int LoginID, string PhoneNumber);

        void UpdateDriverEmail(int LoginID, string Email);

        void AddDriver(DriverInfo drvInfo);

        void DeActivateDriver(int LoginID);
    }
}
 