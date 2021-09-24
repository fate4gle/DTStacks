using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Helpers;

namespace DTStacks.DataType.Generic.Navigation
{
    [System.Serializable]
    public class PoseStamped : Message
    {
        public Stamp stamp;
        public Pose pose;
    }
}
