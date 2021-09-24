using UnityEngine;

using DTStacks.DataType.ROS.Messages.sensor_msgs;
using DTStacks.UnityComponents.Converters;

namespace DTStacks.UnityComponents.ROS.Helpers
{
    [RequireComponent(typeof(UnityEngine.HingeJoint))]
    public class JointStateController : MonoBehaviour
    {
        [Tooltip("The name of the joint in the relevant data message.")]
        public string name;
        [Tooltip("The current angular state of the joint.")]
        public float angle;
        [Tooltip("The current angular velocity of the joint.")]
        public float velocity;
        [Tooltip("The current effort.")]
        public float effort;
        [Tooltip("The angular offset to apply. Relevant if the used model is not in home-pose by default.")]
        public float angleOffset;

        private float targetState;
        [Tooltip("If the robot is publishing, the joint rotation will not be manipulated with every frame.")]
        public bool isPublishing = false;
        private bool isConvertingNecessary;
        [Range(1f, 0.001f)]
        public float interpolationSpeed = 0.1f;


        [HideInInspector]
        public HingeJoint joint;
        /// <summary>
        /// Get the <c>UnityEngine.HingeJoint</c> at the start of the program 
        /// </summary>
        private void Start()
        {
            joint = this.GetComponent<HingeJoint>();
        }
        /// <summary>
        /// Update the joint state at which the <c>JointStateController</c> is attached based on the index
        /// </summary>
        /// <param name="index">Hierachical position of the joint</param>
        /// <param name="msg"><c>JointStateMsg</c> containing the information</param>
        /// <param name="isConvertingNecessary"> Indicate if a conversion from left to right-handed coordinate system is necessary</param>
        public void UpdateJoint(int index, JointStateMsg msg, bool isConvertingNecessary)
        {            
            name = msg.name[index];
            this.isConvertingNecessary = isConvertingNecessary;
            //angle = UnWrapAngle(msg.position[index]);
            angle = Mathf.Rad2Deg *msg.position[index];            
            velocity = msg.velocity[index];
            effort = msg.effort[index];            
            targetState = (angle + angleOffset);
        }
        /// <summary>
        /// Get the current JointState based on the joint.angle and the angular Offset
        /// </summary>
        /// <returns> Returns the current JointState in radians</returns>
        public float GetJointState()
        {
            angle = -(joint.angle + angleOffset) * Mathf.Deg2Rad;
            return angle;
            //return WrapAngle(angle);
        }
        public void Update()
        {
            if (!isPublishing)
            {
                MoveJoint();
            }
        }

        /// <summary>
        /// Moves the joint by lerping from the current position to target position based on the interpolation speed
        /// </summary>
        private void MoveJoint()
        {
            Vector3 angleV;
            angleV = joint.axis * (targetState);

            if (isConvertingNecessary)
            {
                //angleV = angleV.ROS2Unity();
            }

            Quaternion rot = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(-angleV), interpolationSpeed);
            this.transform.localRotation = rot;            
        }


        /// <summary>
        /// Get the current JointState based on the joint.angle and the angular Offset
        /// </summary>
        /// <returns> Returns the current JointState in degrees</returns>
        public float GetJointStateInDegree()
        {
            angle = -(joint.angle + angleOffset);
            return angle;
        }

        #region DEV only
        public float WrapAngle(float a)
        {
            a %= 360;
            if (a > 180)
            {
                return a - 360;
            }
            Debug.Log(a);
            return a;
        }
        public float UnWrapAngle(float a)
        {
            if (a >= 0)
            {
                return a;
            }
            a = -a % 360;
            Debug.Log(a);
            return 360 - a;
        }
        #endregion

    }
}
