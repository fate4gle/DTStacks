using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.diagnostic_msgs
{
    [System.Serializable]
    public class DiagnosticArray : Message
    {
        public Header header;
        DiagnosticStatus[] status;
    }
}
