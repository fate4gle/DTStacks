﻿using UnityEngine;

using DTStacks.UnityComponents.ROS.Helpers;
using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.ROS.Messages.nav_msgs;
using DTStacks.UnityComponents.Converters;

namespace DTStacks.UnityComponents.ROS.Subscriber
{
    class OdometrySubscriber : DTS_MQTTSubscriber
    {
        [Tooltip("Specify if the incoming odometry's origin is a ROS environment. The odommetry will autommatically be transfered to the unity coordinate system.")]
        public bool isROSMsg;
        [Tooltip("The handler attached to the gamobject to which the odometry shall be applied to.")]
        public OdomProcessor odomProcessor;
        [Tooltip("The reference system of the odometry message. (Default = Self = local space)")]
        public Space referenceSystem;
        [Tooltip("The latest received odometry message.")]
        public Odometry odom;

        public override void ExtendedStart()
        {
            base.ExtendedStart();
            odomProcessor.isROSMsg = isROSMsg;
            odomProcessor.isPublishing = false;
            odom = new Odometry();
            odomProcessor.space = referenceSystem;
        }

        public override void ProcessMessage(string msg)
        {
            FeedData(msg);
        }
        public void FeedData(string s)
        {
            odomProcessor.ProcessMessage(odom);
            odom.FeedDataFromJSON(s);
            odomProcessor.ProcessMessage(odom);
        }
    }
}
