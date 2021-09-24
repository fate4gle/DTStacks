using System;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.std_msgs
{
    [System.Serializable]
    public class MultiArrayLayout : Message
    {
        public MultiArrayDimension[] dim;
        public UInt32 data_offset;
    }
}
