using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using DTStacks.DataType.Vehicles.Messages.Electrics;

namespace DTStacks.DataType.Vehicles.Electrics
{
    public class ElectroMotor : DTStacks.DataType.Templates.Vehicles.Motor 
    {
        public float curPower;
        public float maxPower;
        public float minVoltage;
        public float curVoltage;
        public float maxVoltage;
        public float curCurrent;
        public float maxCurrent;

        public bool isEMFenabled;
    }    
}
