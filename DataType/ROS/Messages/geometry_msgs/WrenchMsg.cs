using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Wrench : Message
    {
        public Vector3 force;
        public Vector3 torque;
    }
}
