using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Helpers
{
    [System.Serializable]
    public class Stamp : Message
    {
        public string label;
        public int size;
        public int index;
    }
}
