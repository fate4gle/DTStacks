using DTStacks.DataType.Generic.Helpers;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class PositionStamped : Message
    {
        public Stamp stamp;
        public Vector3 position;
    }
}
