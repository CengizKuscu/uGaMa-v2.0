using UnityEngine;
using UnityEditor;
using System.IO;

namespace uGaMa.Editor
{
    public class uGaMaScriptWindow : EditorWindow
    {
        bool showPosition = true;
        string status = "Select a Folder from Project";
        string path = "";
        string className;
        int index = 0;

        // Add menu named "My Window" to the Window menu
        [MenuItem("Window/uGaMa Scripts")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            uGaMaScriptWindow window = (uGaMaScriptWindow)EditorWindow.GetWindow(typeof(uGaMaScriptWindow), false, "uGaMa Scripts");
            window.Show();
        }


        void OnGUI()
        {
            GUILayout.Label("uGaMa Scripts", EditorStyles.boldLabel);

            showPosition = EditorGUILayout.Foldout(showPosition, status);
            if (showPosition)
            {
                foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
                {
                    path = AssetDatabase.GetAssetPath(obj);
                    if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    {
                        path = Path.GetDirectoryName(path);
                        break;
                    }
                }
                path = EditorGUILayout.TextField("Path: ", path);

                string[] options = new string[] { "Context", "Command", "Model", "View", "Mediator", "enum", "MonoBehaviour", "C# Script" };

                index = EditorGUILayout.Popup(index, options);

                className = EditorGUILayout.TextField("Class Name", className);

                if (GUILayout.Button("Create"))
                {
                    this.Repaint();
                    InstantiatePrimitive(className, path);
                }
            }
            this.Repaint();
        }

        //private string GetTempScriptName()
        //{
        //    switch (index)
        //    {
        //        case 0:
        //            return "uGaMa_Context";
        //        case 1:
        //            return "uGaMa_Command";
        //        case 2:
        //            return "uGaMa_Model";
        //        case 3:
        //            return "uGaMa_View";
        //        case 4:
        //            return "uGaMa_Mediator";
        //        case 5:
        //            return "uGaMa_enum";
        //        case 6:
        //            return "MonoBehaviour";
        //        default:
        //            return "uGaMa_View";

        //    }
        //}

        void InstantiatePrimitive(string className, string path)
        {
            switch (index)
            {
                case 0:
                    CreateUGAMAScripts.CreateContext(className, path);
                    break;

                case 1:
                    CreateUGAMAScripts.CreateCommand(className, path);
                    break;

                case 2:
                    CreateUGAMAScripts.CreateModel(className, path);
                    break;

                case 3:
                    CreateUGAMAScripts.CreateView(className, path);
                    break;

                case 4:
                    CreateUGAMAScripts.CreateMediator(className, path);
                    break;

                case 5:
                    CreateUGAMAScripts.CreateEnum(className, path);
                    break;

                case 6:
                    CreateUGAMAScripts.CreateMonoBehaviour(className, path);
                    break;

                case 7:
                    CreateUGAMAScripts.CreateCSharpScript(className, path);
                    break;

                default:
                    CreateUGAMAScripts.CreateMonoBehaviour(className, path);
                    break;
            }
        }

        public void OnInspectorUpdate()
        {
            this.Repaint();
        }
    }
}