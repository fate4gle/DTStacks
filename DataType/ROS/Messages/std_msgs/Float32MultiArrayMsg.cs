using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class Float32MultiArray : Message
    {
        public MultiArrayLayout layout;
        public float[] data;        
    }
}
