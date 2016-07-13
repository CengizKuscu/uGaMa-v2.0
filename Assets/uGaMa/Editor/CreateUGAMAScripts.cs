using System.IO;
using UnityEditor;

namespace uGaMa.Editor
{
    public class CreateUGAMAScripts : UnityEditor.AssetModificationProcessor
    {

        public static void CreateContext(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Context;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public class " + className + " : Context");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\tpublic override void Bindings()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\tpublic override void UnBindings()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateCommand(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Command;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public class " + className + " : Command");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\tpublic override void Execute(NotifyParam notify)");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }

        public static void CreateMonoBehaviour(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public class " + className + " : MonoBehaviour");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t// Use this for initialization");
                    outfile.WriteLine("\tvoid Start()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t// Update is called once per frame");
                    outfile.WriteLine("\tvoid Update()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }

        public static void CreateView(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("using uGaMa.Mediator;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public class " + className + " : View");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t// Use this for initialization");
                    outfile.WriteLine("\tvoid Start()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t// Update is called once per frame");
                    outfile.WriteLine("\tvoid Update()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateMediator(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("using uGaMa.Mediator;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public class " + className + " : Mediator");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\tpublic override void Init()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t// Use this for initialization");
                    outfile.WriteLine("\tpublic override void OnRegister()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t// Update is called once per frame");
                    outfile.WriteLine("\tpublic override void OnRemove()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateModelInterface(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Model;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public interface " + className + " : IModel");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateModel(string className, string path)
        {
            string interfaceName = "I" + className;
            string interfacePath = path + "/" + interfaceName + ".cs";


            //path += "/" + interfaceName + ".cs";

            if (File.Exists(interfacePath) == false)
            {
                using (StreamWriter outfile = new StreamWriter(interfacePath))
                {
                    outfile.WriteLine("using uGaMa.Model;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public interface " + interfaceName + " : IModel");
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("}");
                }
            }

            string classPath = path + "/" + className + ".cs";

            AssetDatabase.Refresh();

            if (File.Exists(classPath) == false)
            {
                using (StreamWriter outfile = new StreamWriter(classPath))
                {
                    outfile.WriteLine("using uGaMa.Model;");
                    outfile.WriteLine("");
                    outfile.WriteLine("public class " + className + " : " + interfaceName);
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\tpublic void init()");
                    outfile.WriteLine("\t{");
                    outfile.WriteLine("");
                    outfile.WriteLine("\t}");
                    outfile.WriteLine("}");
                }
            }

            AssetDatabase.Refresh();
        }

        public static void CreateEnum(string className, string path)
        {
            path += "/" + className + ".cs";

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("public enum " + className);
                    outfile.WriteLine("{");
                    outfile.WriteLine("");
                    outfile.WriteLine("}");
                }
            }
            AssetDatabase.Refresh();
        }
    }
}