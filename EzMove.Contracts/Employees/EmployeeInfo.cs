using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class EmployeeInfo
    {
        public int UserID { get; set; }
        public int OfficeID { get; set; }
        public string LoginID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string EmployeeID { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public string OfficeName { get; set; }
        public string OfficeURL { get; set; }
        public EmployeeShiftInfo ShiftInfo { get; set; }
        public EZMoveAddress Address { get; set; }
        public string PicURL { get; set; }
    }

    public class EmployeeShiftInfo
    {
        public string CurrentShift { get; set; } //US, UK, INDIA, Australia etc.,
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
    }
}
