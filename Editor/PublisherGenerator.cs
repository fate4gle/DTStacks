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
        
        string generateBtn = "Generate Publisher";


        
        [MenuItem("DTStacks/Create/Publisher")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            PublisherGenerator window = (PublisherGenerator)EditorWindow.GetWindow(typeof(PublisherGenerator));
            window.Show();
        }

        public void Create(string publisherName, string publisherNamespace, string messageName, string messageNamespace)
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
                    outfile.WriteLine("using DTStacks.UnityComponents.Communication.MQTT;\r\n" +
                        "using " + messageNamespace +";\r\n");
                    outfile.WriteLine("");
                    outfile.WriteLine("namespace " + publisherNamespace);
                    outfile.WriteLine("{");
                    outfile.WriteLine("public class " + publisherName + " : DTS_MQTTPubilsher {");
                    outfile.WriteLine(" ");
                    outfile.WriteLine(" ");
                    outfile.WriteLine("public " + messageName + " Msg;");

                    outfile.WriteLine("public string GetData() \r\n" +
                        "{ \r\n" +
                        "   return Msg.CreateJSONFromData(); \r\n" +
                        "} \r\n");

                    outfile.WriteLine(" public override void InitPublishing()\r\n" +
                        "{\r\n" +
                        "base.InitPublishing();\r\n" +
                        "PublishMsg(GetData()); \r\n" +
                        "}\r\n"
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
        void OnGUI()
        {
            GUILayout.Label("Publisher Generator", EditorStyles.boldLabel);
            publisherName = EditorGUILayout.TextField("Publisher Name", publisherName);
            publisherNamespace = EditorGUILayout.TextField("Publisher Namespace", publisherNamespace);
            EditorGUILayout.BeginToggleGroup("Inlcude Message", includeMsg);
            messageName = EditorGUILayout.TextField("Message Name", messageName);

            
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
                        outfile.WriteLine("using DTStacks.UnityComponents.Communication.MQTT;\r\n" +
                            "using DTStacks.DataType.Generic.Custom; \r\n");                  
                        outfile.WriteLine("");
                        outfile.WriteLine("namespace " + publisherNamespace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("public class " + publisherName + " : DTS_MQTTPubilsher {");
                        outfile.WriteLine(" ");
                        outfile.WriteLine(" ");
                        outfile.WriteLine("public " + messageName + " Msg;");

                        outfile.WriteLine("public string GetData() \r\n" +
                            "{ \r\n" +
                            "   return Msg.CreateJSONFromData(); \r\n" +
                            "} \r\n");

                        outfile.WriteLine(" public override void InitPublishing()\r\n" +
                            "{\r\n" +
                            "base.InitPublishing();\r\n" +
                            "PublishMsg(GetData()); \r\n" +
                            "}\r\n"
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
