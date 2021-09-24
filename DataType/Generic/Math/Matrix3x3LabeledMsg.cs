using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Math
{
    [System.Serializable]
    public class Matrix3x3Labeled : Message 
    {
        public string[,] label = new string[,]
        {
            { "0,0", "0,1", "0,2" },
            { "1,0", "1,1", "1,2" },
            { "2,0", "2,1", "2,2" },
        };
        public float[,] matrix = new float[,] {  
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},};
    }    
}
