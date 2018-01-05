using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzMove.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Make { get; set; }
        public string  Model { get; set; }
        public int Capacity { get; set; }
        public bool AC { get; set; }
        public DateTime PollutionExpireDate { get; set; }

        public List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>()
            {
                new Vehicle {Id=344,Number="AP09CG8888",Make="Tata",Model="Indica",PollutionExpireDate=DateTime.Now.AddMonths(5),Capacity=5,AC=false},
                new Vehicle {Id=887,Number="AP09CG8045",Make="Ford",Model="Aspire",PollutionExpireDate=DateTime.Now.AddMonths(3),Capacity=5,AC=false},
                new Vehicle {Id=133,Number="AP09CG1234",Make="Suzuki",Model="Ritz",PollutionExpireDate=DateTime.Now.AddMonths(4),Capacity=5,AC=false},
                new Vehicle {Id=123,Number="AP09CG007",Make="Toyota",Model="Etios",PollutionExpireDate=DateTime.Now.AddMonths(2),Capacity=5,AC=true},
                new Vehicle {Id=523,Number="AP09CG8055",Make="Mahindra",Model="Xylo",PollutionExpireDate=DateTime.Now.AddMonths(5),Capacity=5,AC=true}
            };
        }
    }
}