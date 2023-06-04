using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace De_Serialization_Lib
{
    public class De_Serealize
    {
        public static void Serialize<T>(List<T> notes, string way)
        {
            string json = JsonConvert.SerializeObject(notes);
            if (!way.Contains("students.json"))
            {
                way += "\\students.json";
            }
            File.WriteAllText(way, json);
        }
        public static List<T> Deserialize<T>(string way)
        {
            List<T> list = new List<T>();

            Directory.CreateDirectory(way);
            way += "\\students.json";

            if (!File.Exists(way))
            {
                File.Create(way);
            }

            string json = File.ReadAllText(way);
            if (string.IsNullOrEmpty(json))
            {
                Serialize(list, way);
                return list;
            }

            list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }
    }
}