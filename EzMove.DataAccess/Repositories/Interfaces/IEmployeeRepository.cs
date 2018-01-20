using EzMove.Contracts;
using System;
using System.Collections.Generic;

namespace EzMove.DataAcess
{
    public interface IEmployeeRepository
    {
        EmployeeInfo GetEmployeeInfo(int LoginID);

        Trip GetEmployeeCurrentTrip(int LoginID);

        void UpdateEmployeePhoneNumber(int LoginID, string PhoneNumber);

        void UpdateEmployeeEmail(int LoginID, string Email);

        void UpdateEmployeeAddress(int LoginID, EZMoveAddress address);

        void AddEmployee(EmployeeInfo empInfo);

        void DeActivateEmployee(int LoginID);

        void UpdateEmployeeShift(int LoginID, string Shift);

        List<EmployeeInfo> GetEmployeeByShift(string shiftname, int officeid);

        List<VechileInfo> GetVechileInfo();
    }
}
