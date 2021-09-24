using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Messages.Aircraft
{
    [System.Serializable]
    public class Performance : Message
    {
        public float horizonatalVelocity;
        public float verticalVelocity;
        public float absVelocity;
    }
}
