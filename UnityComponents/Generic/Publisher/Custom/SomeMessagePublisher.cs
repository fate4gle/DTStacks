using UnityEngine;
using System.Collections;
 
using DTStacks.UnityComponents.Communication.MQTT;
using DTStacks.DataType.Generic.Custom;


namespace DTStacks.UnityComponents.Generic.Publisher.Custom
{
public class SomeMessagePublisher : DTS_MQTTPubilsher {
 
 
public SomeMessage Msg;
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
 public override void ExtendedStart () {

}
 

 // Extended Update function, will be executed after regular update
 public override void ExtendedUpdate () {

}
}
}
