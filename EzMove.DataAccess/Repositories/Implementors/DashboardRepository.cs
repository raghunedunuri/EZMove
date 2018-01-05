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
            dbHelper.CreateCommand("getdashboardstats", System.Data.CommandType.StoredProcedure);
            IDataReader dr = dbHelper.ExecuteReader();

            DashboardInfo dashboardInfo = new DashboardInfo();
            dashboardInfo.ShiftSummary = new List<ShiftInfo>();
            while (dr.Read())
            {
                ShiftInfo sInfo = new ShiftInfo();
                sInfo.NoOfEmployeesBoarded = Convert.ToInt32(dr["BoardedMembers"]);
                int totalPlanned = Convert.ToInt32(dr["TotalPlanned"]);
                sInfo.ShiftName = dr["shiftname"].ToString();
                sInfo.NoOfVechiles = Convert.ToInt32(dr["VechileCount"]);
                sInfo.Status = dr["currentstatus"].ToString();
                sInfo.NoOfEmployeesNoShow = sInfo.Status.ToUpper() == "COMPLETED" ? totalPlanned - sInfo.NoOfEmployeesBoarded : 0;
                sInfo.NoOfEmployeesYetToBoard = sInfo.Status.ToUpper() != "COMPLETED" ? totalPlanned - sInfo.NoOfEmployeesBoarded : 0;
                sInfo.IsReturnTrip = !Convert.ToBoolean( dr["IsPickUpTrip"]);
                sInfo.ShiftStartTime = dr["StartTime"].ToString();
                dashboardInfo.ShiftSummary.Add(sInfo);
            }
            return dashboardInfo;
        }
    }
}
