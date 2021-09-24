using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Math
{
    [System.Serializable]
    public class Matrix2x2 : Message
    {        
        public float[,] matrix = new float[,] {  
            {1, 2},
            {3, 4},};
    }    
}
