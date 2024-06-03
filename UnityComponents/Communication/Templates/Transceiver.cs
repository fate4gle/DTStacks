using DTStacks.DataType.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace DTStacks.UnityComponents.Communication.Templates
{
    public partial class Transceiver : MonoBehaviour
    {
        [Tooltip("Event triggered when new data is received")]
        public UnityEvent MessageReceived;
        public virtual void Start()
        {
            if(MessageReceived == null) MessageReceived = new UnityEvent();
            
        }
        public virtual void OnDataReceived(string message) { }
        public new virtual void SendMessage(string message) { }
        public virtual void ProcessMessage(string message) { }
    }
}
