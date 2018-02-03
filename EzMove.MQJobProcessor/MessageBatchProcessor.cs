using EzMove.Cache;
using EzMove.Communication;
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
                        HandleForgotPassword(BatchRequest);
                        break;
                    case EventDef.STARTTRIP:
                        HandleStartTrip(BatchRequest);
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
        private void HandleForgotPassword(MQBatchRequest batchRequest )
        {
            LoginResponse lr = (LoginResponse)batchRequest.MessageData;
            MailUtiliities.SendMail(lr.Email, "", "", (int)batchRequest.EventType);
        }
        private void HandleStartTrip(MQBatchRequest batchRequest)
        {
            Trip currTrip = CacheImplementor.GetTrip(batchRequest.MessageData.ToString());

            foreach( KeyValuePair<int, TripPerson> kv in currTrip.PassengarInfo)
            {
                LoginResponse lr = CacheImplementor.GetUserInfo(kv.Value.ID.ToString());
                if( lr != null && !String.IsNullOrEmpty(lr.FirebaseID))
                {
                    PushCommunication.SendNotification(lr.FirebaseID, "TRIP STARTED",
                        String.Format("Your trip is started and Vechile: {0} ({1}) Driver: {2} ({3}) is assigned",
                        currTrip.VechileData.VechileModel, currTrip.VechileData.VechileNumber,
                        currTrip.DriverData.DriverName, currTrip.DriverData.DriverPhoneNumber));
                }
            }
        }
        private void HandleStopTrip(MQBatchRequest batchRequest)
        {
            Trip currTrip = CacheImplementor.GetTrip(batchRequest.MessageData.ToString());

            foreach (KeyValuePair<int, TripPerson> kv in currTrip.PassengarInfo)
            {
                LoginResponse lr = CacheImplementor.GetUserInfo(kv.Value.ID.ToString());
                if (lr != null && !String.IsNullOrEmpty(lr.FirebaseID))
                {
                    PushCommunication.SendNotification(lr.FirebaseID, "TRIP STARTED",
                        String.Format("Your trip had been started and Driver: {0} Number: {1] is assigned",
                        currTrip.DriverData.DriverName, currTrip.DriverData.DriverPhoneNumber));
                }
            }
        }
    }
}
