using EzMove.MQUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EzMove.MQJobProcessor
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        private ServiceImplementation<MQBatchRequest, MQJobProcessor> _mqImplementation = new ServiceImplementation<MQBatchRequest, MQJobProcessor>
            (ConfigurationManager.AppSettings["ListeningQueue"], Convert.ToInt32( ConfigurationManager.AppSettings["MaxThreads"]));
  
        protected override void OnStart(string[] args)
        {
            Thread threadUploadMain = new Thread(_mqImplementation.Loop);
            threadUploadMain.Start();
        }

        protected override void OnPause()
        {
            _mqImplementation.Listen = false;
        }

        protected override void OnContinue()
        {
            _mqImplementation.Listen = true;
        }

        protected override void OnStop()
        {
            _mqImplementation.StopService = true;
        }
    }
}
