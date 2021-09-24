using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class Quaternion : Message
    {
        public float x;
        public float y;
        public float z;
        public float w;
        public Quaternion(float xIn, float yIn, float zIn, float wIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
            w = wIn;
        }
    }
}
