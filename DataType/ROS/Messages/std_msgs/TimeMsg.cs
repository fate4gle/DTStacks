using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class Time: Message
    {
        public uint secs;
        public uint nsecs;
    }
}
