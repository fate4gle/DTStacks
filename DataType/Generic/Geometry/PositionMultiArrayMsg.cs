using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Helpers;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class PositionMultiArray : Message
    {
        public string label;
        public MultiArrayLayout layout;
        public Vector3[] position;
    }
}
