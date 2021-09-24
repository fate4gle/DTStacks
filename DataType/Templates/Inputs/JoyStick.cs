using DTStacks.DataType.Generic.Geometry;
using DTStacks.DataType.Templates;

namespace Assets.DTStacks.DataType.Templates.Inputs
{
    [System.Serializable]
    public class JoyStick : Message
    {
        public float X;
        public float Y;
        public float Z;
        public JoyStick(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Collects the JoyStick-Status and returns as them as a float[3] in X,Y,Z.
        /// </summary>
        /// <returns> Returns Joystick values as a float[3] in X,Y,Z.</returns>
        public float[] GetValues()
        {
            float[] Joy = new float[3];
            Joy[0] = X;
            Joy[1] = Y;
            Joy[2] = Z;
            return Joy;
        }

        /// <summary>
        /// Collects the JoyStick-Status and returns as them as <c>DTStacks.DataType.Generic.Geometry.Vector3</c>
        /// </summary>
        /// <returns> Returns Joystick values as a <c>DTStacks.DataType.Generic.Geometry.Vector3</c>.</returns>
        public Vector3 GetValuesAsVector3()
        {
            Vector3 Joy = new Vector3(X, Y, Z);
            return Joy;
        }
    }
}
