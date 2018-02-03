using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using EzMove.MQUtilities;
using EzMove.DataAccess.Repositories.Interfaces;
using Unity;
using EzMove.DataAcess;

namespace EzMove.MQJobProcessor
{
    public abstract class BatchRequestProcessor
    {
        public bool Completed { get; protected set; }
        public bool Result { get; protected set; }

        public IConnectionManager connManager { get; set; }
        public IDbHelper dbHelper { get; set; }
        public IDashboardRepository dashboardRepository { get; set; }
        public IDriverRepository driverRepository { get; set; }
        public IEmployeeRepository employeeRepository { get; set; }
        public IShiftRepository shiftRepository { get; set; }
        public ITripRepository tripRepository { get; set; }
        public ILoginRepository loginRepository { get; set; }

        public BatchRequestProcessor( )
        {
            IUnityContainer container = Bootstrapper.Initialise();
            connManager = container.Resolve<IConnectionManager>();
            dbHelper = container.Resolve<IDbHelper>();

            dashboardRepository = container.Resolve<IDashboardRepository>();
            driverRepository = container.Resolve<IDriverRepository>();
            employeeRepository = container.Resolve<IEmployeeRepository>();
            shiftRepository = container.Resolve<IShiftRepository>();
            tripRepository = container.Resolve<ITripRepository>();
            loginRepository = container.Resolve<ILoginRepository>();
        }

        public abstract void Process();
    }

    public abstract class BatchRequestProcessor<TBatchRequest> : BatchRequestProcessor
        where TBatchRequest : BatchRequest
    {
        public TBatchRequest BatchRequest { get; set; }

        public virtual void SetBatchRequest(TBatchRequest batchRequest)
        {
            BatchRequest = batchRequest;
        }
    }
}
