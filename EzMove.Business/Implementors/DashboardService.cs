using EzMove.Contracts;
using EzMove.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Business
{
    public class DashboardService : IDashboardService
    {
        private IDashboardRepository dashboardRepos = null;
        public DashboardService(IDashboardRepository dashboardRepos)
        {
            this.dashboardRepos = dashboardRepos;
        }

        public DashboardInfo GetDashBoardInfo()
        {
            return dashboardRepos.GetDashBoardInfo();
        }
    }
}
