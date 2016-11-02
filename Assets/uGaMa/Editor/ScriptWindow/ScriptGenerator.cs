using UnityEngine;
using System.IO;
using UnityEditor;
using uGaMa.Editor;

namespace uGaMa.Editor
{

    public class ScriptGenerator : EditorWindow
    {
        string path;
        string className;
        bool useNameSpace;
        string nameSpaceName;

        public string[] selStrings;

        public int selGridInt;

        [MenuItem("Window/uGaMa Scripts")]
        static void Init()
        {
            ScriptGenerator window = (ScriptGenerator)EditorWindow.GetWindow(typeof(ScriptGenerator), false, "uGaMa Scripts");
            window.Show();
        }

        void OnEnable()
        {
            path = "Assets";

            selStrings = new string[] { "Context", "View", "Mediator", "Model", "Command", "MonoBehaviour", "C#", "Interface", "enum" };

            selGridInt = 0;

            nameSpaceName = "";

            useNameSpace = false;
        }


        void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.LabelField("Select a Folder from Project", EditorStyles.boldLabel);


            foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }

            EditorGUILayout.LabelField("Path : " + path, EditorStyles.boldLabel, GUILayout.Width(position.width - 10));

            GUILayout.Space(15);

            selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 2);

            GUILayout.Space(15);

            useNameSpace = EditorGUILayout.Toggle("Use namespace: ", useNameSpace);

            if(useNameSpace)
            {
                nameSpaceName = EditorGUILayout.TextField("namespace: ", nameSpaceName);
            }

            GUILayout.Space(15);

            className = EditorGUILayout.TextField("Script Name: ", className);

            GUILayout.Space(15);

            if (GUILayout.Button("Create", GUILayout.Height(50)))
            {
                InstantiatePrimitive(className, path, useNameSpace);
                AssetDatabase.SaveAssets();
            }


            EditorGUILayout.EndVertical();
            this.Repaint();

            EditorUtility.SetDirty(this);
        }

        void InstantiatePrimitive(string className, string path, bool _useNameSpace)
        {
            //string typeStr = selStrings[selGridInt];
            string nameSpace = "";

            if(_useNameSpace)
            {
                nameSpace = nameSpaceName;
            }

            switch (selGridInt)
            {
                case 0:
                    CreateUGAMAScripts.CreateContext(className, path, nameSpace);
                    break;

                case 1:
                    CreateUGAMAScripts.CreateView(className, path, nameSpace);
                    break;

                case 2:
                    CreateUGAMAScripts.CreateMediator(className, path, nameSpace);
                    break;

                case 3:
                    CreateUGAMAScripts.CreateModel(className, path, nameSpace);
                    break;

                case 4:
                    CreateUGAMAScripts.CreateCommand(className, path, nameSpace);
                    break;

                case 5:
                    CreateUGAMAScripts.CreateMonoBehaviour(className, path, nameSpace);
                    break;

                case 6:
                    CreateUGAMAScripts.CreateCSharpScript(className, path, nameSpace);
                    break;

                case 7:
                    CreateUGAMAScripts.CreateInterface(className, path, nameSpace);
                    break;

                case 8:
                    CreateUGAMAScripts.CreateEnum(className, path, nameSpace);
                    break;

                default:
                    CreateUGAMAScripts.CreateMonoBehaviour(className, path, nameSpace);
                    break;
            }
        }

        public void OnInspectorUpdate()
        {
            this.Repaint();
        }
    }
}