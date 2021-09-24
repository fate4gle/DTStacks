using UnityEngine;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.UnityComponents.ROS.Helpers;
using DTStacks.DataType.ROS.Messages.sensor_msgs;

namespace DTStacks.UnityComponents.ROS.Publisher
{
    public class JointStatePublisher : DTS_MQTTPubilsher
    {
        [Tooltip("The last published joint state message")]
        public JointStateMsg jointStateMsg;
        [Tooltip("The robot which the joint state message shall represent")]
        public GameObject robotParent;

        [Tooltip("List of all joint state controllers found within the object tree below the robot parent.")]
        public JointStateController[] jointStateControllers;

        /// <summary>
        /// Gets the latest joint states from all known joint state controllers and creates a JSON representation of it.
        /// </summary>
        /// <returns>The joint state message as a JSON-string</returns>
        public string GetData() //So far onnly joint_states
        {
            GetJointStates();
            return jointStateMsg.CreateJSONFromData();
        }

        /// <summary>
        /// Updates the JointStatesMessage based on the known joint state controllers.
        /// </summary>
        void GetJointStates()
        {
            for (int i = 0; i < jointStateControllers.Length; i++)
            {
                jointStateMsg.name[i] = jointStateControllers[i].name;
                jointStateMsg.position[i] = jointStateControllers[i].GetJointState();                
            }
        }

        public override void ExtendedStart()
        {
            jointStateMsg.SetNumberOfJoints(jointStateControllers.Length);
            for(int i =0; i<jointStateControllers.Length; i++)
            {
                jointStateMsg.name[i] = jointStateControllers[i].name;
            }
        }
        public override void ExtendedUpdate()
        {

        }

        public override void InitPublishing()
        {
            base.InitPublishing();
            PublishMsg(GetData());
        }
        #region EditorFunctions

        /// <summary>
        /// Finds all joint state controllers in the object tree below the robotParent object.
        /// </summary>
        public void FindJoints()
        {
            jointStateControllers = robotParent.GetComponentsInChildren<JointStateController>();
            foreach(JointStateController jsc in jointStateControllers)
            {
                jsc.name = jsc.gameObject.name;
                jsc.isPublishing = true;
            }
        }
        #endregion
    }
}
