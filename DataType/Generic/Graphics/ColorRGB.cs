using System;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Generic.Graphics
{
    [System.Serializable]
    public class ColorRGB: Message
    {
        public int r;
        public int g;
        public int b;

        public ColorRGB(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public ColorRGB()
        {
            r = 255;
            g = 255;
            b = 255;
        }
    }
}
