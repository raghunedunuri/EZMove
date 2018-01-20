using EzMove.MQUtilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EzMove.MQJobProcessor
{
    internal class ServiceImplementation<TBatchRequest, TBatchProcessor>
        where TBatchRequest : BatchRequest, new()
        where TBatchProcessor : BatchRequestProcessor<TBatchRequest>, new()
    {
        private string _queueName;
        private int _maxThreads;

        public ServiceImplementation(string queueName, int maxThreads)
        {
            _queueName = queueName;
            _maxThreads = maxThreads;
        }

        private class ThreadInfo<TProcessor>
            where TProcessor : BatchRequestProcessor
        {
            public readonly TProcessor Processor;
            public readonly Thread Thread;

            public ThreadInfo(TProcessor processor, Thread thread)
            {
                Processor = processor;
                Thread = thread;
            }
        }

        public bool StopService = false;
        public bool Listen = true;

        private List<ThreadInfo<TBatchProcessor>> _threadInfo = new List<ThreadInfo<TBatchProcessor>>();

        private TimeSpan PollingInterval
        {
            get
            {
                return new TimeSpan(0, 0, 0, 0, Convert.ToInt32(ConfigurationManager.AppSettings["PollingInterval"]));
            }
        }

        internal void Loop()
        {
            try
            {
                MessageQueue queue = MQManager.GetQueue(_queueName, QueueAccessMode.Receive);

                if (queue.CanRead == false)
                {
                    throw new InvalidOperationException("Unable to read from queue [" + _queueName + "]");
                }
                else
                {
                    //  Logger.Log(null, "Queue {0} open and can read", _queueName);
                }

                string queueAddress = queue.Path;

                while (StopService == false)
                {
                    while (Listen == true)
                    {
                        int i = 0;
                        while (i < _threadInfo.Count)
                        {
                            ThreadInfo<TBatchProcessor> threadInfo = _threadInfo[i];
                            if (threadInfo.Processor.Completed == true)
                            {
                                threadInfo.Thread.Abort();
                                _threadInfo.RemoveAt(i);
                            }
                            else
                            {
                                i++;
                            }
                        }

                        if (_threadInfo.Count < _maxThreads)
                        {
                            try
                            {
                                Message msg = queue.Receive(PollingInterval);
                                TBatchRequest batchRequest = (TBatchRequest)msg.Body;
                              
                                TBatchProcessor processor = new TBatchProcessor();
                                processor.SetBatchRequest(batchRequest);

                                Thread thread = new Thread(processor.Process);
                                thread.Start();

                                ThreadInfo<TBatchProcessor> threadInfo = new ThreadInfo<TBatchProcessor>(processor, thread);
                                _threadInfo.Add(threadInfo);
                            }
                            catch (MessageQueueException mqEx)
                            {
                                switch (mqEx.MessageQueueErrorCode)
                                {
                                    case MessageQueueErrorCode.IOTimeout:
                                        // all good, no message to get
                                        break;

                                    default:
                                        throw;
                                }
                            }
                        }
                        else
                        {
                            // all threads loaded up, so wait a bit before seeing if we can remove any again
                            Thread.Sleep(PollingInterval);
                        }
                    }
                    // check stopping
                    if (StopService == true)
                    {
                        break;
                    }
                    //Logger.Log("StopService is {0}", StopService.ToString());
                }
            }
            catch (Exception e)
            {
                //throw;
            }
            Thread.CurrentThread.Abort(); // kill me now..
        }
    }
}
