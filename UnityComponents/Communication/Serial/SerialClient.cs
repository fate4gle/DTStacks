using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTStacks.Communication.Serial;
using UnityEngine;

namespace DTStacks.UnityComponents.Communication.Serial
{
    /// <summary>
    /// SerialClient to be used as a transceiving module
    /// </summary>
    public class SerialClient : SerialCommunication
    {

        /// <summary>
        /// Method to define what happens when Data is received and preprocessed to a string
        /// </summary>
        /// <param name="message"> the received message as a string</param>
        public override void ProcessMessage(string message)
        {
            
        }

    }
}
