using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using DTStacks.DataType.Vehicles.Combustion;

namespace DTStacks.UnityComponents.Vehicles.Automobile
{
    public class AutomobileManager : MonoBehaviour
    {
        public SimpleEngine engine;

        public float velocity;
        public bool isSignalingTurn;
        public bool isRightSide;
        public bool isTurningRight;
        public bool isTurningLeft;

        void Start()
        {
            if(engine == null) { engine = gameObject.GetComponentInChildren<SimpleEngine>(); }
        }

    }
}
