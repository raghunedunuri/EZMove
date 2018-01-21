using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.DataAccess.Repositories.Implementors
{
    public class ShiftRepository : IShiftRepository
    {
        public void AddShift(Shift shift) { }

        public Shift GetShiftDetails(string ShiftName)
        {
            return new Shift();
        }

        public ShiftDates GetEmployeeeShift(int LoginID, string ShiftName)
        {
            return new ShiftDates();
        }
    }
}
