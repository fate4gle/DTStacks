using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class PoseWithCovariance : Message
    {
        public Pose pose;
        public float covariance;
    }
}
