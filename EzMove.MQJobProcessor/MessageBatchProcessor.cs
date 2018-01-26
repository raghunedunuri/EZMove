using EzMove.Contracts;
using EzMove.MQUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.MQJobProcessor
{
    public class MQJobProcessor : BatchRequestProcessor<MQBatchRequest>
    {
        public MQJobProcessor()
        {
        }

        public override void Process()
        {
            try
            {
                switch (BatchRequest.EventType)
                {
                    case EventDef.FORGOTPASSWORD:
                        break;
                    case EventDef.STARTTRIP:
                        break;
                    case EventDef.STOPTRIP:
                        break;
                    case EventDef.EMPLOYEESHOW:
                        break;
                    case EventDef.EMPLOYEENOSHOW:
                        break;
                    case EventDef.LOCATIONUPDATE:
                        break;
                    case EventDef.NEWEMPLOYEE:
                        break;
                    case EventDef.ADDRESSUPDATE:
                        break;
                    case EventDef.NEWVECHILE:
                        break;
                    case EventDef.VECHILEBREAKDOWN:
                        break;
                    case EventDef.TRAFFICUPDATE:
                        break;
                    case EventDef.SOS:
                        break;
                    case EventDef.ADHOCMESSAGE:
                        break;
                    case EventDef.ADHOCTRIP:
                        break;
                    case EventDef.ADHOCREPORT:
                        break;
                    case EventDef.ROASTERUPDATE:
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
