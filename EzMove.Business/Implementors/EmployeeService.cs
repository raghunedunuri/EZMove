using System;
using System.Data;
using EzMove.Contracts;
using EzMove.DataAcess;

namespace EzMove.Business
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository = null;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public EmployeeInfo GetEmployeeInfo(int LoginID)
        {
            return employeeRepository.GetEmployeeInfo(LoginID);
        }

        public Trip GetEmployeeCurrentTrip(int LoginID)
        {
            return employeeRepository.GetEmployeeCurrentTrip(LoginID);
        }

        public void UpdateEmployeePhoneNumber(int LoginID, string PhoneNumber)
        {
            employeeRepository.UpdateEmployeePhoneNumber(LoginID, PhoneNumber);
        }

        public void UpdateEmployeeEmail(int LoginID, string Email)
        {
            employeeRepository.UpdateEmployeeEmail(LoginID, Email);
        }

        public void UpdateEmployeeAddress(int LoginID, EZMoveAddress address)
        {
            employeeRepository.UpdateEmployeeAddress(LoginID, address);
        }

        public void AddEmployee(EmployeeInfo empInfo)
        {
            employeeRepository.AddEmployee(empInfo);
        }

        public void DeActivateEmployee(int LoginID)
        {
            employeeRepository.DeActivateEmployee(LoginID);
        }

        public void UpdateEmployeeShift(int LoginID, string Shift)
        {
            employeeRepository.UpdateEmployeeShift(LoginID, Shift);
        }
    }
}
