using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.nav_msgs
{
    [System.Serializable]
    public class OccupancyGrid : Message
    {
        public Header header;
        public MapMetaData info;
        public int[] data;
    }
}
