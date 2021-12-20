using System;                                           
using UnityEngine;
using DTStacks.DataType.Templates;                  //Provides the message template
using DTStacks.DataType.Generic.Geometry;

// Automatically includes all DTStacks namespaces to prevent errors.
using DTStacks.DataType.Generic.Helpers;
using DTStacks.DataType.Generic.Math;
using DTStacks.DataType.Generic.Navigation;

// Automatically includes all ROS namesapces, since it was enabled in the message-creator window
using DTStacks.DataType.ROS.Messages.std_msgs;
using DTStacks.DataType.ROS.Messages.nav_msgs;
using DTStacks.DataType.ROS.Messages.geometry_msgs;
using DTStacks.DataType.ROS.Messages.sensor_msgs;

namespace DTStacks.DataType.Generic.Custom
{
    [Serializable]
    public class SomeMessage : Message
    {

        public string[] myStrings;
        public float myFloat;
        public ClusterObject clusterObject;


        public SomeMessage() { }
    }
    [Serializable]
    public class ClusterObject
    {
        public string oneString;
        public string anotherString;

        public float oneFloat;
        public float anotherFloat;
    }
}

