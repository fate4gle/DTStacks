using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class Int64MultiArray : Message
    {
        public MultiArrayLayout layout;
        public int[] data;
    }
}
