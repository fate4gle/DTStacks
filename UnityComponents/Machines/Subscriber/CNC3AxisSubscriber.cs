using UnityEngine;
using System.Collections;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.Machines;


namespace DTStacks.UnityComponents.Machines.Subscriber
{
    public class CNC3AxisSubscriber : DTS_MQTTSubscriber
    {
        public CNC3Axis Msg;
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
