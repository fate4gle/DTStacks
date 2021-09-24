using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.diagnostic_msgs
{
    [System.Serializable]
    public class KeyValue : Message
    {
        public string key;
        public string value;
    }
}
