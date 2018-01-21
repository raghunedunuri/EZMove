using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public  string QueueTarget { get; set; }
    }

    public class MQManager
    {
        private static string TripQueue;
        private static string EmployeeQueue;

        static MQManager()
        {
            TripQueue = ConfigurationManager.AppSettings["TripUpateQueue"];
            EmployeeQueue = ConfigurationManager.AppSettings["EmployeeUpateQueue"];

        }
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

        public static void PushTripStatus( string TripID, EventDef aEvent )
        {
            MessageQueue queue = GetQueue(TripQueue, QueueAccessMode.Send);
            MessageQueueTransactionType txnType = MessageQueueTransactionType.Single;
            MQBatchRequest mqBatchRequest = new MQBatchRequest()
            {
                EventType = aEvent,
                MessageData = TripID,
                QueueTarget = TripQueue
            };
            queue.Send(mqBatchRequest, txnType);
        }

        public static void PushTripInfo(string TripID, int EmployeeID, EventDef aEvent)
        {
            MessageQueue queue = GetQueue(TripQueue, QueueAccessMode.Send);
            MessageQueueTransactionType txnType = MessageQueueTransactionType.Single;
            MQBatchRequest mqBatchRequest = new MQBatchRequest()
            {
                EventType = aEvent,
                MessageData = new TripPersonUpdate()
                {
                    TripID = TripID,
                    EmployeeID = EmployeeID
                },
                QueueTarget = TripQueue
            };
            queue.Send(mqBatchRequest, txnType);
        }
    }
}
