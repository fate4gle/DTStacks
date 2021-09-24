using System;
using UnityEngine;

using DTStacks.DataType.Services;
using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Templates.Vehicles
{
    [Serializable]
    public class Motor : Message
    {
        public Header header;

        public string motorType;
        public float rpm;
        public float torgue;
        public float temperature;
        public float maxTemp;
        public float minTemp;
        public float coolingLiquidTemperatur;
        public float curTorgue;
        public float maxTorgue;


        public bool isEnabled;
        public bool isOperting;
        public string[] dataPackages;

        public virtual void FeedData(string data)
        {
            string[] s = data.Split(header.headerDelim);
            string[] sd;
            if (s.Length > 1)
            {
                string[] sh = s[0].Split(header.delim);
                sd = s[1].Split(header.delim);
                header.FeedData(sh[0] + header.delim + sh[1] + header.delim + sh[2]);
            }
            else
            {
                sd = s[0].Split(header.delim);
            }

            dataPackages = new string[sd.Length];
            dataPackages = sd;
        }
    }
}
