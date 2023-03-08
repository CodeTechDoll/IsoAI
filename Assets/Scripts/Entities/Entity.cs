using Assets.Scripts.Components;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YComponent = Assets.Scripts.Components.YComponent;

namespace Assets.Scripts.Entities
{
    public class Entity
    {
        private Dictionary<Type, YComponent> components = new Dictionary<Type, YComponent>();

        public int Id { get; private set; }

        public Entity(IDGenerator idGenerator)
        {
            Id = idGenerator.GenerateID();
        }

        public void AddComponent<T>(T component) where T : YComponent
        {
            component.SetEntity(this);
            components[typeof(T)] = component;
        }

        public T GetComponent<T>() where T : YComponent
        {
            if (components.TryGetValue(typeof(T), out var component))
            {
                return (T)component;
            }

            return null;
        }

        public bool HasComponent<T>() where T : YComponent
        {
            return components.ContainsKey(typeof(T));
        }

        public void RemoveComponent<T>() where T : YComponent
        {
            if (components.TryGetValue(typeof(T), out var component))
            {
                component.ClearEntity();
                components.Remove(typeof(T));
            }
        }

        public IEnumerable<T> GetComponents<T>() where T : YComponent
        {
            foreach (var component in components.Values)
            {
                if (component is T tComponent)
                {
                    yield return tComponent;
                }
            }
        }
    }
}