using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class DriverInfo
    {
        public int DriverID { get; set; }
        public string Name { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string DrivingLicenseNo { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public double Rating { get; set; }
        public string PicURL { get; set; }
    }
}
