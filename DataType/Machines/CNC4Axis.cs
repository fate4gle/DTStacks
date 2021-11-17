using System;
using UnityEngine;
using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

using DTStacks.DataType.Generic.Helpers;
using DTStacks.DataType.Generic.Math;
using DTStacks.DataType.Generic.Navigation;

using DTStacks.DataType.ROS.Messages.std_msgs;
using DTStacks.DataType.ROS.Messages.nav_msgs;
using DTStacks.DataType.ROS.Messages.geometry_msgs;
using DTStacks.DataType.ROS.Messages.sensor_msgs;

namespace DTStacks.DataType.Machines
{
    [Serializable]
    public class CNC4Axis : Message
    {

        public float xPosition;
        public float yPosition;
        public float zPosition;
        public float aPosition;
    }
}
