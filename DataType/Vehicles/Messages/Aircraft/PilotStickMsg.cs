
using DTStacks.DataType.Generic.Geometry;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Messages.Aircraft
{
    [System.Serializable]
    public class PilotStick : Message
    {
        public float pitch;
        public float roll;
        public float yaw;

        public PilotStick(float Pitch, float Roll, float Yaw)
        {
            pitch = Pitch;
            roll = Roll;
            yaw = Yaw;
        }

        /// <summary>
        /// Collects the JoyStick-Status and returns as them as a float[3] in X,Y,Z.
        /// </summary>
        /// <returns> Returns Joystick values as a float[3] in X,Y,Z.</returns>
        public float[] GetValues()
        {
            float[] Joy = new float[3];
            Joy[0] = pitch;
            Joy[1] = roll;
            Joy[2] = yaw;
            return Joy;
        }

        /// <summary>
        /// Collects the JoyStick-Status and returns as them as <c>DTStacks.DataType.Generic.Geometry.Vector3</c>
        /// </summary>
        /// <returns> Returns Joystick values as a <c>DTStacks.DataType.Generic.Geometry.Vector3</c>.</returns>
        public Vector3 GetValuesAsVector3()
        {
            Vector3 joy = new Vector3(pitch, roll, yaw);
            return joy;
        }
    }
}
