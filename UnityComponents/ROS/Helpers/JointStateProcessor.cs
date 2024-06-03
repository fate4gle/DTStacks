using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.UnityComponents.ROS.Helpers;
using DTStacks.DataType.ROS.Messages.sensor_msgs;
using DTStacks.UnityComponents.Communication.Templates;
using System;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DTStacks.UnityComponents.ROS.Helpers
{
    public class JointStateProcessor : Processor
    {
        [Tooltip("The latest jointStateMsg")]
        public JointStateMsg jointStateMsg;

        [Tooltip("List of all joint state controllers found within the object tree below the robot parent.")]
        public JointStateActuator[] JointStateActuators;


        private void Start()
        {
            jointStateMsg.SetNumberOfJoints(JointStateActuators.Length);
            for (int i = 0; i < JointStateActuators.Length; i++)
            {
                jointStateMsg.name[i] = JointStateActuators[i].name;
            }
        }

        public JointStateMsg GetJointStateMsg()
        {
            for (int i = 0; i < JointStateActuators.Length; i++)
            {
                jointStateMsg.name[i] = JointStateActuators[i].name;
                jointStateMsg.position[i] = JointStateActuators[i].GetJointState();
            }
            return jointStateMsg;
        }
        /// <summary>
        /// Activates the Processor based on the received data
        /// </summary>
        /// <param name="jsa">Array of the relevant JointStateActuators in the system.</param>
        /// <param name="jsm">The <c>JointStateMessage</c> with updated paramters</param>
        /// <param name="ros">Bool indicating if it is a ros-message and additional steps have to be taken.</param>
        public void ProcessMessage(JointStateActuator[] jsa, JointStateMsg jsm, bool ros)
        {
            UpdateJointStates(jsa, jsm, ros);
        }


        /// <summary>
        /// Initiates all JointStateActuators to update their joint angle based on the JointStateMessage. Indicate if it is a ROS-Message.
        /// </summary>
        /// <param name="jsa">List of <c>JointStateActuators</c></param>
        /// <param name="jsm">The <c>JointStateMessage</c> with updated paramters</param>
        /// <param name="ros">Bool indicating if it is a ros-message and additional steps have to be taken.</param>
        public void UpdateJointStates(JointStateActuator[] jsa, JointStateMsg jsm, bool ros)
        {
            for ( int i = 0; i < jsm.name.Length; i++)
            {
                var foundJoinstStateActuator = jsa.SingleOrDefault(item => item.name == jsm.name[i]);
                foundJoinstStateActuator.ActuateMessage(i, jsm, ros);
            }
        }
    }
}
