using UnityEngine;
using System.Collections;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.Home;


namespace DTStacks.UnityComponents.Home.Publisher
{
    public class SimpleLightPublisher : DTS_MQTTPubilsher
    {


        public SimpleLight Msg;
        public string GetData()
        {
            return Msg.CreateJSONFromData();
        }

        public override void InitPublishing()
        {
            base.InitPublishing();
            PublishMsg(GetData());
        }

        // Use this for extras during initialization
        public override void ExtendedStart()
        {

        }


        // Extended Update function, will be executed after regular update
        public override void ExtendedUpdate()
        {

        }
    }
}
