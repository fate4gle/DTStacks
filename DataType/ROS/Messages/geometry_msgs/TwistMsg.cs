using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Twist : Message
    {
        public Vector3 linear;
        public Vector3 angular;
    }
}
