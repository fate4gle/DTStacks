using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.sensor_msgs
{
    [System.Serializable]
    public class Image : Message
    {
        public Header header;
        public uint height;
        public uint width;
        public string encoding;
        public uint is_bigendian;
        public int step;
        public int[] data;
    }
}
