using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzMove.Models
{
    public class EmployeeInfo
    {
        public int EmployeeID { get; set; }
        public int OfficeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string AssociateID { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public EmployeeShiftInfo ShiftInfo { get; set; }
        public EZMoveAddress Address { get; set; }
        public string PicURL { get; set; }

        public List<EmployeeInfo> GetEmployeeInfo()
        {
            EmployeeShiftInfo shift1 = new EmployeeShiftInfo { CurrentShift = "UK", ShiftStartTime = DateTime.Now.ToShortTimeString(), ShiftEndTime = DateTime.Now.AddHours(8).ToShortTimeString() };
            EmployeeShiftInfo shift2 = new EmployeeShiftInfo { CurrentShift = "US", ShiftStartTime = DateTime.Now.ToShortTimeString(), ShiftEndTime = DateTime.Now.AddHours(8).ToShortTimeString() };
            EmployeeShiftInfo shift3 = new EmployeeShiftInfo { CurrentShift = "US", ShiftStartTime = DateTime.Now.ToShortTimeString(), ShiftEndTime = DateTime.Now.AddHours(8).ToShortTimeString() };
            EmployeeShiftInfo shift4 = new EmployeeShiftInfo { CurrentShift = "UK", ShiftStartTime = DateTime.Now.ToShortTimeString(), ShiftEndTime = DateTime.Now.AddHours(8).ToShortTimeString() };
            EmployeeShiftInfo shift5 = new EmployeeShiftInfo { CurrentShift = "IND", ShiftStartTime = DateTime.Now.ToShortTimeString(), ShiftEndTime = DateTime.Now.AddHours(8).ToShortTimeString() };

            EZMoveCoordinates cord1 = new EZMoveCoordinates { Latitude = 17.4948, Longitude = 78.3996 };
            EZMoveCoordinates cord2 = new EZMoveCoordinates { Latitude = 17.5125, Longitude = 78.3522 };
            EZMoveCoordinates cord3 = new EZMoveCoordinates { Latitude = 17.4653, Longitude = 78.3766 };
            EZMoveCoordinates cord4 = new EZMoveCoordinates { Latitude = 17.4483, Longitude = 78.3915 };
            EZMoveCoordinates cord5 = new EZMoveCoordinates { Latitude = 17.4375, Longitude = 78.4483 };

            EZMoveAddress address1 = new EZMoveAddress { AddressLine1 = "Kukatpally", AddressLine2 = "Kukatpally", City = "Hyderabad", Country = "India", LandMark = String.Empty, PinCode = "500072", State = "Telangana", Coordinates = cord1, Street = String.Empty };
            EZMoveAddress address2 = new EZMoveAddress { AddressLine1 = "Miyapur", AddressLine2 = "Miyapur", City = "Hyderabad", Country = "India", LandMark = String.Empty, PinCode = "500049", State = "Telangana", Coordinates = cord2, Street = String.Empty };
            EZMoveAddress address3 = new EZMoveAddress { AddressLine1 = "Kothaguda", AddressLine2 = "Kothaguda", City = "Hyderabad", Country = "India", LandMark = String.Empty, PinCode = "500084", State = "Telangana", Coordinates = cord3, Street = String.Empty };
            EZMoveAddress address4 = new EZMoveAddress { AddressLine1 = "Madhapur", AddressLine2 = "Madhapur", City = "Hyderabad", Country = "India", LandMark = String.Empty, PinCode = "500081", State = "Telangana", Coordinates = cord4, Street = String.Empty };
            EZMoveAddress address5 = new EZMoveAddress { AddressLine1 = "Ameerpet", AddressLine2 = "Ameerpet", City = "Hyderabad", Country = "India", LandMark = String.Empty, PinCode = "500038", State = "Telangana", Coordinates = cord5, Street = String.Empty };

            List<EmployeeInfo> empInfoList = new List<EmployeeInfo>()
        {
            new EmployeeInfo {  Address=address1,
                                AssociateID ="829290",
                                Email = "raghu.nedunuri@gmail.com",
                                EmployeeID =767659,
                                FirstName ="Raghu",
                                Gender ="Male",
                                LastName="Nedunuri",
                                OfficeID=101,
                                PhNo="9652342342",
                                PicURL=string.Empty,
                                ShiftInfo=shift1,
                                UserType="Employee",
                                UserStatus="Active"
                            }
                            ,
                            new EmployeeInfo
                            {
                                Address = address2,
                                AssociateID = "834290",
                                Email = "ayyappa.yellapu@gmail.com",
                                EmployeeID = 798568,
                                FirstName = "Ayyappa",
                                Gender = "Male",
                                LastName = "Yellapu",
                                OfficeID = 121,
                                PhNo = "9949305554",
                                PicURL = string.Empty,
                                ShiftInfo = shift2,
                                UserType = "Employee",
                                UserStatus = "Active"
                            }
                            ,
                            new EmployeeInfo
                            {
                                Address = address3,
                                AssociateID = "652290",
                                Email = "sagar.ayitham@gmail.com",
                                EmployeeID = 132659,
                                FirstName = "Sagar",
                                Gender = "Male",
                                LastName = "Ayitham",
                                OfficeID = 181,
                                PhNo = "8898345623",
                                PicURL = string.Empty,
                                ShiftInfo = shift3,
                                UserType = "Employee",
                                UserStatus = "Active"
                            }
                            ,
                            new EmployeeInfo
                            {
                                Address = address4,
                                AssociateID = "829595",
                                Email = "pavan.gangone@gmail.com",
                                EmployeeID = 896754,
                                FirstName = "Pavan",
                                Gender = "Male",
                                LastName = "Gangone",
                                OfficeID = 159,
                                PhNo = "8849573098",
                                PicURL = string.Empty,
                                ShiftInfo = shift4,
                                UserType = "Employee",
                                UserStatus = "Active"
                            }
                            ,
                            new EmployeeInfo
                            {
                                Address = address5,
                                AssociateID = "123290",
                                Email = "srinivas.mundru@gmail.com",
                                EmployeeID = 187659,
                                FirstName = "Srinivas",
                                Gender = "Male",
                                LastName = "Mundru",
                                OfficeID = 101,
                                PhNo = "9866343098",
                                PicURL = string.Empty,
                                ShiftInfo = shift5,
                                UserType = "Employee",
                                UserStatus = "Active"
                            }
        };

            return empInfoList;
        }

    }

}