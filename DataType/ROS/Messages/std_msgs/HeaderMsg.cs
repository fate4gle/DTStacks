using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class Header : Message
    {
        public int seq;
        public ROS.Messages.std_msgs.Time stamp;
        public string frame_id;

        public Header()
        {
            stamp = new ROS.Messages.std_msgs.Time();
        }
    }
}
