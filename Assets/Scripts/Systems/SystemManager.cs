using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    [AddComponentMenu("")]
    public class SystemManager : MonoBehaviour
    {
        // Store systems as a dictionary for faster access
        private Dictionary<Type, BaseSystem> systems = new Dictionary<Type, BaseSystem>();

        // Use generics to ensure type safety when registering systems
        public void RegisterSystem<T>(T system) where T : BaseSystem
        {
            systems[typeof(T)] = system;
        }

        // Use generics to ensure type safety when unregistering systems
        public void UnregisterSystem<T>(T system) where T : BaseSystem
        {
            systems.Remove(typeof(T));
        }

        // Use generics to ensure type safety when getting systems
        public T GetSystem<T>() where T : BaseSystem
        {
            if (systems.TryGetValue(typeof(T), out var system))
            {
                return (T)system;
            }
            return null;
        }

        private void Update()
        {
            foreach (var system in systems.Values)
            {
                system.Update();
            }
        }
    }
}