using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;
using DTStacks.DataType.ROS.Messages.geometry_msgs;

namespace DTStacks.DataType.ROS.Messages.nav_msgs
{
    [System.Serializable]
    public class Odometry : Message
    {
        public Header header;
        public string child_frame_id;
        public PoseWithCovariance pose;
        public TwistWithCovariance twist;
        
        public Odometry()
        {
            header = new Header();
            pose = new PoseWithCovariance();
            twist = new TwistWithCovariance();
        }        
    }
}
