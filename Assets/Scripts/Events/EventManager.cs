using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class EventManager
    {
        public static EventManager Instance { get; private set; }

        private Dictionary<Type, List<Action<object>>> subscribers;

        private EventManager()
        {
            subscribers = new Dictionary<Type, List<Action<object>>>();
        }

        public static void Initialize()
        {
            Instance = new EventManager();
        }

        public void Subscribe<T>(Action<T> action)
        {
            if (!subscribers.ContainsKey(typeof(T)))
            {
                subscribers[typeof(T)] = new List<Action<object>>();
            }

            subscribers[typeof(T)].Add(obj => action((T)obj));
        }

        public void Unsubscribe<T>(Action<T> action)
        {
            if (subscribers.TryGetValue(typeof(T), out var actions))
            {
                actions.Remove(obj => action((T)obj));
            }
        }

        public void Notify<T>(T data)
        {
            if (subscribers.TryGetValue(typeof(T), out var actions))
            {
                foreach (var action in actions)
                {
                    action(data);
                }
            }
        }
    }
}