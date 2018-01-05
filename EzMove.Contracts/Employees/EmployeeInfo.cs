using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class EmployeeInfo
    {
        public int EmployeeID { get; set; }
        public int OfficeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string AssociateID { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
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
