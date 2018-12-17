using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
namespace FolderStructureImporterExporter
{
    public class ExportHelper : ImportExportHelper
    {
        public void Export(string rootPath)
        {
            var entries = Directory.GetFileSystemEntries(rootPath, "*", SearchOption.AllDirectories);
            var d = new DirectoryInfo(rootPath).EnumerateFileSystemInfos("*", SearchOption.AllDirectories);
            var logicalEntries = d.AsEnumerable().ToArray();
            //var entriesJson = toJson(entries);
            //var logicalEntries = entries.Select(s => s.Replace(rootPath + "\\", string.Empty)).ToList<string>();

            try
            {
                var jsonString = JsonHelper.ToJson(logicalEntries);
                base.SaveFileAs(jsonString);
                //var dataObject = JsonHelper.FromJson<List<string>>(jsonString);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
