using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzMove.Models
{
    public class ShiftInfo
    {
        public Shift Shift { get; set; }
        public int EmployeesBoarded { get; set; }
        public int EmployeesYetToBoard { get; set; }
        public int EmployeesNoShow { get; set; }
        public string Status { get; set; }
        public int Vechiles { get; set; }
        public int TripsStarted { get; set; }
        public int TripsInProgress { get; set; }
        public int TripsCompleted { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalEmployees { get; set; }

        public List<ShiftInfo> GetShiftInfo()
        {
            Shift shift1 = new Shift { EmpID = 1, ShiftName = "UK", FirstName = "Raghu", LastName = "Nedunuri", Email = "raghu.nedunuri@gmail.com", Phone = "9652342342" };
            Shift shift2 = new Shift { EmpID = 1, ShiftName = "US", FirstName = "Srinivas", LastName = "Mundru", Email = "srinivas.mundru@gmail.com", Phone = "9866165673" };
            Shift shift3 = new Shift { EmpID = 1, ShiftName = "AUS", FirstName = "Ayyappa", LastName = "Yellapu", Email = "ayyappa.yellapu@gmail.com", Phone = "9866123456" };
            Shift shift4 = new Shift { EmpID = 1, ShiftName = "IND", FirstName = "Sridhar", LastName = "Potula", Email = "sridhar.potula@gmail.com", Phone = "98662345678" };

            List<ShiftInfo> shiftInfoList = new List<ShiftInfo>()
            {
                new ShiftInfo {Shift=shift1,EmployeesBoarded=200,EmployeesYetToBoard=20,EmployeesNoShow=10,Status="Started",TripsCompleted=0,TripsInProgress=40,TripsStarted=20,Vechiles=60,StartTime=DateTime.Now,TotalEmployees=500 },
                new ShiftInfo {Shift=shift2,EmployeesBoarded=100,EmployeesYetToBoard=10,EmployeesNoShow=4,Status="In Progress",TripsCompleted=10,TripsInProgress=30,TripsStarted=10,Vechiles=40,StartTime=DateTime.Now.AddHours(2),TotalEmployees=100 },
                new ShiftInfo {Shift=shift3,EmployeesBoarded=300,EmployeesYetToBoard=30,EmployeesNoShow=2,Status="In Progress",TripsCompleted=20,TripsInProgress=60,TripsStarted=30,Vechiles=90,StartTime=DateTime.Now.AddHours(4),TotalEmployees=400 },
                new ShiftInfo {Shift=shift4,EmployeesBoarded=500,EmployeesYetToBoard=50,EmployeesNoShow=1,Status="In Progress",TripsCompleted=10,TripsInProgress=10,TripsStarted=40,Vechiles=50,StartTime=DateTime.Now.AddHours(6),TotalEmployees=300 }
            };

            return shiftInfoList;
        }
    }
}