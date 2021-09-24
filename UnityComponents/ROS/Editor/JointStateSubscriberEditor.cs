using UnityEditor;
using UnityEngine;
using DTStacks.UnityComponents.ROS.Subscriber;

namespace DTStacks.UnityComponents.ROS.Editor
{
    [CustomEditor(typeof(JointStateSubscriber))]
    public class JointStateSubscriberEditor : UnityEditor.Editor
    {
        private JointStateSubscriber jointStateSubscriber;
        private static GUIStyle buttonStyle;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This is the central point of your incoming robot communication. " +
                "Enter the details of your mqtt broker, the topic to subscribe to and specify the robotParent object. " +
                "Either presss play and see if your robotcontrollers are in the correct order, press on 'Find Joints and configure' or manually specificy the order.", MessageType.Info);

            DrawDefaultInspector();
            if (buttonStyle == null) buttonStyle = new GUIStyle(EditorStyles.miniButtonRight) { fixedWidth = 75 };

            jointStateSubscriber = (JointStateSubscriber)target;

            if (GUILayout.Button("Find joints in robot and configure"))
            {
                jointStateSubscriber.FindJoints();
            }
        }

    }
}
