using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace DTStacks.UnityComponents.Vehicles.Automobile.Auxillary
{
    public class TurnSignalController : MonoBehaviour
    {
        TurnSignal rightSignal;
        TurnSignal leftSignal;
                
        public void StartTurnSignal()
        {
            rightSignal.StartBlinking();
            leftSignal.StartBlinking();
        }
        public void StartTurnSignal(float interval)
        {
            rightSignal.StartBlinking(interval);
            leftSignal.StartBlinking(interval);
        }
        public void StartTurnSignal(bool isRight)
        {
            if (isRight)
            {
                rightSignal.StartBlinking();
            }
            else
            {
                leftSignal.StartBlinking();
            }
        }

        public void StartTurnSignal(bool isRight, float interval)
        {
            if (isRight)
            {
                rightSignal.StartBlinking(interval);
            }
            else
            {
                leftSignal.StartBlinking(interval);
            }
        }
        
        public void StopTurnSignal(bool isRight)
        {
            if (isRight)
            {
                rightSignal.StopBlinking();
            }
            else
            {
                leftSignal.StopBlinking();
            }
        }
        public void StopTurnSignal()
        {
            rightSignal.StopBlinking();
            leftSignal.StopBlinking();            
        }
    }
}
