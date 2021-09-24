using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;


namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Pose : Message
    {
        public Vector3 position;
        /* alternatively use 
        public Point position;
        */
        public Quaternion orientation;
    }
}
