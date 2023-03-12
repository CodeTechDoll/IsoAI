using Assets.Scripts.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using YComponent = Assets.Scripts.Components.YComponent;

namespace Assets.Scripts.DataManagement
{
    public abstract class DataLoaderSystem
    {
        public Dictionary<string, object> LoadData(string[] fileNames)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
                if (!File.Exists(filePath))
                {
                    Debug.LogError("File not found: " + filePath);
                    continue;
                }

                string jsonString = File.ReadAllText(filePath);
                Dictionary<string, object> jsonData = Json.Deserialize(jsonString) as Dictionary<string, object>;
                foreach (string key in jsonData.Keys)
                {
                    if (result.ContainsKey(key))
                    {
                        Debug.LogWarning("Duplicate key found in data files: " + key);
                    }
                    result[key] = jsonData[key];
                }
            }
            return result;
        }
    }
}