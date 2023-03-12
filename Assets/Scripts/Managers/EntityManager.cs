using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Scripts.Managers
{
    public class EntityManager
    {
        private Dictionary<int, Entity> entities = new Dictionary<int, Entity>();
        [Inject]
        private IDGenerator iDGenerator;


        public Entity CreateEntity()
        {
            var entity = new Entity(iDGenerator);
            entities[entity.Id] = entity;
            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
            entities.Remove(entity.Id);
        }

        public Entity GetEntityById(int id) { 
            if(entities.TryGetValue(id, out var entity)) return entity;
            return null;
        }

        public IEnumerable<Entity> GetAllEntities() { return entities.Values; }

        public IEnumerable<Entity> GetEntitiesWithComponents(params Type[] componentTypes)
        {
            // Create a bitset for the component types
            var bitset = new BitArray(ComponentTypeHelper.MaxComponentTypes);
            foreach (var componentType in componentTypes)
            {
                bitset.Set(ComponentTypeHelper.GetComponentIndex(componentType), true);
            }

            // Filter the entities by the bitset
            foreach (var entity in entities.Values)
            {
                bool hasComponents = true;
                foreach (var kvp in entity.Components)
                {
                    int componentIndex = ComponentTypeHelper.GetComponentIndex(kvp.Key);
                    if (!bitset.Get(componentIndex))
                    {
                        hasComponents = false;
                        break;
                    }
                }

                if (hasComponents)
                {
                    yield return entity;
                }
            }
        }
    }
}