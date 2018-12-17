using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FolderStructureImporterExporter
{
    public static class JsonHelper
    {
        public static string ToJson(object data)
        {
            var serializedJsonString = string.Empty;
            serializedJsonString = JsonConvert.SerializeObject(data, Formatting.Indented);

            return serializedJsonString;
        }

        public static T FromJson<T>(string jsonString)
        {
            T returnedData;

            returnedData = JsonConvert.DeserializeObject<T>(jsonString);

            return returnedData;
        }
    }
}
