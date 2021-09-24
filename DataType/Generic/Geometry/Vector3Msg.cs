using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class Vector3 : Message
    {
        public float x;
        public float y;
        public float z;
        public Vector3(float xIn, float yIn, float zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
        }
    }
}
