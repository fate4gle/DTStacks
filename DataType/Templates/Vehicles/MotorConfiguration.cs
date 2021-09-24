using DTStacks.DataType.Templates;


namespace DTStacks.DataType.Templates.Vehicles
{
    [System.Serializable]
    public class MotorConfiguration : Message
    {
        public string motorType;
        public float minTemperature;
        public float maxTemperature;
        public float maxRPM;
        public float maxTorgue;
        public MotorConfiguration(string Type, float MINIMUM_TEMPERATURE, float MAXIMUM_TEMPERATURE, float MAX_RPM, float MAX_TORGUE )
        {
            motorType = Type;
            minTemperature = MINIMUM_TEMPERATURE;
            maxTemperature = MAXIMUM_TEMPERATURE;
            maxRPM = MAX_RPM;
            maxTorgue = MAX_TORGUE;
        }
    }
}
