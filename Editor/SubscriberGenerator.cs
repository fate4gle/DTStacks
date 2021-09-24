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
        bool groupEnabled;
        bool myBool = true;
        float myFloat = 1.23f;

        string generateBtn = "Generate Subscriber";


        //public variableTypes variableType;

        [MenuItem("DTStacks/Create/Subscriber")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            SubscriberGenerator window = (SubscriberGenerator)EditorWindow.GetWindow(typeof(SubscriberGenerator));
            window.Show();
        }

        public void Create(string subscriberName, string subscriberNamespace, string messageName)
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
                    outfile.WriteLine("using DTStacks.UnityComponents.Communication.MQTT;\n" +
                        "using DTStacks.DataType.Generic.Custom; \n");
                    outfile.WriteLine("");
                    outfile.WriteLine("namespace " + subscriberNamespace);
                    outfile.WriteLine("{");
                    outfile.WriteLine("public class " + subscriberName + " : DTS_MQTTSubscriber {");
                    outfile.WriteLine(" ");
                    outfile.WriteLine(" ");
                    outfile.WriteLine("public " + messageName + " Msg;");


                    outfile.WriteLine("public void FeedData(string s) \n" +
                        "{ \n" +
                        "  Msg.FeedDataFromJSON(s); \n" +
                        "} \n");

                    outfile.WriteLine(" public override void ProcessMessage(string msg)\n" +
                                    "{\n" +
                                    "FeedData(msg);\n" +
                                    "} \n");




                    outfile.WriteLine(" // Use this for extras during initialization");
                    outfile.WriteLine(" public override void ExtendedStart () {\n" +
                        "\n" +
                        "}\n" +
                        " \n");

                    outfile.WriteLine(" // Extended Update function, will be executed after regular update");
                    outfile.WriteLine(" public override void ExtendedUpdate () {\n" +
                        "\n" +
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

            /*
            EditorGUILayout.EndToggleGroup();

            groupEnabled = EditorGUILayout.BeginToggleGroup("Include Paramters", groupEnabled);
            
            //variableType = (variableTypes)EditorGUILayout.EnumPopup("Select Paramter", variableType);
            EditorGUILayout.EndToggleGroup();
            */

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
                        outfile.WriteLine("using DTStacks.UnityComponents.Communication.MQTT;\n" +
                            "using DTStacks.DataType.Generic.Custom; \n");
                        outfile.WriteLine("");
                        outfile.WriteLine("namespace " + subscriberNamespace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("public class " + subscriberName + " : DTS_MQTTSubscriber {");
                        outfile.WriteLine(" ");
                        outfile.WriteLine(" ");
                        outfile.WriteLine("public " + messageName + " Msg;");


                        outfile.WriteLine("public void FeedData(string s) \n" +
                            "{ \n" +
                            "  Msg.FeedDataFromJSON(s); \n" +
                            "} \n");


                        outfile.WriteLine(" public override void ProcessMessage(string msg)\n" +
                                        "{\n" +
                                        "FeedData(msg);\n" +
                                        "} \n"
                                        );



                        outfile.WriteLine(" // Use this for extras during initialization");
                        outfile.WriteLine(" public override void ExtendedStart () {\n" +
                            "\n" +
                            "}\n" +
                            " \n");

                        outfile.WriteLine(" // Extended Update function, will be executed after regular update");
                        outfile.WriteLine(" public override void ExtendedUpdate () {\n" +
                            "\n" +
                            "}");

                        outfile.WriteLine("}");
                        outfile.WriteLine("}");
                    }//File written
                }
                AssetDatabase.Refresh();
            }
        }
        /*
         * Moved to Message  Generator
        public enum variableTypes
        {
            integer = 0,
            float64 = 1,
            boolean = 2
        }
        */

    }
}
