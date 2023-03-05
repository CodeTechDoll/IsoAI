using DataTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Assets.Scripts.DataFlow
{
    public class DataManager<T, U>
        where T : DataObject<U>
        where U : class
    {
        private readonly IDataSerializer<T, U> _serializer;
        private readonly Dictionary<int, T> _objects = new Dictionary<int, T>();
        private static string directoryPath = Application.persistentDataPath + "/data/test.json";

        public event UnityAction<T> ObjectAdded;
        public event UnityAction<T> ObjectRemoved;
        public event UnityAction<T> ObjectChanged;
        public DataManager(IDataSerializer<T, U> serializer)
        {
            _serializer = serializer;
        }

        public void Add(T obj)
        {
            _objects[obj.Id] = obj;
            obj.Changed.AddListener(HandleObjectChanged);
            ObjectAdded?.Invoke(obj);
        }

        public void Remove(T obj)
        {
            _objects.Remove(obj.Id);
            obj.Changed.RemoveListener(HandleObjectChanged);
            ObjectRemoved?.Invoke(obj);
        }

        public void HandleObjectChanged(DataObject<U> obj)
        {
            ObjectChanged?.Invoke(obj as T);
        }

        public void Save()
        {
            Save(_objects, directoryPath);
        }

        public void Load()
        {
            Load(directoryPath);
        }

        public void Save(Dictionary<int, T> dataObjects, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }


            var data = new Dictionary<string, string>();
            foreach (var pair in dataObjects)
            {
                var id = pair.Key;
                var dataObject = pair.Value;
                data[id.ToString()] = _serializer.Serialize(dataObject);
            }
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public Dictionary<int, T> Load(string filePath)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(filePath));
            var dataObjects = new Dictionary<int, T>();

            foreach (var pair in data)
            {
                var id = int.Parse(pair.Key);
                var json = pair.Value;
                var dataObject = _serializer.Deserialize(json);
                dataObjects[id] = dataObject;
            }

            return dataObjects;
        }
    }
}
