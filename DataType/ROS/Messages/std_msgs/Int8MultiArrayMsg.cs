using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class Int8Multiarray : Message 
    {
        public MultiArrayLayout layout;
        public int[] data;
    }
}
