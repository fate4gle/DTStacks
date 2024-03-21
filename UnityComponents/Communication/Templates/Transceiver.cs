using DTStacks.DataType.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DTStacks.UnityComponents.Communication.Templates
{
    public partial class Transceiver : MonoBehaviour
    {
        public virtual void OnDataReceived(string message) { }
        public virtual void SendMessage(string message) { }
        public virtual void ProcessMessage(string message) { }
    }
}
