using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Contracts
{
    public class VechileInfo
    {
        public string VechileID { get; set; }
        public string Number { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; } //AC,  NON-AC
        public string Category { get; set; } //CAR, VAN, BUS
        public int Capacity { get; set; } //5, 7 etc,.,
        public int MaxSpeed { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime PollutionExpiryDate { get; set; }
        public DateTime InsuranceExpiryDate { get; set; }
    }
}
