using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Geometry
{
    [System.Serializable]
    public class Vector3 : Message
    {
        public float x;
        public float y;
        public float z;
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
