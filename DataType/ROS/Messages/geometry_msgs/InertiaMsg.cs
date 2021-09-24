using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    [System.Serializable]
    public class Inertia : Message
    {
        public float m;
        public Vector3 com;
        public float ixx;
        public float ixy;
        public float ixz;
        public float iyy;
        public float iyz;
        public float izz;
    }
}
