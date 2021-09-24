using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

namespace DTStacks.Editor.Generator
{

    public class PublisherGenerator : EditorWindow
    {

        string publisherName = "GenericPublisher";
        string publisherNamespace = "DTStacks.UnityComponents.Generic.Publisher.Custom";
        string messageName = "GenericMessage";
        bool includeMsg = true;
        bool groupEnabled;
        bool myBool = true;
        float myFloat = 1.23f;
        
        string generateBtn = "Generate Publisher";


        //public variableTypes variableType;

        [MenuItem("DTStacks/Create/Publisher")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            PublisherGenerator window = (PublisherGenerator)EditorWindow.GetWindow(typeof(PublisherGenerator));
            window.Show();
        }

        public void Create(string publisherName, string publisherNamespace, string messageName)
        {
            string copyPath = "Assets/DTStacks/UnityComponents/Generic/Publisher/Custom/" + publisherName + ".cs";
            Debug.Log("Creating Publisher Classfile: " + copyPath);

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
                    outfile.WriteLine("namespace " + publisherNamespace);
                    outfile.WriteLine("{");
                    outfile.WriteLine("public class " + publisherName + " : DTS_MQTTPubilsher {");
                    outfile.WriteLine(" ");
                    outfile.WriteLine(" ");
                    outfile.WriteLine("public " + messageName + " Msg;");

                    outfile.WriteLine("public string GetData() \n" +
                        "{ \n" +
                        "   return Msg.CreateJSONFromData(); \n" +
                        "} \n");

                    outfile.WriteLine(" public override void InitPublishing()\n" +
                        "{\n" +
                        "base.InitPublishing();\n" +
                        "PublishMsg(GetData()); \n" +
                        "}\n"
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
        void OnGUI()
        {
            GUILayout.Label("Publisher Generator", EditorStyles.boldLabel);
            publisherName = EditorGUILayout.TextField("Publisher Name", publisherName);
            publisherNamespace = EditorGUILayout.TextField("Publisher Namespace", publisherNamespace);
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
                string copyPath = "Assets/DTStacks/UnityComponents/Generic/Publisher/Custom/" + publisherName + ".cs";
                Debug.Log("Creating Publisher Classfile: " + copyPath);

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
                        outfile.WriteLine("namespace " + publisherNamespace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("public class " + publisherName + " : DTS_MQTTPubilsher {");
                        outfile.WriteLine(" ");
                        outfile.WriteLine(" ");
                        outfile.WriteLine("public " + messageName + " Msg;");

                        outfile.WriteLine("public string GetData() \n" +
                            "{ \n" +
                            "   return Msg.CreateJSONFromData(); \n" +
                            "} \n");

                        outfile.WriteLine(" public override void InitPublishing()\n" +
                            "{\n" +
                            "base.InitPublishing();\n" +
                            "PublishMsg(GetData()); \n" +
                            "}\n"
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
