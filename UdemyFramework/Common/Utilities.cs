using System;
using Newtonsoft.Json;
using System.IO;

namespace UdemyFramework
{
    public static class Utilities
    {
        /// <summary>
        /// Deserialize jsonDataFile and return it into a requested type
        /// </summary>
        public static T GetDataFromJsonFile<T>(string jsonDataFile)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Replace("bin\\Debug\\", "Data\\");
            string data = File.ReadAllText(string.Format("{0}/{1}", path, jsonDataFile));
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static string GetStringDataFromFile(string DataFile)
        {
            return File.ReadAllText(string.Format("{0}/../..{1}", AppDomain.CurrentDomain.BaseDirectory, DataFile));
        }

        public static T GetDeserializedJson<T>(string jsonText)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return JsonConvert.DeserializeObject<T>(jsonText);
        }

        public static string GetSerializedJson<T>(T type)
        {
            return JsonConvert.SerializeObject(type);
        }
    }
}
