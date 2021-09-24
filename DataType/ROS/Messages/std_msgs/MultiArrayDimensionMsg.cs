using System;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class MultiArrayDimension : Message
    {
        public string label;
        public UInt32 size;
        public UInt32 stride;
    }
}
