using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class Point : Message
    {
        public float x;
        public float y;
        public float z;

        public Point (float inX, float inY, float inZ)
        {
            x = inX;
            y = inY;
            z = inZ;
        }
    }
}
