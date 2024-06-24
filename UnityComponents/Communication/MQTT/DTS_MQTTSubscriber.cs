using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using uPLibrary.Networking.M2Mqtt.Messages;

using DTStacks.Communication.MQTT;
using System.Collections;
using System.Diagnostics;

namespace DTStacks.UnityComponents.Communication.MQTT
{
    public partial class DTS_MQTTSubscriber : MQTTSubscriber
    {
        private List<string> eventMessages = new List<string>();
        public bool autoTest = false;
        private bool isConnected = false;
        private bool isPostAwake = false;

        public void SetBrokerAddress(string brokerAddress)
        {
            this.brokerAddress = brokerAddress;
        }

        public void SetBrokerPort(string brokerPort)
        {
            int.TryParse(brokerPort, out this.brokerPort);

        }

        public void SetEncrypted(bool isEncrypted)
        {
            this.isEncrypted = isEncrypted;
        }

        protected override void OnConnecting()
        {
            base.OnConnecting();
        }

        protected override void OnConnected()
        {
            base.OnConnected();
            isConnected = true;
            Debug.Log("MQTT Connected");

        }

        protected override void SubscribeTopics()
        {
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        protected override void UnsubscribeTopics()
        {
            client.Unsubscribe(new string[] { topic });
        }

        protected override void OnConnectionFailed(string errorMessage)
        {
            Debug.Log("CONNECTION FAILED! " + errorMessage);
        }

        protected override void OnDisconnected()
        {
            Debug.Log("Disconnected.");
            isConnected = false;
        }

        protected override void OnConnectionLost()
        {
            Debug.Log("CONNECTION LOST!");
            isConnected = false;
        }




        public override void Start()
        {
            base.Start();
            isPostAwake = true;
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            try
            {

                string msg = System.Text.Encoding.UTF8.GetString(message);
                //Debug.Log("Received: " + msg);
                StoreMessage(msg);
                /* If multiple topics shall be subrscibed to 
                if (topic == topic)
                {
                    if (autoTest)
                    {
                        autoTest = false;
                        Disconnect();
                    }
                }
                */

                if (autoTest)
                {
                    autoTest = false;
                    Disconnect();
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        private void StoreMessage(string eventMsg)
        {
            eventMessages.Add(eventMsg);
        }

        public override void ProcessMessage(string msg)
        {

        }

        protected override void Update()
        {
            base.Update(); // call ProcessMqttEvents()

            if (eventMessages.Count > 0)
            {
                foreach (string msg in eventMessages)
                {
                    ProcessMessage(msg);
                }
                eventMessages.Clear();
            }
            ExtendedUpdate();
        }
        public virtual void ExtendedUpdate()
        {

        }

        private void OnDestroy()
        {
            Disconnect();
            isConnected = false;
        }

        private void OnValidate()
        {
            if (autoTest)
            {
                autoConnect = true;
            }
        }
        private void OnApplicationPause(bool pause)
        {
            Debug.Log("Application is" + pause);
            if (pause && isPostAwake) { Disconnect(); }
            if (!pause && isPostAwake) { StartCoroutine(Reconnect()); Debug.Log("Connecting again"); }

        }
        IEnumerator Reconnect()
        {
            yield return new WaitForSeconds(1);
            if (isConnected) { Disconnect(); yield return new WaitForSeconds(1); }

            Debug.Log("Connecting again");
            Connect();
        }
    }
}
