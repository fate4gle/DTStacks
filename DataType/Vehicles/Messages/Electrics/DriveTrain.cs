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


        
        public override void FeedData(string data)
        {
            
            string[] s  = data.Split(header.headerDelim);
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

            base.FeedData(data);
        }
    }    
}
