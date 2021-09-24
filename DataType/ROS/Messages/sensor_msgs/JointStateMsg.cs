using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.sensor_msgs
{
    [System.Serializable]
    public class JointStateMsg : Message
    {
        public Header header;
        public string[] name;
        public float[] position;
        public float[] velocity;
        public float[] effort;

        public void SetNumberOfJoints(int i)
        {
            name = new string[i];
            position = new float[i];
            velocity = new float[i];
            effort = new float[i];
        }
    }
}
