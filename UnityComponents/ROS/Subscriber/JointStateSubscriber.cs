using UnityEngine;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.UnityComponents.ROS.Helpers;
using DTStacks.DataType.ROS.Messages.sensor_msgs;


namespace DTStacks.UnityComponents.ROS.Subscriber
{
    public class JointStateSubscriber : DTS_MQTTSubscriber
    {
        [Tooltip("The latest received joint state message")]
        public JointStateMsg jointStateMsg;
        [Tooltip("If the messages are incoming from ROS, a conversion between axis-systems needs to be applied.")]
        public bool isROSMsg;
        [Tooltip("The robot parent object for which the joint states are applied to.")]
        public GameObject robotParent;
        [Range(1f, 0.001f)]
        [Tooltip("Interpolation speed with which the robot adapts its joint positions towards the latest message.(Used for smoothing the joint movements at lower update rates.)")]
        public float interpolationSpeed = 0.1f;
        [Tooltip("The JointStateProcessor who is controlling the JointStateActuators in question.")]
        public JointStateProcessor JointStateProcessor;


        public override void ExtendedStart()
        {
            jointStateMsg.SetNumberOfJoints(JointStateProcessor.JointStateActuators.Length);
        }
        public void FeedData(string s)
        {            
            jointStateMsg.FeedDataFromJSON(s);
            JointStateProcessor.ProcessMessage(JointStateProcessor.JointStateActuators,jointStateMsg, isROSMsg);            
        }
       
        /// <summary>
        /// Defines what happens with the message. Use this to start the Unity-Data-pipeline
        /// </summary>
        /// <param name="msg"> The received message (usually a JSON)</param>
        public override void ProcessMessage(string msg)
        {
            FeedData(msg);
        }
        /// <summary>
        /// Editor Void: Only used for the UnityEditor. Finds and configures the JointStateActuators in hierachical order
        /// </summary>
        public void FindJoints()
        {
            JointStateProcessor.JointStateActuators = robotParent.GetComponentsInChildren<JointStateActuator>();
            foreach (JointStateActuator jsc in JointStateProcessor.JointStateActuators)
            {
                jsc.name = jsc.gameObject.name;
                jsc.isPublishing = false;
                jsc.interpolationSpeed = this.interpolationSpeed;
            }
        }
    }
}
