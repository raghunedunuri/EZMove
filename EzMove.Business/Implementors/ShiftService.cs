using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Business
{
    public class ShiftService : IShiftService
    {
        private IShiftRepository shiftRepos = null;
        public ShiftService(IShiftRepository shiftRepos)
        {
            this.shiftRepos = shiftRepos;
        }

        public void AddShift(Shift shift)
        {
            shiftRepos.AddShift(shift);
        }

        public Shift GetShiftDetails(string ShiftName)
        {
            return shiftRepos.GetShiftDetails(ShiftName);
        }
    }
}
