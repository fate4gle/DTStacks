using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DTStacks.UnityComponents.Communication.Templates
{
    public partial class Processor : MonoBehaviour
    {
        public virtual void GetDataFromActutor() { }
        public virtual void ProcessMessage() { }
        public virtual void SendDataToActuator() { }

    }
}
