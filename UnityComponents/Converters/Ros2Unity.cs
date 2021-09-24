using UnityEngine;

namespace DTStacks.UnityComponents.Converters
{
    public static partial class ROSHelpers {
        /// <summary>
        /// Convert a DTStack-type Vector3 to a <c>UnityEngine.Vector3</c>
        /// </summary>
        /// <param name="rosVector3"> ROS Vector3 of type <c>DTStacks.DataType.Generic.Geometry.Vector3</c> in right-handed coordinate system</param>
        /// <returns name="unityVector3"> UnityEngine.Vector3 </returns>
        public static Vector3 ROS2Unity(this DTStacks.DataType.Generic.Geometry.Vector3 rosVector3)
        {
            Vector3 unityVector3 = new Vector3(rosVector3.x, rosVector3.z, rosVector3.y);
            return unityVector3;
        }
        /// <summary>
        /// Right-handed Vector3 to a <c>UnityEngine.Vector3</c> (left-handed)
        /// </summary>
        /// <param name="rosVector3"> ROS Vector3 in right-handed coordinate system</param>
        /// <returns name="unityVector3"> <c>UnityEngine.Vector3</c></returns>
        public static Vector3 ROS2Unity(this Vector3 rosVector3)
        {
            Vector3 unityVector3 = new Vector3(rosVector3.x, rosVector3.z, rosVector3.y);
            return unityVector3;
        }
        /// <summary>
        /// Converts <c>DTStacks.DataType.Generic.Geometry.Quaternion</c> to a <c>UnityEngine.Quaternion</c>
        /// </summary>
        /// <param name="rosQuaternion"> ROS Quaternion as type of <c>DTStacks.DataType.Generic.Geometry.Quaternion</c></param>
        /// <returns name="unityQuaternion"> Quaternion as type of <c>UnityEngine.Quaternion</c></returns>
        public static Quaternion ROS2Unity(this DTStacks.DataType.Generic.Geometry.Quaternion rosQuaternion)
        {
            Quaternion unityQuaternion = new Quaternion(rosQuaternion.x, rosQuaternion.y, rosQuaternion.z, rosQuaternion.w);
            return unityQuaternion;
        }
    }
}
