﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using DTStacks.DataType.Vehicles.Messages.Aircraft;

namespace DTStacks.UnityComponents.Vehicles.Airplane
{
    public class FlapController : MonoBehaviour
    {
        public GameObject pivotPointL, pivotPointR;
        public Vector3 pivotAxisL, pivotAxisR;
        private Vector3 _deflectionL, _deflectionR;
        private float deflection;

        public ControllSurfaceMsg controllSurface;

        void Start()
        {
            if (pivotPointL == null)
            {
                pivotPointL = this.gameObject;
            }
            if (pivotAxisL == null)
            {
                pivotAxisL = new Vector3(0, 0, 1);
            }
            if (pivotPointR == null)
            {
                pivotPointR = this.gameObject;
            }
            if (pivotAxisR == null)
            {
                pivotAxisR = new Vector3(0, 0, 1);
            }
        }
        public void ApplyDeflection(ControllSurfaceMsg con)
        {
            controllSurface.genDeflection = con.aileron;
            deflection = con.rudder;
            _deflectionL = pivotAxisL * con.aileron;
            _deflectionR = pivotAxisR * con.flaps;
            pivotPointL.transform.localRotation = Quaternion.Euler(_deflectionL);
            pivotPointR.transform.localRotation = Quaternion.Euler(_deflectionL);
        }
        public void ApplyDeflection(float f)
        {
            controllSurface.genDeflection = f;
            deflection = f;
            _deflectionL = pivotAxisL * f;
            _deflectionR = pivotAxisR * f;
            pivotPointL.transform.localRotation = Quaternion.Euler(_deflectionL);
            pivotPointR.transform.localRotation = Quaternion.Euler(_deflectionR);
        }
        public void UpdateDeflection()
        {
            ApplyDeflection(controllSurface.genDeflection);
        }
        public float GetDeflection()
        {
            float f = controllSurface.genDeflection;
            //float f = Vector3.Scale(_deflection, pivotAxis).magnitude;

            return f;
        }
    }
}
