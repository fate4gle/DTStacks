using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Helpers;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class PointStamped : Message
    {
        public Stamp stamp;
        public Point point;
    }
}
