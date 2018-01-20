using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using EzMove.MQUtilities;

namespace EzMove.MQJobProcessor
{
    public abstract class BatchRequestProcessor
    {
        public bool Completed { get; protected set; }
        public bool Result { get; protected set; }

        public BatchRequestProcessor()
        {
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
