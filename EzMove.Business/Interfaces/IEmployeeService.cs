using EzMove.Contracts;
using System;
using System.Collections.Generic;

namespace EzMove.Business
{
    public interface IEmployeeService
    {
        EmployeeInfo GetEmployeeInfo(int LoginID);

        List<EmployeeInfo> GetEmployeeByShift(string shiftname, int officeid);

        Trip GetEmployeeCurrentTrip(int LoginID);

        void UpdateEmployeePhoneNumber(int LoginID, string PhoneNumber);

        void UpdateEmployeeEmail(int LoginID, string Email);

        void UpdateEmployeeAddress(int LoginID, EZMoveAddress address);

        void AddEmployee(EmployeeInfo empInfo);

        void DeActivateEmployee(int LoginID);

        void UpdateEmployeeShift(int LoginID, int Shift);

        List<VechileInfo> GetVechileInfo();
    }
}
