using UnityEngine;

namespace DTStacks.UnityComponents.Converters
{
    public static partial class ROSHelpers
    {
        /// <summary>
        /// Converts a <c>UnityEngine.Vector3</c> to a ROS Vector3, including the coordinate system transfer.
        /// </summary>
        /// <param name="unityVector3"> The <c>UnityEngine.Vector3</c></param>
        /// <returns><c>DTStacks.DataType.Generic.Geometry.Vector3 including coordinate system transfer</c></returns>
        public static DTStacks.DataType.Generic.Geometry.Vector3 Unity2ROS(this Vector3 unityVector3)
        {
            DTStacks.DataType.Generic.Geometry.Vector3 rosVector3 = new DTStacks.DataType.Generic.Geometry.Vector3(unityVector3.x, unityVector3.y, unityVector3.z);
            return rosVector3;
        }

        /// <summary>
        /// Converts a <c>DTStacks.DataType.Generic.Geometry.Vector3</c> to a ROS Vector3, including the coordinate system transfer.
        /// </summary>
        /// <param name="unityVector3"> The <c>DTStacks.DataType.Generic.Geometry.Vector3</c></param>
        /// <returns><c>DTStacks.DataType.Generic.Geometry.Vector3 including coordinate system transfer</c></returns>
        public static Vector3 Unity2ROS(this DTStacks.DataType.Generic.Geometry.Vector3 unityVector3)
        {
            Vector3 rosVector3 = new Vector3(unityVector3.x, unityVector3.z, unityVector3.y);
            return rosVector3;
        }

        /// <summary>
        /// Converts  <c>UnityEngine.Quaternion</c> to <c>DTStacks.DataType.Generic.Geometry.Quaternion</c>
        /// </summary>
        /// <param name="rosQuaternion"> ROS Quaternion as type of <c>DTStacks.DataType.Generic.Geometry.Quaternion</c></param>
        /// <returns name="unityQuaternion"> Quaternion as type of <c>UnityEngine.Quaternion</c></returns>
        public static DTStacks.DataType.Generic.Geometry.Quaternion Unity2ROS(this Quaternion unityQuaternion)
        {
            DTStacks.DataType.Generic.Geometry.Quaternion rosQuaternion = new DTStacks.DataType.Generic.Geometry.Quaternion(unityQuaternion.x, unityQuaternion.y, unityQuaternion.z, unityQuaternion.w);
            return rosQuaternion;
        }
    }
}
