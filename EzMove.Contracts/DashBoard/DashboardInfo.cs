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

    public class DashboardInfo
    {
        public List<ShiftInfo> ShiftSummary { get; set; }
    }
}
