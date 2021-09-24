using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DTStacks.UnityComponents.Vehicles.Airplane
{
    public class PropellerWriter: MonoBehaviour
    {
        public GameObject[] propellerBladesPivot;
        public Vector3 propellerBladesPivotAxis;
        public GameObject propellerPivot;

        public float rpm;
        private float _rpmSpeed;
        private float propellerBladesAngle;
        public bool isEnabled = false;
        

        void Start()
        {
            if ( propellerPivot == null)
            {
                propellerPivot = this.gameObject;
            }

            if( propellerBladesPivot == null)
            {
                propellerBladesPivot = new GameObject[this.transform.childCount];
                for (int i = 0; i< propellerBladesPivot.Length; i++)
                {
                    propellerBladesPivot[i] = this.transform.GetChild(i).gameObject;
                }
            }
            if(propellerBladesPivotAxis == null)
            {
                propellerBladesPivotAxis = new Vector3(0, 0, 1);
            }
        }

        void Update()
        {

        }

        public void SetBladeAngle(float f)
        {
            propellerBladesAngle = f;
            Vector3 pivot = propellerBladesPivotAxis * f;
            foreach(GameObject go in propellerBladesPivot)
            {
                go.transform.localRotation = Quaternion.Euler(pivot);
            }
        }
    }
}
