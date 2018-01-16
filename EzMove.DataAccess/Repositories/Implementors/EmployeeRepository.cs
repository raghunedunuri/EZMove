using System;
using System.Collections.Generic;
using System.Data;
using EzMove.Contracts;
using EzMove.DataAcess;

namespace EzMove.DataAcess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IDbHelper dbHelper = null;
        public EmployeeRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public EmployeeInfo GetEmployeeInfo(int LoginID)
        {
            EmployeeInfo ei = new EmployeeInfo();

            dbHelper.CreateCommand("getemployeeinfo", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("userid", LoginID);
            IDataReader dr = dbHelper.ExecuteReader();

            while (dr.Read())
            {
                ei = new EmployeeInfo();
                ei.EmployeeID = LoginID;
                ei.OfficeID = Convert.ToInt32(dr["OfficeID"]);
                ei.PhNo = dr["Phone"].ToString();
                ei.Email = dr["Email"].ToString();
                ei.FirstName = dr["FirstName"].ToString();
                ei.LastName = dr["FirstName"].ToString();
                ei.Gender = dr["Gender"].ToString();
                ei.PicURL = dr["Photo"].ToString();
                ei.UserType = dr["UserType"].ToString();
                ei.UserStatus = dr["UserStatus"].ToString();
                ei.Address = new EZMoveAddress();
                ei.Address.AddressLine1 = dr["Address1"] != null ? dr["Address1"].ToString() : String.Empty;
                ei.Address.AddressLine2 = dr["Address2"] != null ? dr["Address2"].ToString() : String.Empty;
                ei.Address.City = dr["City"] != null ? dr["City"].ToString() : String.Empty;
                ei.Address.Country = dr["Country"] != null ? dr["Country"].ToString() : String.Empty;
                ei.Address.PinCode = dr["Pin"] != null ? dr["Pin"].ToString() : String.Empty;
                ei.Address.Coordinates = new EZMoveCoordinates();
                ei.Address.Coordinates.Latitude = dr["Latitude"] != null ? Convert.ToDouble(dr["Latitude"]) : 0;
                ei.Address.Coordinates.Longitude = dr["Longitude"] != null ? Convert.ToDouble(dr["Longitude"]) : 0;
                ei.ShiftInfo = new EmployeeShiftInfo();
                ei.ShiftInfo.CurrentShift = dr["ShiftName"] != null ? dr["ShiftName"].ToString() : String.Empty;
                ei.ShiftInfo.ShiftStartTime = dr["StartTime"] != null ? dr["StartTime"].ToString() : String.Empty;
                ei.ShiftInfo.ShiftEndTime = dr["EndTime"] != null ? dr["EndTime"].ToString() : String.Empty;
                break;
            }
            dr.Close();
            return ei;
        }

        public EZMoveAddress GetEmployeeAddress(int LoginID)
        {
            return new EZMoveAddress();
        }

        public EmployeeShiftInfo GetEmployeeShiftInfo(int LoginID)
        {
            return new EmployeeShiftInfo();
        }

        public List<EmployeeInfo> GetEmployeeListBasedOnShift(string shift)
        {
            return new List<EmployeeInfo>();
        }

        public Trip GetEmployeeCurrentTrip(int LoginID)
        {
            dbHelper.CreateCommand("getcurrenttripinfo", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("currID", LoginID);
            DataSet ds = dbHelper.ExecuteDataSet();
            return DataMapper.ConvertTripFromDataSet(ds);
        }

        public void UpdateEmployeePhoneNumber(int LoginID, string PhoneNumber)
        { }

        public void UpdateEmployeeEmail(int LoginID, string Email)
        { }

        public void UpdateEmployeeAddress(int LoginID, EZMoveAddress address)
        { }

        public void AddEmployee(EmployeeInfo empInfo)
        { }

        public void DeActivateEmployee(int LoginID)
        { }

        public void UpdateEmployeeShift(int LoginID, string Shift)
        { }

        public List<EmployeeInfo> GetEmployeeByShift(string shiftname)
        {
            dbHelper.CreateCommand("getemployeesonshift", System.Data.CommandType.StoredProcedure);
            dbHelper.AddParameter("shiftname", shiftname);

            DataSet ds = dbHelper.ExecuteDataSet();
            List<EmployeeInfo> lstEmpInfo = new List<EmployeeInfo>();

            foreach( DataRow dr in ds.Tables[0].Rows)
            {
                EmployeeInfo ei = new EmployeeInfo();
                ei.EmployeeID = Convert.ToInt32(dr["USERID"]);
                ei.ShiftInfo = new EmployeeShiftInfo();
                ei.ShiftInfo.CurrentShift = dr["ShiftName"] != null ? dr["ShiftName"].ToString() : String.Empty;
                ei.PhNo = dr["Phone"].ToString();
                ei.Email = dr["Email"].ToString();
                ei.FirstName = dr["FirstName"].ToString();
                ei.LastName = dr["FirstName"].ToString();
                ei.Gender = dr["Gender"].ToString();
                ei.UserType = dr["UserType"].ToString();
                ei.UserStatus = dr["UserStatus"].ToString();
                lstEmpInfo.Add(ei);
            }
            return lstEmpInfo;
        }

        public List<VechileInfo> GetVechileInfo()
        {
            dbHelper.CreateCommand("getvechiles", System.Data.CommandType.StoredProcedure);
           
            DataSet ds = dbHelper.ExecuteDataSet();
            List<VechileInfo> lstEmpInfo = new List<VechileInfo>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                VechileInfo ei = new VechileInfo();
                ei.Capacity = Convert.ToInt32(dr["VechileCapacity"]);
                ei.Number = dr["VechileNo"].ToString();
                ei.CompanyName = dr["VechileName"].ToString();
                ei.Type = dr["VechileType"].ToString();
                lstEmpInfo.Add(ei);
            }
            return lstEmpInfo;
        }
    }
}
