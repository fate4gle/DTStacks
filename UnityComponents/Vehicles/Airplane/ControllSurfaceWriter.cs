using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


using DTStacks.DataType.Vehicles.Messages.Aircraft;
namespace DTStacks.UnityComponents.Vehicles.Aircraft
{
    public class ControllSurfaceWriter: MonoBehaviour
    {
        public GameObject pivotPoint;
        public Vector3 pivotAxis;
        private Vector3 _deflection;
        private float deflection;

        public ControllSurfaceMsg controllSurface;

        void Start()
        {
            if(pivotPoint == null)
            {
                pivotPoint = this.gameObject;
            }
            if (pivotAxis == null)
            {
                pivotAxis = new Vector3(0, 0, 1);
            }
            ;
        }
        public void ApplyDeflection(float f)
        {
            controllSurface.genDeflection = f;
            deflection = f;            
            _deflection = pivotAxis * f;
            pivotPoint.transform.localRotation = Quaternion.Euler(_deflection);            
        }
        public void UpdateDeflection()
        {
            ApplyDeflection(controllSurface.genDeflection);
        }
        public float GetDeflection()
        {
            float f = Vector3.Scale(_deflection, pivotAxis).magnitude;
            return f;
        }
    }
}
