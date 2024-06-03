using DTStacks.DataType.ROS.Messages.nav_msgs;
using DTStacks.UnityComponents.Converters;
using UnityEngine;

namespace DTStacks.UnityComponents.ROS.Helpers
{
    public class OdomProcessor : MonoBehaviour
    {
        [Tooltip("The currently set odometry message/data")]
        public Odometry odom = new Odometry();
        [Tooltip("Specify if data origin or destination is a ROS environment. (If true: Automatically converts the data to the correct coordinate system.)")]
        public bool isROSMsg;
        [Tooltip("The speed with which the target pose shall be interpolated towards. (Smoothing of movement if update-rate is low.)")]
        public float interpolationSpeed;
        [Tooltip("Specify the usage of this OdomProcessor, if true, the odometry will automatically be processed each frame.")]
        public bool isPublishing;

        [Tooltip("The Odometry Actuator attached to the specific Object.")]
        public OdomActuator odomActuator;

        [HideInInspector]
        public Space space = Space.Self;

        private void Awake()
        {
           // odom = new Odometry();
        }
        /// <summary>
        /// Sets the target position and orientation of the transform.
        /// </summary>
        /// <param name="odom">The odometry data <c>DTStacks.DataType.ROS.Messages.nav_msgs.Odometry</c></param>
        public void ProcessMessage(Odometry odom)
        {
            this.odom = odom;
        }

        /// <summary>
        /// Gets the Odometry of the specific Objects
        /// </summary>
        /// <param name="space">The reference space of the retrieved Odometry (local or global) </param>
        /// <returns></returns>
        public Odometry GetOdom(Space space)
        {
            return odomActuator.GetOdom(space);
        }

        
        
    }
}
