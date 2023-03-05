using DataTypes;
using Newtonsoft.Json;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DataFlow
{
    public class JsonDataSerializer<T, U> : IDataSerializer<T, U> where T : DataObject<U> where U : class
    {
        public T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize(T dataObject)
        {
            return JsonConvert.SerializeObject(dataObject, Formatting.Indented);
        }

        public void Save(T dataObject, string filePath)
        {
            string jsonData = Serialize(dataObject);
            File.WriteAllText(filePath, jsonData);
        }

        public T Load(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return Deserialize(jsonData);
        }
    }
}