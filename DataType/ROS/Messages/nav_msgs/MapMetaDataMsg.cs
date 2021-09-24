using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.geometry_msgs;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.nav_msgs
{
    [System.Serializable]
    public class MapMetaData : Message
    {
        public Time map_load_time;
        public float resolution;
        public int width;
        public int height;
        public Pose origin;
    }
}
