using System.IO;
using UnityEditor;

namespace uGaMa.Editor
{
    public class CreateUGAMAScripts : UnityEditor.AssetModificationProcessor
    {

        public static void CreateContext(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Context;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className + " : Context");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\tpublic override void Bindings()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\tpublic override void UnBindings()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateCommand(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Command;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className + " : Command");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\tpublic override void Execute(NotifyParam notify)");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }

        public static void CreateCSharpScript(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using System;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className );
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateMonoBehaviour(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className + " : MonoBehaviour");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t// Use this for initialization");
                    outfile.WriteLine(classSeperate + "\tvoid Start()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t// Update is called once per frame");
                    outfile.WriteLine(classSeperate + "\tvoid Update()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }

        public static void CreateView(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("using uGaMa.Mediate;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className + " : View");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t// Use this for initialization");
                    outfile.WriteLine(classSeperate + "\tvoid Start()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t// Update is called once per frame");
                    outfile.WriteLine(classSeperate + "\tvoid Update()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateMediator(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using UnityEngine;");
                    outfile.WriteLine("using uGaMa.Mediate;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className + " : Mediator");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t// Use this for initialization");
                    outfile.WriteLine(classSeperate + "\tpublic override void OnRegister()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t// Update is called once per frame");
                    outfile.WriteLine(classSeperate + "\tpublic override void OnRemove()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateModelInterface(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Model;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public interface " + className + " : IModel");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }

        public static void CreateInterface(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";

            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    outfile.WriteLine("using uGaMa.Model;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public interface " + className);
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }


        public static void CreateModel(string className, string path, string nameSpace)
        {
            string interfaceName = "I" + className;
            string interfacePath = path + "/" + interfaceName + ".cs";

            string classSeperate = "";
            
            if (nameSpace != "")
            {
                classSeperate = "\t";
            }

            //path += "/" + interfaceName + ".cs";

            if (File.Exists(interfacePath) == false)
            {
                using (StreamWriter outfile = new StreamWriter(interfacePath))
                {
                    outfile.WriteLine("using uGaMa.Model;");
                    outfile.WriteLine("");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public interface " + interfaceName + " : IModel");
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
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

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate + "public class " + className + " : " + interfaceName);
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\tpublic void init()");
                    outfile.WriteLine(classSeperate + "\t{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "\t}");
                    outfile.WriteLine(classSeperate + "}");                    

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }

            AssetDatabase.Refresh();
        }

        public static void CreateEnum(string className, string path, string nameSpace)
        {
            path += "/" + className + ".cs";

            string classSeperate = "";
            
            if(nameSpace != "")
            {
                classSeperate = "\t";
            }
            
            if (File.Exists(path) == false)
            {
                using (StreamWriter outfile = new StreamWriter(path))
                {
                    if(nameSpace != "")
                    {
                        outfile.WriteLine("namespace " + nameSpace);
                        outfile.WriteLine("{");
                        outfile.WriteLine("");
                    }

                    outfile.WriteLine(classSeperate+"public enum " + className);
                    outfile.WriteLine(classSeperate + "{");
                    outfile.WriteLine(classSeperate + "");
                    outfile.WriteLine(classSeperate + "}");

                    if (nameSpace != "")
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("}");
                    }
                }
            }
            AssetDatabase.Refresh();
        }
    }
}