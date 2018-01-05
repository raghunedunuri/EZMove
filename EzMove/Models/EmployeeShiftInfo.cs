using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzMove.Models
{
    public class EmployeeShiftInfo
    {
        public string CurrentShift { get; set; } //US, UK, INDIA, Australia etc.,
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
    }
}