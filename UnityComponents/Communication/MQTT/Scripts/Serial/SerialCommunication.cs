using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


#if !WINDOWS_UWP
using System.IO;
using System.IO.Ports;
#endif


namespace DTStacks.Communication.Serial
{
    public partial class SerialCommunication : MonoBehaviour
    {
        public SerialPort serialPort;
        public string portName = "COM1";
        public int baudRate = 9600;
        public Parity parity = Parity.None;
        
        /// <summary>
        /// Configuration of the SerialPort.
        /// </summary>
        /// <param name="portName">Name of the SerialPort e.g. "COM1"</param>
        /// <param name="baudRate">The baudrate of the Serialport e.g.9600</param>
        /// <param name="parity">The Parity to be used by the SerialConnection</param>
        public void ConfigurateSerialPort(string portName, int baudRate, Parity parity)
        {
            this.portName = portName;
            this.baudRate = baudRate;
            this.parity= parity;
        }
        /// <summary>
        /// Starts the SerialCommunication, if not configured before, uses the default settings of "COM1", baudrate of 9600 and no parity.
        /// </summary>
        public void StartSerial()
        {
            serialPort = new SerialPort(portName);
            serialPort.BaudRate = baudRate;
            serialPort.Parity = parity;
            serialPort.Open();
            serialPort.DataReceived += new SerialDataReceivedEventHandler( OnMessageReceived);
        }
        /// <summary>
        /// Event called when new data is received. If the encoding is successfull, the message will be forwarded to the ProcessMessage()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMessageReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buf = new byte[serialPort.BytesToRead];
            serialPort.Read(buf, 0, buf.Length);
            string message = Encoding.UTF8.GetString(buf);
            if (!string.IsNullOrEmpty(message)) { ProcessMessage(message); }
        }
        public virtual void ProcessMessage(string message)
        {

        }
        /// <summary>
        /// Publishes the message after encoding it to UTF8.
        /// </summary>
        /// <param name="message"></param>
        public void PublishMsg(string message)
        {
            byte[] buf = Encoding.UTF8.GetBytes(message);
            serialPort.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// Stops the SerialCommunication
        /// </summary>
        public void StopSerial()
        {
            serialPort.Close();
        }

    }

}
