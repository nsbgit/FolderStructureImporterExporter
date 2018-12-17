using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FolderStructureImporterExporter
{
    public class ImportHelper : ImportExportHelper
    {

        public void Import(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath)) throw new ArgumentException("rootPath cannot be null or empty", "rootPath");

            var tuppleResult = OpenDialog();
            if (tuppleResult.Item2.HasValue && tuppleResult.Item2.Value)
            {
                // File name
                var filename = tuppleResult.Item1.FileName;
                var fileContent = File.ReadAllText(filename);
                var dataObject = JsonHelper.FromJson<DirectoryInfo[]>(fileContent);
                var eliminatePathPart = string.Empty;

                foreach (var item in dataObject)
                {
                    var pathElements = item.FullName.Split('\\');

                    if (string.IsNullOrWhiteSpace(eliminatePathPart))
                    {
                        for (int i = 0; i < pathElements.Length - 1; i++)
                        {
                            eliminatePathPart = Path.Combine(eliminatePathPart + "\\", pathElements[i]);
                        }
                    }

                    var logicalPath = item.FullName.Replace(eliminatePathPart + "\\", string.Empty);
                    var physicalPath = Path.Combine(rootPath, logicalPath);

                    if (item.Attributes.Equals(FileAttributes.Directory))
                    {
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                        }
                    }
                    else
                    {
                        if (!File.Exists(physicalPath))
                        {
                            File.WriteAllText(physicalPath, string.Empty);
                        }
                    }

                    //var physicalPath = Path.Combine(rootPath, item);
                    //var isDirectory = CheckForDirectory(physicalPath);
                    //if (!Directory.Exists(physicalPath))
                    //{
                    //    Directory.CreateDirectory(physicalPath);
                    //}

                    //if (!File.Exists(physicalPath))
                    //{
                    //    File.WriteAllText(physicalPath, string.Empty);
                    //}

                    //if (CheckForDirectory(item))
                    //{
                    //    // Directory

                    //}
                    //else
                    //{

                    //}
                }

            }
        }
    }

    class Concrete : FileSystemInfo
    {

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override bool Exists
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }
    }
}
