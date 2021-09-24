using UnityEditor;
using UnityEngine;
using DTStacks.UnityComponents.ROS.Publisher;

namespace DTStacks.UnityComponents.ROS.Editor
{
    [CustomEditor(typeof(JointStatePublisher))]
    public class JointStatePublisherEditor : UnityEditor.Editor
    {

        private JointStatePublisher jointStatePublisher;
        private static GUIStyle buttonStyle;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This is the central point of your outgoing robot communication. " +
                "Enter the details of your mqtt broker, the topic to publish to, set your target update rate as in 'every X frames' and specify the robotParent object. " +
                "Either presss play and see if your robotcontrollers are in the correct order, press on 'Find Joints and configure' or manually specificy the order.", MessageType.Info);

            DrawDefaultInspector();
            if (buttonStyle == null) buttonStyle = new GUIStyle(EditorStyles.miniButtonRight) { fixedWidth = 75 };

            jointStatePublisher = (JointStatePublisher)target;

            if (GUILayout.Button("Find joints in robot and configure"))
            {
                jointStatePublisher.FindJoints();
            }
        }

    }
}
