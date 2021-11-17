using System;
using UnityEngine;

namespace DTStacks.UnityComponents.Converters
{
    public static class DTStacks2Unity
    {
        /// <summary>
        /// Transforms a 3D Point from DTStacks Vector3 to Unity Vector3 framework.
        /// </summary>
        /// <param name="a"> The DTStacks.Vector3 point to transform</param>
        /// <returns>The transformed Point as Vector3</returns>
        public static Vector3 Point2Unity(this DTStacks.DataType.Generic.Geometry.Point a)
        {
            Vector3 b = new Vector3(a.x, a.y, a.z);
            return b;
        }

        public static Vector3 Vector2Unity(this DTStacks.DataType.Generic.Geometry.Vector3 a)
        {
            Vector3 b = new Vector3(a.x, a.y, a.z);
            return b;
        }

        public static Quaternion Quaternion2Unity(this DTStacks.DataType.Generic.Geometry.Quaternion a)
        {
            Quaternion b = new Quaternion(a.x, a.y, a.z, a.w);
            return b;
        }

        public static Matrix4x4 Matrix4x42Unity(this DTStacks.DataType.Generic.Math.Matrix4x4 a)
        {
            Matrix4x4 m = new Matrix4x4();
            for (int i= 0; i<4; i++)
            {
                for (int k = 0; k<4; k++)
                {
                    m[i, k] = a.matrix[i, k];
                }
            }
            return m;
        }
    }
}
