using DTStacks.DataType.ROS.Messages.nav_msgs;
using DTStacks.UnityComponents.Converters;
using UnityEngine;

namespace DTStacks.UnityComponents.ROS.Helpers
{
    public class OdomHandler : MonoBehaviour
    {
        [Tooltip("The currently set odometry message/data")]
        public Odometry odom;
        [Tooltip("Specify if data origin or destination is a ROS environment. (If true: Automatically converts the data to the correct coordinate system.)")]
        public bool isROSMsg;
        [Tooltip("The speed with which the target pose shall be interpolated towards. (Smoothing of movement if update-rate is low.)")]
        public float interpolationSpeed;
        [Tooltip("Specify the usage of this OdomHandler, if true, the odometry will automatically be processed each frame.")]
        public bool isPublishing;

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
        public void SetTargetPose(Odometry odom)
        {
            this.odom = odom;
        }

        /// <summary>
        /// Each frame Unity checks if the OdomHandler is used for publishing, if this is not the case (e.g. it is subscribed), the object is moved.
        /// </summary>
        private void Update()
        {
            if (!isPublishing)
            {
                ApplyOdom(this.transform, space);
            }
        }
        /// <summary>
        /// Moves the transform towards the current odometry data avilable with a predefined interpolation speed.
        /// </summary>
        /// <param name="t">The transform to apply the odometry to.</param>
        public void ApplyOdom(Transform t, Space space)
        {
            Vector3 pos;
            Quaternion rot;
            if (isROSMsg)
            {
                pos = this.odom.pose.pose.position.ROS2Unity();
                rot = this.odom.pose.pose.orientation.ROS2Unity();
            }
            else
            {
                pos = this.odom.pose.pose.position.Vector2Unity();
                rot = this.odom.pose.pose.orientation.Quaternion2Unity();
            }
            if(space == Space.Self)
            {
                ApplyLocalOdometry(t, pos, rot, interpolationSpeed);
            }
            else
            {
                ApplyWorldOdometry(t, pos, rot, interpolationSpeed);
            }
        }
        public void ApplyLocalOdometry(Transform t,Vector3 position, Quaternion rotation, float lerpSpeed)
        {
            t.transform.localPosition = Vector3.Lerp(t.transform.localPosition, position, lerpSpeed);
            t.localRotation = Quaternion.Lerp(t.transform.localRotation, rotation, lerpSpeed);
        }
        public void ApplyWorldOdometry(Transform t, Vector3 position, Quaternion rotation, float lerpSpeed)
        {
            t.transform.position = Vector3.Lerp(t.transform.position, position, lerpSpeed);
            t.rotation = Quaternion.Lerp(t.transform.rotation, rotation, lerpSpeed);
        }
        /// <summary>
        /// Gets the current odometry of the transform either in local or world space and updates the odometry data in the odom handler.
        /// </summary>
        /// <param name="space">The reference frame of the odometry</param>
        /// <returns>The odometry of the transform.</returns>
        public Odometry GetOdom(Space space)
        {
            Odometry odom = (space == Space.Self) ? GetLocalOdom() : GetWorldOdom();
            return odom;
        }
        /// <summary>
        /// Gets the current odometry data from the attached transform in local space.
        /// </summary>
        /// <returns>The odometry message of the attached transform in local-space</returns>
        public Odometry GetLocalOdom()
        {
            //Odometry odom = new Odometry();
            if (isROSMsg)
            {
                odom.pose.pose.position = this.transform.localPosition.Unity2ROS();
                odom.pose.pose.orientation = this.transform.localRotation.Unity2ROS();
            }
            else
            {
                odom.pose.pose.position = this.transform.localPosition.Vector2DTStacks();
                odom.pose.pose.orientation = this.transform.localRotation.Quaternion2DTStacks();
            }
            return odom;
        }
        /// <summary>
        /// Gets the current odometry data from the attached transform in world space.
        /// </summary>
        /// <returns>The odometry message of the attached transform in world space</returns>
        public Odometry GetWorldOdom()
        {
            if (isROSMsg)
            {
                odom.pose.pose.position = this.transform.position.Unity2ROS();
                odom.pose.pose.orientation = this.transform.rotation.Unity2ROS();
            }
            else
            {
                odom.pose.pose.position = this.transform.position.Vector2DTStacks();
                odom.pose.pose.orientation = this.transform.rotation.Quaternion2DTStacks();
            }
            return odom;
        }
    }
}
