using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.sensor_msgs
{
    [System.Serializable]
    public class RegionOfInterest : Message
    {
        public uint x_offset;
        public uint y_offset;
        public uint height;
        public uint width;
        public bool do_rectify;
    }
}
