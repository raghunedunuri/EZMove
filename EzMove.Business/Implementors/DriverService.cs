using System.Collections.Generic;
using System.Data;
using System.Linq;
using EzMove.Contracts;
using EzMove.DataAcess;

namespace EzMove.Business
{
    public class DriverService : IDriverService
    {
        private IDriverRepository driverRepos = null;
        public DriverService(IDriverRepository driverRepos)
        {
            this.driverRepos = driverRepos;
        }

        public DriverInfo GetDriverInfo(int LoginID)
        {
            return driverRepos.GetDriverInfo(LoginID); 
        }

        public Trip GetDriverCurrentTrip(int LoginID)
        {
            return driverRepos.GetDriverCurrentTrip(LoginID);
        }

        public List<Trip> GetPreviousTrips(int LoginID)
        {
            return driverRepos.GetPreviousTrips(LoginID);
        }

        public void UpdateDriverPhoneNumber(int LoginID, string PhoneNumber)
        {
            driverRepos.UpdateDriverPhoneNumber(LoginID, PhoneNumber);
        }

        public void UpdateDriverEmail(int LoginID, string Email)
        {
            driverRepos.UpdateDriverEmail(LoginID, Email);
        }

        public void AddDriver(DriverInfo drvInfo)
        {
            driverRepos.AddDriver(drvInfo);
        }

        public void DeActivateDriver(int LoginID)
        {
            driverRepos.DeActivateDriver(LoginID);
        }

        public List<DriverInfo> GetDrivers()
        {
           return driverRepos.GetDrivers();
        }
    }
}
