using System.Collections.Generic;
using System.Data;
using System.Linq;
using EzMove.Contracts;

namespace EzMove.DataAcess
{
    public class DriverRepository : IDriverRepository
    {
        private IDbHelper dbHelper = null;
        public DriverRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public DriverInfo GetDriverInfo(int LoginID)
        {
            return new DriverInfo(); 
        }

        public Trip GetDriverCurrentTrip(int LoginID)
        {
            dbHelper.CreateCommand("getcurrenttripbydriver", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("currID", LoginID);
            DataSet ds = dbHelper.ExecuteDataSet();

            return DataMapper.ConvertTripFromDataSet(ds);
        }

        public List<Trip> GetPreviousTrips(int LoginID)
        {
            return new List<Trip>();
        }

        public void UpdateDriverPhoneNumber(int LoginID, string PhoneNumber)
        {
        }

        public void UpdateDriverEmail(int LoginID, string Email)
        { }

        public void AddDriver(DriverInfo drvInfo)
        { }

        public void DeActivateDriver(int LoginID)
        { }

        //private List<Offers> GetOfferDetails(int offertype)
        //{
        //    dbHelper.CreateCommand("transpire_products.sp_get_megamenu", CommandType.StoredProcedure);
        //    dbHelper.AddParameter("offertype", offertype);

        //    DataSet ds = dbHelper.ExecuteDataSet();
        //    return ds.Tables[0].ToEntities<Offers>().ToList();
        //}
    }
}
