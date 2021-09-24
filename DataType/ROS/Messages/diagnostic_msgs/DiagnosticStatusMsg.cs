using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.diagnostic_msgs
{
    [System.Serializable]
    public class DiagnosticStatus : Message
    {
        public byte OK = 0;
        public byte WARN = 1;
        public byte ERROR = 2;
        public byte STALE = 3;
        public byte level;
        public string name;
        public string message;
        public string hardware_id;
        public KeyValue[] values;
    }
}
