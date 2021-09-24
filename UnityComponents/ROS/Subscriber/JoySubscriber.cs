
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using UnityEngine;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.ROS.Messages.sensor_msgs;

namespace DTStacks.UnityComponents.ROS.Subscriber
{
    class JoySubscriber : DTS_MQTTSubscriber
    {
        public Transform subscribedTransform;
        public Joy joy;
        public bool isROSMsg;


        public void FeedData(string s)
        {
            joy.FeedDataFromJSON(s);
        }
        
        public Vector3 ROS2Unity(Vector3 a)
        {
            Vector3 b = new Vector3(a.x, a.z, a.y);
            return b;
        }
    }
}
