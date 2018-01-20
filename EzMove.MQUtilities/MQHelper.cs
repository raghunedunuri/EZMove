using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.MQUtilities
{
    public class MQBatchRequest : BatchRequest
    {
        public EventDef EventType { get; set; }
        public object MessageData { get; set; }
    }

    public  class BatchRequest
    {
        public  string QueueTarget { get; }
    }

    public class MQManager
    {
        public static void Queue(BatchRequest batchRequest)
        {
            try
            {
                MessageQueue queue = GetQueue(batchRequest.QueueTarget, QueueAccessMode.Send);
                MessageQueueTransactionType txnType = MessageQueueTransactionType.Single;

                if (queue.CanWrite == false)
                {
                    throw new Exception("PhysicalQueueNotFound: " + batchRequest.QueueTarget);
                }
                queue.Send(batchRequest, txnType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public static MessageQueue GetQueue(string queueName, QueueAccessMode accessMode)
        {
            MessageQueue queue = new MessageQueue(queueName, accessMode);
            queue.Formatter = new ActiveXMessageFormatter();
            return queue;
        }
    }
}
