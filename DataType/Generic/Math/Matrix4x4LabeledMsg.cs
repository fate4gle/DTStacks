using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Math
{
    [System.Serializable]
    public class Matrix4x4Labeled : Message
    {
        public string[,] label = new string[,]
        {
            { "0,0", "0,1", "0,2", "0,3" },
            { "1,0", "1,1", "1,2", "1,3" },
            { "2,0", "2,1", "2,2", "2,3" },
            { "3,0", "3,1", "3,2", "3,3" },
        };
        public float[,] matrix = new float[,] {  
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16},};
    }    
}
