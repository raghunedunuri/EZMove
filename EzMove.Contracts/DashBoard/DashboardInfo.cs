using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class ShiftInfo
    {
        public string ShiftName { get; set; }
        public string ShiftStartTime { get; set; }
        public int NoOfEmployeesBoarded { get; set; }
        public int NoOfEmployeesYetToBoard { get; set; }
        public int NoOfEmployeesNoShow { get; set; }
        public string Status { get; set; }
        public int NoOfVechiles { get; set; }
        public bool IsReturnTrip { get; set; }
    }
    public class ShiftRowInfo
    {
        public string ShiftPickStartTime { get; set; }
        public int NoOfEmployeesBoarded { get; set; }
        public int NoOfEmployeesYetToBoard { get; set; }
        public int NoOfEmployeesNoShow { get; set; }
        public string Status { get; set; }
        public int NoOfVechiles { get; set; }
    }

    public class ShiftDashboardInfo
    {
        public string ShiftName { get; set; }
        public ShiftRowInfo PickUpTrip { get; set; }
        public ShiftRowInfo ReturnTrip { get; set; }
    }

    public class DashboardInfo
    {
        public List<ShiftDashboardInfo> ShiftSummary { get; set; }
    }
}
