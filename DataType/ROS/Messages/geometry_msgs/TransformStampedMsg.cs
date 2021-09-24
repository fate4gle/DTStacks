using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class TransformStamped : Message
    {
        public Header header;
        public string child_frame_id;
        public Transform transform;
    }
}
