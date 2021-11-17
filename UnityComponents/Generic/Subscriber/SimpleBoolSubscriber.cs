using UnityEngine;
using System.Collections;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.Generic;


namespace DTStacks.UnityComponents.Generic.Subscriber.Custom
{
    public class SimpleBoolSubscriber : DTS_MQTTSubscriber
    {
        public SimpleBool Msg;
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
