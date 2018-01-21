using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class Shift
    {
        public String ShiftName { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
        public int ShiftID { get; set; }
    }

    public class ShiftDates : Shift
    {
        public String StartDate { get; set; }
        public String EndDate { get; set; }
    }
}
