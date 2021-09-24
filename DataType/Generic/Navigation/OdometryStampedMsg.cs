using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Helpers;

namespace DTStacks.DataType.Generic.Navigation
{
    [System.Serializable]
    public class OdometryStamped : Message
    {
        public Stamp stamp;
        public Odometry odom;
    }
}
