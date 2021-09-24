using DTStacks.DataType.Templates;
using DTStacks.DataType.ROS.Messages.std_msgs;

namespace DTStacks.DataType.ROS.Messages.sensor_msgs
{
    [System.Serializable]
    public class Joy : Message
    {
        public Header header;
        public float[] axes;
        int[] buttons;

        /// <summary>
        /// Sets the amount of individual axes in the message
        /// </summary>
        /// <param name="nAxes"></param>
        public void SetNumberOfAxis(int nAxes)
        {
            axes = new float[nAxes];
        }
        /// <summary>
        /// Sets the amount of individual Buttons in the message
        /// </summary>
        /// <param name="nButtons"></param>
        public void SetNumberOfButtons(int nButtons)
        {
            buttons = new int[nButtons];
        }
    }
}
