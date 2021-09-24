using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTStacks.DataType.Templates;

namespace DTStacks.DataType.Vehicles.Messages.Electrics
{
    [Serializable]
    public class BatterySystem : Message
    {
        public int nBatCell;
        public BatteryCell[] batCells = new BatteryCell[4];

        public float curPower;
        public float maxPower;

        public float minVoltage;
        public float curVoltage;
        public float maxVoltage;

        public float curCurrent;
        public float maxCurrent;


        /// <summary>
        /// Calculate absolute performance paramters based on all known cells
        /// </summary>
        public void AbsPerformanceBasedOnCells()
        {
            int k = batCells.Length;
            nBatCell = k;
            for (int i = 0; i < k; k++)
            {
                curCurrent += batCells[i].curCurrent;
                curVoltage += batCells[i].curVoltage;
                curPower += batCells[i].curPower;
            }
        }
        /// <summary>
        /// Get The performance based on the latest available data as a float[3] across all known batteries
        /// </summary>
        /// <returns>
        /// the momentary Voltage, Current and Power
        /// </returns>
        public float[] GetLatestPerformance()
        {
            AbsPerformanceBasedOnCells();
            float[] f = new float[3];
            f[0] = curVoltage;
            f[1] = curCurrent;
            f[2] = curPower;
            return f;
        }

        /// <summary>
        /// Reset all parameters
        /// </summary>
        public void ResetData()
        {
            float[] a = new float[3];
            curPower = 0;
            curVoltage = 0;
            curCurrent = 0;
        }
    }
}
