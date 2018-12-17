using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FolderStructureImporterExporter
{
    public abstract class ImportExportHelper
    {
        //public abstract void Do();
        public bool IsFile { get; set; }
        public bool IsDirectory { get; set; }

        protected string toJson(object _data)
        {
            string jsonData = string.Empty;
            //List<Type> knownTypes = new List<Type>();
            //knownTypes.Add(typeof(T));
            //knownTypes.Add(typeof(CCIL.MESSAGES.MessageHeader));
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(_data.GetType());
            MemoryStream ms = new MemoryStream();
            jsonSerializer.WriteObject(ms, _data);
            jsonData = Encoding.UTF8.GetString(ms.ToArray());
            return jsonData;
        }
        protected string toNewtonJson(object _data)
        {
            return JObject.FromObject(_data).ToString();
        }

        protected void SaveFileAs(string fileTextData)
        {
            // Process save file dialog box results
            var tuppleResult = OpenDialog();
            if (tuppleResult.Item2.HasValue && tuppleResult.Item2.Value)
            {
                // Save document
                string filename = tuppleResult.Item1.FileName;
                File.WriteAllText(filename, fileTextData);
            }
            else
            {
                throw new Exception("Unable to open Dialog");
            }
        }

        protected Tuple<Microsoft.Win32.SaveFileDialog, bool?> OpenDialog()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Export"; // Default file name
            dlg.DefaultExt = ".json"; // Default file extension
            //dlg.Filter = "Json documents (.json)|*.json"; // Filter files by extension
            dlg.Filter = "Json Files(*.json)|*.json|All(*.*)|*";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            var resultTupple = new Tuple<Microsoft.Win32.SaveFileDialog, bool?>(dlg, result);

            return resultTupple;
        }

        protected bool CheckForDirectory(string path)
        {
            var fileAttributes = File.GetAttributes(path);
            var result = fileAttributes.HasFlag(FileAttributes.Directory);
            return result;
        }
    }
}
