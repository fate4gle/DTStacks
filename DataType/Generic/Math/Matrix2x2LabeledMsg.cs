using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Math
{
    [System.Serializable]
    public class Matrix2x2Labeled : Message
    {
        public string[,] label = new string[,]
        {
            { "0,0", "0,1" },
            { "1,0", "1,1"}, 
        };
        public float[,] matrix = new float[,] 
        {  
            {1, 2},
            {3, 4},
        };
    }    
}
