using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
namespace DTStacks.UnityComponents.ROS.Helpers
{
    public class RobotManager : MonoBehaviour
    {
        public string robotName;
        public string type;
        public enum RobotType {Manipulator, AGV, Other };
        public RobotType robotType;

#if robotType == Manipulator
        public int nJoints;
#elif robotType == AGV
        public int nWheels;
#endif

    }
}
