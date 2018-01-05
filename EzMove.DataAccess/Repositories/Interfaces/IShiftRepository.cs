using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.DataAccess.Repositories.Interfaces
{
    public interface IShiftRepository
    {
        void AddShift(Shift shift);

        Shift GetShiftDetails(string ShiftName);
    }
}
