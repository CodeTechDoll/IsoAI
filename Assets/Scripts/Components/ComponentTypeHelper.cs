using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public static class ComponentTypeHelper
    {
        private static Dictionary<Type, int> componentTypeToIndex = new Dictionary<Type, int>();
        private static int maxComponentTypes = 0;

        public static int MaxComponentTypes => maxComponentTypes;

        public static int GetComponentIndex<T>() where T : YComponent
        {
            Type componentType = typeof(T);
            if (!componentTypeToIndex.TryGetValue(componentType, out int index))
            {
                index = maxComponentTypes;
                componentTypeToIndex.Add(componentType, index);
                maxComponentTypes++;
            }

            return index;
        }

        public static int GetComponentIndex(Type componentType)
        {
            if (!componentTypeToIndex.TryGetValue(componentType, out int index))
            {
                index = maxComponentTypes;
                componentTypeToIndex.Add(componentType, index);
                maxComponentTypes++;
            }

            return index;
        }
    }
}