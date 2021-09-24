using DTStacks.DataType.Generic.Geometry;
using DTStacks.DataType.Generic.Navigation;
using DTStacks.DataType.Templates;


namespace DTStacks.DataType.Vehicles.Airplane.Messages
{
    [System.Serializable]
    public class Odometry : Message
    {
        public Vector3 position;
        public Quaternion rotation;        
    }
}
