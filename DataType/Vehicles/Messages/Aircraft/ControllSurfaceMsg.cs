using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Messages.Aircraft
{
    [System.Serializable]
    public class ControllSurfaceMsg: Message
    {
        public float rudder;
        public float aileron;
        public float flaps;
        public float elevator;
        public float genDeflection;
        public ControllSurfaceMsg (float Rudder, float Aileron, float Flaps,  float Elevator, float GenDeflection)
        {
            rudder = Rudder;
            aileron = Aileron;
            flaps = Flaps;
            elevator = Elevator;
            genDeflection = GenDeflection;
        }
    }
}
