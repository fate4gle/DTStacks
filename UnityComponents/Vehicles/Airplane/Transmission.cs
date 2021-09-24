using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace DTStacks.UnityComponents.Vehicles.Airplane
{
    public class Transmission : MonoBehaviour
    {
        [Tooltip ("PropellerRPM/EngineRPM")]
        public float transmissionRatio = 10;

        [SerializeField]
        private PropellerWriter propeller;

        [SerializeField]
        private float engineRPM;

        [SerializeField]
        private float propellerRPM;

        void Start()
        {
            if(propeller = null)
            {
                propeller = this.GetComponentInChildren<PropellerWriter>();
            }
        }

        public void SetRPM(float _engineRPM)
        {
            engineRPM = _engineRPM;
            propellerRPM = engineRPM * transmissionRatio;
            propeller.rpm = propellerRPM;
        }

    }
}
