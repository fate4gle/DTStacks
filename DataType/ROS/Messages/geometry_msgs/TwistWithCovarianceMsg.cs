using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class TwistWithCovariance : Message
    {
        public Twist twist;
        public float covariance;
    }
}
