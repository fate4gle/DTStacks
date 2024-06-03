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
        public bool autoTest = false;

        [Tooltip("Establish countinous stream of data per defined amount of frames. If false, the publisher operates in One-Shot mode which needs to be triggered externally.")]
        public bool isUsingContinousUpdate = true;
        [Tooltip("Number of frames after which the next message is published")]
        public int updateFrames = 20;
        private int frameCounter = 0;
        private bool isConnected;



        public void TestPublish()
        {
            client.Publish(topic, System.Text.Encoding.UTF8.GetBytes("test message"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("Test message published");
        }
        public void PublishMsg(string s)
        {
            if (client.ClientId != null)
            {
                client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(s), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }
            //client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(s), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

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
            isConnected = true;

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
            isConnected = false;
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

            if (autoTest)
            {
                autoTest = false;
                Disconnect();
            }
            /* EntryPoint if used for multiple topics to publish to...
            if (topic == listOfTopic) 
            {
                if (autoTest)
                {
                    autoTest = false;
                    Disconnect();
                }
            }
            */
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
            if (isUsingContinousUpdate && isConnected)
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
        public override void OnApplicationQuit()
        {
            base.OnApplicationQuit();
        }
    }
}
