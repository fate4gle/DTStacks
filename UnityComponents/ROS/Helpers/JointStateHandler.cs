using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.UnityComponents.ROS.Helpers;
using DTStacks.DataType.ROS.Messages.sensor_msgs;

namespace DTStacks.UnityComponents.ROS.Helpers
{
    public class JointStateHandler : MonoBehaviour
    {
        [Tooltip("The latets jointStateMsg")]
        public JointStateMsg jointStateMsg;

        [Tooltip("List of all joint state controllers found within the object tree below the robot parent.")]
        public JointStateController[] jointStateControllers;


        private void Start()
        {
            jointStateMsg.SetNumberOfJoints(jointStateControllers.Length);
            for (int i = 0; i < jointStateControllers.Length; i++)
            {
                jointStateMsg.name[i] = jointStateControllers[i].name;
            }
        }

        public JointStateMsg GetJointStateMsg()
        {
            for (int i = 0; i < jointStateControllers.Length; i++)
            {
                jointStateMsg.name[i] = jointStateControllers[i].name;
                jointStateMsg.position[i] = jointStateControllers[i].GetJointState();
            }
            return jointStateMsg;
        }




        /// <summary>
        /// Initiates all JointStateControllers to update their joint angle based on the JointStateMessage. Indicate if it is a ROS-Message.
        /// </summary>
        /// <param name="jsc">List of <c>JointStateControllers</c></param>
        /// <param name="jsm">The <c>JointStateMessage</c> with updated paramters</param>
        /// <param name="ros">Bool indicating if it is a ros-message and additional steps have to be taken.</param>
        public void UpdateJointStates(JointStateController[] jsc, JointStateMsg jsm, bool ros)
        {
            for (int i = 0; i < jsc.Length; i++)
            {
                jsc[i].UpdateJoint(i, jsm, ros);
            }
        }
    }
}
