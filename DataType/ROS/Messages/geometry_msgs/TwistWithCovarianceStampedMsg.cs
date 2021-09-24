using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class TwistWithCovarianceStamped : Message
    {
        public Header header;
        public TwistWithCovariance twist;
    }
}
