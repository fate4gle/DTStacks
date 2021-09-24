using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

namespace DTStacks.DataType.Generic.Navigation
{
    [System.Serializable]
    public class Pose : Message
    {
        public Position position;
        public Quaternion orientation;
    }
}
