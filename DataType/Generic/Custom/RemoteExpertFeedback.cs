using System;
using UnityEngine;
using DTStacks.DataType.Templates;
using DTStacks.DataType.Generic.Geometry;

using DTStacks.DataType.Generic.Helpers;
using DTStacks.DataType.Generic.Math;
using DTStacks.DataType.Generic.Navigation;
using DTStacks.DataType.Generic.Graphics;

namespace DTStacks.DataType.Generic.Custom
{
    [Serializable]
    public class RemoteExpertFeedback : Message
    {
        public bool isNewObject;
        public bool isDelete;
        public bool isDeleteLatest;
        public bool isDeleteOldest;
        public string objectType;
        public UnityEngine.Vector3 position;
        public UnityEngine.Vector3 scalingFactor;
        public ColorRGBA color;


        public RemoteExpertFeedback()
        {
            isNewObject = false;
            isDelete = false;
            isDeleteLatest = false;
            isDeleteOldest = false;
        }
    }
}
