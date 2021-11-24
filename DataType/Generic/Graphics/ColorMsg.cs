using DTStacks.DataType.Templates;
using System;

namespace DTStacks.DataType.Generic.Graphics
{
    [System.Serializable]
    public class ColorRGBA : Message
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public ColorRGBA(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        public ColorRGBA()
        {
            r = 255;
            g = 255;
            b = 255;
            a = 255;
        }
    }
}
