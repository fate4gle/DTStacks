using DTStacks.DataType.Generic.Geometry;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Accel : Message
    {
        public Vector3 linear;
        public Vector3 angular;
    }
}
