using System;
using UnityEngine;

namespace DTStacks.UnityComponents.Converters
{
    static class Unity2DTStacks
    {
        public static DTStacks.DataType.Generic.Geometry.Vector3 Point2DTStacks(this DTStacks.DataType.Generic.Geometry.Point a)
        {
            DTStacks.DataType.Generic.Geometry.Vector3 b = new DTStacks.DataType.Generic.Geometry.Vector3(a.x, a.y, a.z);
            return b;
        }

        public static DTStacks.DataType.Generic.Geometry.Vector3 Vector2DTStacks(this UnityEngine.Vector3 a)
        {
            DTStacks.DataType.Generic.Geometry.Vector3 b = new DTStacks.DataType.Generic.Geometry.Vector3(a.x, a.y, a.z);
            return b;
        }

        public static DTStacks.DataType.Generic.Geometry.Quaternion Quaternion2DTStacks(this UnityEngine.Quaternion a)
        {
            DTStacks.DataType.Generic.Geometry.Quaternion b = new DTStacks.DataType.Generic.Geometry.Quaternion(a.x, a.y, a.z, a.w);
            return b;
        }

        public static DTStacks.DataType.Generic.Math.Matrix4x4 Matrix4x42DTStacks(this Matrix4x4 a)
        {
            DTStacks.DataType.Generic.Math.Matrix4x4 m = new DTStacks.DataType.Generic.Math.Matrix4x4();
            for (int i= 0; i<4; i++)
            {
                for (int k = 0; k<4; k++)
                {
                    m.matrix[i, k] = a[i, k];
                }
            }
            return m;
        }
    }
}
