using UnityEngine;
using System.Collections;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.Home;


namespace DTStacks.UnityComponents.Home.Subscriber
{
    public class SimpleLightSubscriber : DTS_MQTTSubscriber
    {
        public SimpleLight Msg;
        public void FeedData(string s)
        {
            Msg.FeedDataFromJSON(s);
        }

        public override void ProcessMessage(string msg)
        {
            FeedData(msg);
        }

        // Use this for extras during initialization
        public override void ExtendedStart()
        {

        }


        // Extended Update function, will be executed after regular update
        public override void ExtendedUpdate()
        {

        }
    }
}
