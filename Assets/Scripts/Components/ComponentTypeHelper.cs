using System;
using System.Collections.Generic;

namespace Assets.Scripts.Components
{
    public static class ComponentTypeHelper
    {
        private static readonly Dictionary<Type, int> componentTypeToIndex = new Dictionary<Type, int>();

        public static int MaxComponentTypes { get; private set; } = 0;

        public static int GetComponentIndex<T>() where T : YComponent
        {
            Type componentType = typeof(T);
            if (!componentTypeToIndex.TryGetValue(componentType, out int index))
            {
                index = MaxComponentTypes;
                componentTypeToIndex.Add(componentType, index);
                MaxComponentTypes++;
            }

            return index;
        }

        public static int GetComponentIndex(Type componentType)
        {
            if (!componentTypeToIndex.TryGetValue(componentType, out int index))
            {
                index = MaxComponentTypes;
                componentTypeToIndex.Add(componentType, index);
                MaxComponentTypes++;
            }

            return index;
        }
    }
}