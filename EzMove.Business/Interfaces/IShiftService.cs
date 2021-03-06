﻿using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Business
{
    public interface IShiftService
    {
        void AddShift(Shift shift);

        Shift GetShiftDetails(string ShiftName);

        ShiftDates GetEmployeeeShift(int LoginID, string ShiftName);
    }
}
