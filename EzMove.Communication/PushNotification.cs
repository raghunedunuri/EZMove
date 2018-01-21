using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EzMove.Communication
{
    public class NotificationData
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string NotificationTime { get; set; }
    }

    public class Notification
    {
        public string to { get; set; }
        public NotificationData data { get; set; }
    }

    public class FCMResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FCMResult> results { get; set; }
    }
    public class FCMResult
    {
        public string message_id { get; set; }
    }

    public class PushCommunication
    {
        public static string ServerID = "AAAASqXdum8:APA91bGpHs0Ng5gwTfWtxSDpAcgoXoSR9Fg2Cv4w4tAD_oeVtXvZq3lQ1qPpaxrXpIWBYi7yMNp2aSFWmfxfiVy0yNbkDOBIzYoQyAfrmpfOaSPzwS_2N9vK0hwyEJ7gW7OssrdK62kg";
        public static string SenderID = "320610351727";

        public PushCommunication()
        {
        }

        public static void SendNotification(string To, string Title, string Message)
        {
            try
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                string ur = "Test";
                var objNotification = new
                {
                    to = To,
                    data = new
                    {
                        title = Title,
                        body = Message,
                        deliverytime = String.Format( "{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()),
                        dimage = ur
                    }
                };
                string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", ServerID));
               // tRequest.Headers.Add(string.Format("Sender: id={0}", SenderID));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String responseFromFirebaseServer = tReader.ReadToEnd();
                                FCMResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                                if (response.success == 1)
                                {
                                }
                                else if (response.failure == 1)
                                {
                                }

                            }
                        }

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
