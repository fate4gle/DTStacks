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

        public Motor()
        {

        }
    }
}
