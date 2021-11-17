using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

namespace DTStacks.Editor.Generator
{

    public class SubscriberGenerator : EditorWindow
    {

        string subscriberName = "GenericSubscriber";
        string subscriberNamespace = "DTStacks.UnityComponents.Generic.Subscriber.Custom";
        string messageName = "GenericMessage";
        bool includeMsg = true;
        
        string generateBtn = "Generate Subscriber";


        [MenuItem("DTStacks/Create/Subscriber")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            SubscriberGenerator window = (SubscriberGenerator)EditorWindow.GetWindow(typeof(SubscriberGenerator));
            window.Show();
        }

        public void Create(string subscriberName, string subscriberNamespace, string messageName, string messageNamespace)
        {
            string copyPath = "Assets/DTStacks/UnityComponents/Generic/Subscriber/Custom/" + subscriberName + ".cs";
            Debug.Log("Creating Subscriber Classfile: " + copyPath);

            if (File.Exists(copyPath) == false)
            {
                // do not overwrite
                using (StreamWriter outfile =
                    new StreamWriter(copyPath))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("using System.Collections;");
                    outfile.WriteLine(" ");
                    outfile.WriteLine("using DTStacks.UnityComponents.Communication.MQTT;\r\n" +
                        "using " + messageNamespace+ "; \r\n");
                    outfile.WriteLine("");
                    outfile.WriteLine("namespace " + subscriberNamespace);
                    outfile.WriteLine("{");
                    outfile.WriteLine("public class " + subscriberName + " : DTS_MQTTSubscriber {");
                    outfile.WriteLine("public " + messageName + " Msg;");


                    outfile.WriteLine("public void FeedData(string s) \r\n" +
                        "{ \r\n" +
                        "  Msg.FeedDataFromJSON(s); \r\n" +
                        "} \r\n");

                    outfile.WriteLine(" public override void ProcessMessage(string msg)\r\n" +
                                    "{\r\n" +
                                    "FeedData(msg);\r\n" +
                                    "} \r\n");




                    outfile.WriteLine(" // Use this for extras during initialization");
                    outfile.WriteLine(" public override void ExtendedStart () {\r\n" +
                        "\r\n" +
                        "}\r\n" +
                        " \r\n");

                    outfile.WriteLine(" // Extended Update function, will be executed after regular update");
                    outfile.WriteLine(" public override void ExtendedUpdate () {\r\n" +
                        "\r\n" +
                        "}");

                    outfile.WriteLine("}");
                    outfile.WriteLine("}");
                }//File written
            }
            AssetDatabase.Refresh();
        }
        void OnGUI()
        {
            GUILayout.Label("Publisher Generator", EditorStyles.boldLabel);
            subscriberName = EditorGUILayout.TextField("Subscriber Name", subscriberName);
            subscriberNamespace = EditorGUILayout.TextField("SubscriberNamespace", subscriberNamespace);
            EditorGUILayout.BeginToggleGroup("Inlcude Message", includeMsg);
            messageName = EditorGUILayout.TextField("Message Name", messageName);


            if (GUILayout.Button(generateBtn))
            {
                Create();
            }

            void Create()
            {
                string copyPath = "Assets/DTStacks/UnityComponents/Generic/Subscriber/Custom/" + subscriberName + ".cs";
                Debug.Log("Creating Subscriber Classfile: " + copyPath);

                if (File.Exists(copyPath) == false)
                {
                    // do not overwrite
                    using (StreamWriter outfile =
                        new StreamWriter(copyPath))
                    {
                        outfile.WriteLine("using UnityEngine;");
                        outfile.WriteLine("using System.Collections;");
                        outfile.WriteLine(" ");
                        outfile.WriteLine("using DTStacks.UnityComponents.Communication.MQTT;\r\n" +
                            "using DTStacks.DataType.Generic.Custom; \r\n");
                        outfile.WriteLine("");
                        outfile.WriteLine("namespace " + subscriberNamespace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("public class " + subscriberName + " : DTS_MQTTSubscriber {");
                        outfile.WriteLine(" ");
                        outfile.WriteLine(" ");
                        outfile.WriteLine("public " + messageName + " Msg;");


                        outfile.WriteLine("public void FeedData(string s) \r\n" +
                            "{ \r\n" +
                            "  Msg.FeedDataFromJSON(s); \r\n" +
                            "} \r\n");


                        outfile.WriteLine(" public override void ProcessMessage(string msg)\r\n" +
                                        "{\r\n" +
                                        "FeedData(msg);\r\n" +
                                        "} \r\n"
                                        );



                        outfile.WriteLine(" // Use this for extras during initialization");
                        outfile.WriteLine(" public override void ExtendedStart () {\r\n" +
                            "\r\n" +
                            "}\r\n" +
                            " \r\n");

                        outfile.WriteLine(" // Extended Update function, will be executed after regular update");
                        outfile.WriteLine(" public override void ExtendedUpdate () {\r\n" +
                            "\r\n" +
                            "}");

                        outfile.WriteLine("}");
                        outfile.WriteLine("}");
                    }//File written
                }
                AssetDatabase.Refresh();
            }
        }
    }
}
