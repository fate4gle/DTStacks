using System;
using UnityEngine;
using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;
using DTStacks.DataType.Generic.Helpers;
using DTStacks.DataType.Generic.Math;
using DTStacks.DataType.Generic.Navigation;

namespace DTStacks.DataType.Machines
{
    [Serializable]
    public class CNC3AxisTool : Message
    {

        public float xPosition;
        public float yPosition;
        public float zPosition;
        public float toolRPM;
    }
}
