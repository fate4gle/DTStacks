using UnityEngine;
using System.Collections;

using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.Machines;


namespace DTStacks.UnityComponents.Machines.Publisher
{
    public class CNC4AxisToolPublisher : DTS_MQTTPubilsher
    {


        public CNC4AxisTool Msg;
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
