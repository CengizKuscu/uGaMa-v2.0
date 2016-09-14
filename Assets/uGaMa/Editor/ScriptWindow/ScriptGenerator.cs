using UnityEngine;
using System.IO;
using UnityEditor;
using uGaMa.Editor;

public class ScriptGenerator : EditorWindow
{
    string path;
    string className;
    
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

        EditorGUILayout.LabelField("Path : "+ path,EditorStyles.boldLabel, GUILayout.Width(position.width - 10));

        GUILayout.Space(15);

        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 2);

        GUILayout.Space(15);

        className = EditorGUILayout.TextField("Script Name: ", className);

        GUILayout.Space(15);

        if (GUILayout.Button("Create", GUILayout.Height(50)))
        {
            InstantiatePrimitive(className, path);
            AssetDatabase.SaveAssets();
        }
        
        
        EditorGUILayout.EndVertical();
        this.Repaint();

        EditorUtility.SetDirty(this);
    }

    void InstantiatePrimitive(string className, string path)
    {
        //string typeStr = selStrings[selGridInt];

        switch (selGridInt)
        {
            case 0:
                CreateUGAMAScripts.CreateContext(className, path);
                break;

            case 1:
                CreateUGAMAScripts.CreateView(className, path);
                break;

            case 2:
                CreateUGAMAScripts.CreateMediator(className, path);
                break;

            case 3:
                CreateUGAMAScripts.CreateModel(className, path);
                break;

            case 4:
                CreateUGAMAScripts.CreateCommand(className, path);
                break;

            case 5:
                CreateUGAMAScripts.CreateMonoBehaviour(className, path);
                break;

            case 6:
                CreateUGAMAScripts.CreateCSharpScript(className, path);
                break;

            case 7:
                CreateUGAMAScripts.CreateInterface(className, path);
                break;

            case 8:
                CreateUGAMAScripts.CreateEnum(className, path);
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

