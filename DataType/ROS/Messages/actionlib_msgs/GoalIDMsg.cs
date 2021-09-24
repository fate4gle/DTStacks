using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.actionlib_msgs
{
    [System.Serializable]
    public class GoalID : Message
    {
        public Time stamp;
        public string id;
    }
}
