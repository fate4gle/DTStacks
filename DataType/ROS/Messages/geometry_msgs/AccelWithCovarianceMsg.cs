using DTStacks.DataType.Templates;

namespace DTStacks.DataType.ROS.Messages.geometry_msgs
{
    /// <summary>
    /// Needs to be intialized with covariance as a float[36]
    /// </summary>
    [System.Serializable]
    public class AccelWithCovariance : Message
    {
        public Accel accel;
        public float[] covariance = new float[36];
    }
}
