using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace DTStacks.UnityComponents.Vehicles.Automobile.Auxillary
{
    public class TurnSignal : MonoBehaviour
    {
        IEnumerator signalRoutinne;
        Light light;
        bool isBlinking = false;
        bool isBright = false;
        float defaultInterval;

        private IEnumerator Blinking(float blinkInterval)
        {
            isBlinking = true;
            while (isBlinking)
            {
                isBright = !isBright;
                LightController(isBright);
                new WaitForSeconds(blinkInterval);
            }
            yield return null;
        }
        private IEnumerator Blinking()
        {
            isBlinking = true;
            while (isBlinking)
            {
                isBright = !isBright;
                LightController(isBright);
                new WaitForSeconds(defaultInterval);
            }
            yield return null;
        }


        void LightController(bool b)
        {
            light.enabled = b;
        }

        public void StartBlinking()
        {
            signalRoutinne = Blinking();
        }
        public void StartBlinking(float blinkInterval)
        {
            signalRoutinne = Blinking(blinkInterval);
        }
        public void StopBlinking()
        {
            isBlinking = false;
            isBright = false;
        }
    }
}
