using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace DTStacks.Editor.Generator
{
    public class MessageGenerator : EditorWindow
    {
        string msgName = "GenericMessage";
        string msgNamespace = "DTStacks.DataType.Generic.Custom";

        bool isROSMsg = true;
        bool includeDTStackType = true;
        bool isDTStacksPriority = false;
        bool isCreatePublisher = false;
        bool isCreateSubscriber = false;
        string generateBtn = "Generate Message";




        public MessageElement[] messageElements;
        private SerializedObject serializedObject;
        private SerializedProperty serializedProperty;

        // Add menu named "My Window" to the Window menu
        [MenuItem("DTStacks/Create/Messages")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            MessageGenerator window = (MessageGenerator)EditorWindow.GetWindow(typeof(MessageGenerator));
            window.Show();
        }


        void OnGUI()
        {
            GUILayout.Label("Message Generator", EditorStyles.boldLabel);
            msgName = EditorGUILayout.TextField("Message Name", msgName);
            msgNamespace = EditorGUILayout.TextField("Message Namespace", msgNamespace);

            EditorGUILayout.BeginHorizontal();
            ScriptableObject target = this;
            serializedObject = new SerializedObject(target);
            serializedObject.Update();
            serializedProperty = serializedObject.FindProperty("messageElements");
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndHorizontal();


            isROSMsg = EditorGUILayout.Toggle("Include ROS dependencies", isROSMsg);
            includeDTStackType = EditorGUILayout.BeginToggleGroup("Include DTStacks message namespaces", includeDTStackType);
            isDTStacksPriority = EditorGUILayout.Toggle("Prioritize DTStacks for Geometry", isDTStacksPriority);
            EditorGUILayout.EndToggleGroup();

            isCreatePublisher = EditorGUILayout.Toggle("Create Publisher", isCreatePublisher);
            isCreateSubscriber = EditorGUILayout.Toggle("Create Subscriber", isCreateSubscriber);




            if (GUILayout.Button(generateBtn))
            {
                Create();
                if (isCreatePublisher)
                {
                    PublisherGenerator pub = new PublisherGenerator();
                    pub.Create(msgName + "Publisher", "DTStacks.UnityComponents.Generic.Publisher.Custom", msgName, msgNamespace);
                }
                if (isCreateSubscriber)
                {
                    SubscriberGenerator sub = new SubscriberGenerator();
                    sub.Create(msgName + "Subscriber", "DTStacks.UnityComponents.Generic.Subscriber.Custom", msgName, msgNamespace);
                }
            }

            void Create()
            {
                string copyPath = "Assets/DTStacks/DataType/Generic/Custom/" + msgName + ".cs";
                Debug.Log("Creating Message class-file: " + copyPath);

                if (File.Exists(copyPath) == false)
                {
                    // do not overwrite
                    using (StreamWriter outfile =
                        new StreamWriter(copyPath))
                    {
                        #region includeNamespaces
                        outfile.WriteLine(  "using System; \r\n"+
                                            "using UnityEngine; \r\n " +
                                            "using DTStacks.DataType.Templates; \r\n " +
                                            "using DTStacks.DataType.Generic.Geometry; \r\n" );
                        if (includeDTStackType)
                        {
                            outfile.WriteLine(                                                
                                                "using DTStacks.DataType.Generic.Helpers; \r\n " +
                                                "using DTStacks.DataType.Generic.Math; \r\n " +
                                                "using DTStacks.DataType.Generic.Navigation;  \r\n "
                                                );
                        }
                        if (isROSMsg)
                        {
                            outfile.WriteLine(
                                                "using DTStacks.DataType.ROS.Messages.std_msgs; \r\n " +
                                                "using DTStacks.DataType.ROS.Messages.nav_msgs; \r\n " +
                                                "using DTStacks.DataType.ROS.Messages.geometry_msgs; \r\n " +
                                                "using DTStacks.DataType.ROS.Messages.sensor_msgs;  \r\n "
                                                );
                        }
                        #endregion

                        #region Write Class Content
                        
                        outfile.WriteLine(
                                             "namespace " + msgNamespace + "\r\n " +
                                             "{ \r\n  " +
                                             "  [Serializable] \r\n  " +
                                             "  public class " + msgName + " : Message \r\n  { \r\n  ");

                        for (int i = 0; i < messageElements.Length; i++)
                        {
                            if (isDTStacksPriority && includeDTStackType)
                            {
                                if (messageElements[i].messageType == MessageType.Quaternion || messageElements[i].messageType == MessageType.Vector3)
                                {
                                    outfile.WriteLine("         public  DTStacks.DataType.Generic.Geometry." + messageElements[i].messageType.ToString() + " " + messageElements[i].name + ";");
                                }
                                else
                                {
                                    outfile.WriteLine("         public  " + messageElements[i].messageType.ToString() + " " + messageElements[i].name + ";");
                                }
                            }
                            else
                            {
                                if (messageElements[i].messageType == MessageType.Quaternion || messageElements[i].messageType == MessageType.Vector3)
                                {
                                    outfile.WriteLine("         public  UnityEngine." + messageElements[i].messageType.ToString() + " " + messageElements[i].name + ";");
                                }
                                else
                                {
                                    outfile.WriteLine("         public  " + messageElements[i].messageType.ToString() + " " + messageElements[i].name + ";");
                                }
                            }
                        }
                        #endregion
                        
                        outfile.WriteLine(" ");
                        outfile.WriteLine(" ");
                        
                        //Constructor
                        outfile.WriteLine("         public " + msgName+"(){}");

                        outfile.WriteLine("     }");
                        outfile.WriteLine("}");
                    }
                }
                AssetDatabase.Refresh();
            }
        }


        [System.Serializable]
        public class MessageElement
        {
            public string name;
            public MessageType messageType;
        }
        public enum MessageType
        {
            Header,
            @int,
            Int32MultiArray,
            MultiArrayDimension,
            MultiArrayLayout,
            @float,
            @string,
            @bool,
            Time,
            Accel,
            AccelStamped,
            AccelWithCovariance,
            AccelWithCovarianceStamped,
            Point,
            PointStamped,
            Pose,
            PoseWithCovariance,
            Quaternion,
            msgTwist,
            TwistWithCovariance,
            Vector3,
            //CompressedImage,
            //Image,
            JointStateMsg,
            JoyMsg,
            //LaserScan,
            //PointCloud2,
            //PointField,
            Odometry,
            MapMetaData,
            //OccupancyGrid,
            GoalID,
            GoalStatus,
            GoalStatusArray,
            DiagnosticStatus,
            DiagnosticArray,
            KeyValue
        };
    }


}
