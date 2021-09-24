using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;
using DTStacks.DataType.ROS.Messages.geometry_msgs;

namespace DTStacks.DataType.ROS.Messages.nav_msgs
{
    [System.Serializable]
    public class Path : Message
    {
        public Header header;
        public PoseStamped[] poses;
    }
}
