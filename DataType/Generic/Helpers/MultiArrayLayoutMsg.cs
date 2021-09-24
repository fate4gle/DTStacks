using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Helpers
{
    [System.Serializable]
    public class MultiArrayLayout : Message
    {
        public MultiArrayDimension[] dim;
    }
}
