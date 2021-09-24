using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Transform : Message
    {
        public Vector3 translation;
        public Quaternion rotation;

    }
}
