using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class QuaternionStamped : Message
    {
        public Header header;
        public Quaternion quaternion;
    }
}
