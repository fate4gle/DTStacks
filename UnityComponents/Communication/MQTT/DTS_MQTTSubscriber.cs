using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using uPLibrary.Networking.M2Mqtt.Messages;

using DTStacks.Communication.MQTT;

namespace DTStacks.UnityComponents.Communication.MQTT
{
    public partial class DTS_MQTTSubscriber : MQTTSubscriber
    {
        private List<string> eventMessages = new List<string>();
        private bool updateUI = false;
        public bool autoTest = false;



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
        }

        protected override void OnConnectionLost()
        {
            Debug.Log("CONNECTION LOST!");
        }




        protected override void Start()
        {
            base.Start();
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            try
            {

                string msg = System.Text.Encoding.UTF8.GetString(message);
                //Debug.Log("Received: " + msg);
                StoreMessage(msg);
                if (topic == topic)
                {
                    if (autoTest)
                    {
                        autoTest = false;
                        Disconnect();
                    }
                }
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }

        private void StoreMessage(string eventMsg)
        {
            eventMessages.Add(eventMsg);
        }

        public virtual void ProcessMessage(string msg)
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
        }

        private void OnValidate()
        {
            if (autoTest)
            {
                autoConnect = true;
            }
        }
    }
}
