using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Math
{
    [System.Serializable]
    public class Matrix3x3 : Message
    {        
        public float[,] matrix = new float[,] {  
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},};
    }    
}
