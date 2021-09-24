using UnityEngine;
using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.ROS.Messages.nav_msgs;
using DTStacks.UnityComponents.Converters;
using DTStacks.UnityComponents.ROS.Helpers;

namespace DTStacks.UnityComponents.ROS.Publisher
{
    public class OdometryPublisher : DTS_MQTTPubilsher
    {

        [Tooltip("The odometry handler which shall be used for this publisher.")]
        public OdomHandler odomHandler;
        [Tooltip("The reference system of the odometry message. (Default = Self = local space)")]
        public Space referenceSystem;
        [Tooltip("The current odometry message.")]
        public Odometry odom;
        [Tooltip("Specify if the odom message is coming or going to a ROS-system. The coordinate system will automatically be adapted.")]
        public bool isROSMsg;


        /// <summary>
        /// Initiates the gatherng of data, feeds it in the odom message and returns it as a JSON
        /// </summary>
        /// <returns>THe JSON-String containing the odometry data</returns>
        public string GetData()
        {
            GetOdom();
            return odom.CreateJSONFromData();
        }
        /// <summary>
        /// Gets the odometry from the odom handler as Odometry message. Uses the reference system indicated in the inspector.
        /// </summary>
        public void GetOdom()
        {
            odom = odomHandler.GetOdom(referenceSystem);
        }
        public override void ExtendedStart()
        {
            odomHandler.isPublishing = true;
            odomHandler.isROSMsg = isROSMsg;

            odom = new Odometry();
        }
        public override void ExtendedUpdate()
        {

        }
        public override void InitPublishing()
        {
            base.InitPublishing();
            PublishMsg(GetData());
        }   
    }
}
