using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Polygon: Message
    {
        public Point32[] points;
    }
}
