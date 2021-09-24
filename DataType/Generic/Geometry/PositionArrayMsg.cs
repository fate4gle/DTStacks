using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Helpers;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class PositionArray
    {
        public string label;
        public ArrayDimension dim;
        public Vector3[] position;
    }
}
