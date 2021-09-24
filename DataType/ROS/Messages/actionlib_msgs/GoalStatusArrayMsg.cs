using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.actionlib_msgs
{
    [System.Serializable]
    public class GoalStatusArray : Message
    {
        public Header header;
        public GoalStatus[] status_list; 
    }
}
