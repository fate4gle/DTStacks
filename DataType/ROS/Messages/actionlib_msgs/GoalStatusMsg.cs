using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.actionlib_msgs
{
    [System.Serializable]
    public class GoalStatus : Message
    {
        public int status;
        public int PENDING = 0;
        public int ACTIVE = 1;
        public int PREEMPTED = 2;
        public int SUCCEEDED = 3;
        public int ABORTED = 4;
        public int REJECTED = 5;
        public int PREMPTING = 6;
        public int RECALLING = 7;
        public int RECALLED = 8;
        public int LOST = 9;
        public string text;
    }
}
