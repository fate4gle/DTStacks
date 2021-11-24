using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;

using DTStacks.Communication.MQTT;
namespace DTStacks.UnityComponents.Communication.MQTT
{
    public partial class DTS_MQTTPubilsher : MQTTPublisher
    {
        private List<string> eventMessages = new List<string>();
        private bool updateUI = false;
        public bool autoTest = false;

        [Tooltip("Establish countinous stream of data per defined amount of frames. If false, the publisher operates in One-Shot mode which needs to be triggered externally.")]
        public bool isUsingContinousUpdate = true;
        [Tooltip("Number of frames after which the next message is published")]
        public int updateFrames = 20;
        private int frameCounter = 0;



        public void TestPublish()
        {
            client.Publish(topic, System.Text.Encoding.UTF8.GetBytes("test message"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("Test message published");
        }
        public void PublishMsg(string s)
        {
            client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(s), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }

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

            if (autoTest)
            {
                TestPublish();
            }
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
            ExtendedStart();
        }

        public virtual void ExtendedStart()
        {

        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            string msg = System.Text.Encoding.UTF8.GetString(message);
            Debug.Log("Received: " + msg);
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

        private void StoreMessage(string eventMsg)
        {
            eventMessages.Add(eventMsg);
        }

        private void ProcessMessage(string msg)
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
            if (isUsingContinousUpdate)
            {
                frameCounter++;
                if (frameCounter >= updateFrames)
                {
                    frameCounter = 0;
                    InitPublishing();
                }
            }
            ExtendedUpdate();
        }
        public virtual void InitPublishing()
        {

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
