using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using DTStacks.DataType.Vehicles.Electrics;


namespace DTStacks.UnityComponents.Vehicles.Airplane
{
    
    public class MotorController : MonoBehaviour
    {
        private ElectroMotor motor;

        void Start()
        {
            motor = new ElectroMotor();
        }

    }
}
