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
            bool result = false;
             
            try
            {
                switch (BatchRequest.EventType)
                {
                    case EventDef.ADDRESSUPDATE:
                        break;

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
