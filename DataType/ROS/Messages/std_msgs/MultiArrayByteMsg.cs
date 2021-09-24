using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class MultiArrayByte : Message
    {
        public MultiArrayLayout layout;
        public @byte[] data; 
    }
}
