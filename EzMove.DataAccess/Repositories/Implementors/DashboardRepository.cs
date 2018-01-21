using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using EzMove.DataAcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.DataAccess.Repositories.Implementors
{
    public class DashboardRepository : IDashboardRepository
    {
        private IDbHelper dbHelper = null;
        public DashboardRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public DashboardInfo GetDashBoardInfo()
        {
            DashboardInfo dashboardInfo = new DashboardInfo();
            dbHelper.CreateCommand("getdashboardstats", System.Data.CommandType.StoredProcedure);
            using (IDataReader dr = dbHelper.ExecuteReader())
            {
                dashboardInfo.ShiftSummary = new List<ShiftDashboardInfo>();
                string str = String.Empty;

                ShiftDashboardInfo prev = null;
                while (dr.Read())
                {
                    string shiftname = dr["shiftname"].ToString();
                    bool IsReturnTrip = !Convert.ToBoolean(dr["IsPickUpTrip"]);

                    ShiftRowInfo shiftRow = new ShiftRowInfo();
                    shiftRow.NoOfEmployeesBoarded = Convert.ToInt32(dr["BoardedMembers"]);
                    int totalPlanned = Convert.ToInt32(dr["TotalPlanned"]);
                    shiftRow.NoOfVechiles = Convert.ToInt32(dr["VechileCount"]);
                    shiftRow.Status = dr["currentstatus"].ToString();
                    shiftRow.NoOfEmployeesNoShow = shiftRow.Status.ToUpper() == "COMPLETED" ? totalPlanned - shiftRow.NoOfEmployeesBoarded : 0;
                    shiftRow.NoOfEmployeesYetToBoard = shiftRow.Status.ToUpper() != "COMPLETED" ? totalPlanned - shiftRow.NoOfEmployeesBoarded : 0;
                    shiftRow.ShiftPickStartTime = dr["ShiftStartTime"].ToString();

                    if (str != shiftname)
                    {
                        str = shiftname;
                        prev = new ShiftDashboardInfo();
                        prev.ShiftName = shiftname;
                        dashboardInfo.ShiftSummary.Add(prev);
                    }
                    if (IsReturnTrip)
                        prev.ReturnTrip = shiftRow;
                    else
                        prev.PickUpTrip = shiftRow;
                }
            }
            return dashboardInfo;
        }

        public List<EmployeeInfo> SearchEmployees( string searchstring)
        {
            return new List<EmployeeInfo>();
        }
    }
}
