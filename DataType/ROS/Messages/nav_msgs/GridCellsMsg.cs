using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;
using DTStacks.DataType.ROS.Messages.geometry_msgs;

namespace DTStacks.DataType.ROS.Messages.nav_msgs
{
    [System.Serializable]
    public class GridCells : Message
    {
        public Header header;
        public float cell_width;
        public float cell_height;
        public Point[] cells;
    }
}
