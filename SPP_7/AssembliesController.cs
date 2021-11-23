using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using AttributesLibraryForSPP7;

namespace SPP_7
{
    public class AssembliesController
    {
        public Queue<UserControl> UserControlsQueue { get; private set; }
        string assembliesFolder;
        public AssembliesController(string assembliesFolder)
        {
            UserControlsQueue = new Queue<UserControl>();
            if (!Directory.Exists(assembliesFolder)) throw new IOException("Assemblies folder does not exists!");
            this.assembliesFolder = assembliesFolder;
        }

        public void CheckAssemblies()
        {
            if (!Directory.Exists(assembliesFolder)) throw new IOException("Assemblies folder does not exists!");
            IEnumerable<string> files = Directory.GetFiles(assembliesFolder);
            //Parallel.ForEach(files, fileName =>
            foreach(var fileName in files)
            {
                if (CheckFileExtension(fileName, ".dll"))
                {
                    LoadAssembly(fileName);
                }
            }//);
        }

        public bool CheckFileExtension(string fileName, string extensionWithDot)
        {
            return fileName.EndsWith(extensionWithDot);
        }

        public void LoadAssembly(string assFileName)
        {
            Assembly assembly = Assembly.LoadFrom(assFileName);
            Type t = assembly.GetTypes()?.ElementAt(0);
            UserControl controlFromAss = (UserControl)Activator.CreateInstance(t);
            UserControlsQueue.Enqueue(controlFromAss);

            //SetAssemblyCustomAttributes(t.CustomAttributes, null);
        }

        private void SetAssemblyCustomAttributes(IEnumerable<CustomAttributeData> customAttributes, UserControl userControl)
        {
            foreach(CustomAttributeData attr in customAttributes)
            {
                MessageBox.Show("" + attr.ConstructorArguments[0].Value);
                switch (attr.AttributeType.Name)
                {
                    case "LeftSpanInLinesAttribute":
                        //userControl.SetValue(Grid.ColumnProperty, (attr.ConstructorArguments));
                        break;
                    case "WidthInLinesAttributes":
                        break;
                    case "TopSpanInLinesAttribute":
                        break;
                    case "HeightInLinesAttribute":
                        break;
                }
            }
        }
    }
}
