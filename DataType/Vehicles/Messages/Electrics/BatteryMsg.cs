using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Messages.Electrics
{
    [System.Serializable]
    public class BatteryCell : Message
    {
        public string name;
        public string label;
        public float charge; //In %
        public float curCurrent;
        public float maxCurrent;

        public float onTime;
        public bool isEnabled;
        public bool isOperating;

        public float curVoltage;
        public float maxVoltage;
        public float minVoltage;

        public float curPower;
        public float maxPower;

        public float Temperature; // in Celsius
    }
}
