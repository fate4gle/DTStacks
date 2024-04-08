using DTStacks.DataType.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DTStacks.UnityComponents.Communication.Templates
{
    public partial class Actutor : MonoBehaviour
    {
        public virtual void FeedData() { }
        public virtual void GetData() { }
        public virtual void Actuate() { }

    }
}
