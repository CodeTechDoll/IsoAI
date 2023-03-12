using System;
using System.Collections.Generic;
using YComponent = Assets.Scripts.Components.YComponent;
using UnityEngine;
using Assets.Scripts.DataManagement;
using Zenject;
using Assets.Scripts.Components;
using System.Reflection;

namespace Assets.Scripts.Entities
{
    public class EntityFactory : MonoBehaviour
    {
        public GameObject entityPrefab;
        [Inject]
        public DataLoaderSystem dataLoaderSystem;
        [Inject]
        public ComponentRegistry componentRegistry;
        [Inject]
        public EntityFactory entityFactory;
        public string[] EntityDataFiles;
        
        public GameObject CreateEntity(string name)
        {
            if (entityPrefab == null)
            {
                Debug.LogError("Entity prefab not set!");
                return null;
            }

            GameObject gameObject = Instantiate(entityPrefab);
            gameObject.name = name;
            gameObject.AddComponent<DataComponent>();

            return gameObject;
        }

        public void PrepareFactory()
        {
            // Load the data for the new entity from a JSON file
            Dictionary<string, object> entityData = dataLoaderSystem.LoadData(EntityDataFiles);

            // Create a new entity with the name specified in the data
            GameObject newEntity = entityFactory.CreateEntity((string)entityData["name"]);

            // Add the data component to the entity
            DataComponent dataComponent = newEntity.GetComponent<DataComponent>();
            dataComponent.data = entityData;

            // Instantiate the necessary components based on the data
            foreach (string componentName in (List<object>)entityData["components"])
            {
                Type componentType = Type.GetType(componentName);
                if (componentType == null)
                {
                    Debug.LogError("Invalid component type: " + componentName);
                    continue;
                }

                YComponent component = componentRegistry.InstantiateComponent(componentType);
                Dictionary<string, object> componentData = (Dictionary<string, object>)entityData[componentName];
                foreach (string propertyName in componentData.Keys)
                {
                    FieldInfo field = componentType.GetField(propertyName);
                    if (field == null)
                    {
                        Debug.LogError("Invalid property name: " + propertyName);
                        continue;
                    }
                    field.SetValue(component, componentData[propertyName]);
                }
                newEntity.AddComponent(component);
            }
        }
    }
}