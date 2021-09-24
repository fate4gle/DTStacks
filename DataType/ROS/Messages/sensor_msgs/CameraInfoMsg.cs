using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.sensor_msgs
{
    [System.Serializable]
    public class CameraInfo : Message
    {
        public Header header;
        public int height;
        public int width;
        public string distortion_model;
        public float[] D;
        public float[] K = new float[9];
        public float[] R = new float[9];
        public float[] P = new float[12];
        public int binning_x;
        public int binning_y;
        public RegionOfInterest roi;
    }
}
