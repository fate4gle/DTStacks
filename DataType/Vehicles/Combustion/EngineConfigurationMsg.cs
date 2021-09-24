using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Combustion
{
    public class EngineConfiguration : Message
    {
        public string TYPE;
        public float MINIMUM_TEMPERATURE;
        public float MAXIMUM_TEMPERATURE;
        public float FUEL_CAPACITY;
        public float MIN_RPM;
        public float MAX_RPM;
        public float MAX_TORGUE;
        public float MAX_POWER;
    }
}
