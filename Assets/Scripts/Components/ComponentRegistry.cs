using Assets.Scripts.DataTypes.Properties;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Components
{
    public class ComponentRegistry : MonoBehaviour
    {
        
        public Dictionary<Type, GameObject> componentMap = new Dictionary<Type, GameObject>();

        public void RegisterComponent<T>(GameObject gameObject) where T : YComponent
        {
            componentMap[typeof(T)] = gameObject;
        }

        public void UnregisterComponent<T>() where T : YComponent
        {
            componentMap.Remove(typeof(T));
        }

        public T InstantiateComponent<T>() where T : YComponent
        {
            if (!componentMap.ContainsKey(typeof(T)))
            {
                Debug.LogError("Component not registered!");
                return null;
            }

            GameObject prefab = componentMap[typeof(T)];
            GameObject instance = Instantiate(prefab);
            T component = instance.AddComponent<T>();
            return component;
        }
        
    }
}