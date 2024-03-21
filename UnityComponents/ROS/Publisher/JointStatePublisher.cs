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

        [Tooltip("Get a refrence to the joint state handler.")]
        public JointStateProcessor JointStateProcessor;

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
            jointStateMsg = JointStateProcessor.GetJointStateMsg();
        }

        public override void ExtendedStart()
        {
            
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
            JointStateProcessor.jointStateControllers = robotParent.GetComponentsInChildren<JointStateActuator>();
            foreach(JointStateActuator jsc in JointStateProcessor.jointStateControllers)
            {
                jsc.name = jsc.gameObject.name;
                jsc.isPublishing = true;
            }
        }
        #endregion
    }
}
