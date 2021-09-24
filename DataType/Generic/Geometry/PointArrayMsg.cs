using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Helpers;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class PointArray : Message
    {
        public string label;
        public ArrayDimension dim;
        public Point[] points;
    }
}
