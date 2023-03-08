using Assets.Scripts.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using YComponent = Assets.Scripts.Components.YComponent;

namespace Assets.Scripts.Systems
{
    public abstract class BaseSystem : MonoBehaviour
    {
        private List<Entity> entities;
        private SystemManager systemManager;

        [Inject]
        public void Construct(SystemManager systemManager)
        {
            this.systemManager = systemManager;
        }

        public void RegisterEntity(Entity entity)
        {
            if (MatchesEntity(entity))
            {
                entities.Add(entity);
                OnEntityAdded(entity);
            }
        }

        public void UnregisterEntity(Entity entity)
        {
            if (entities.Remove(entity))
            {
                OnEntityRemoved(entity);
            }
        }

        protected abstract bool MatchesEntity(Entity entity);
        protected virtual void OnEntityAdded(Entity entity) { }
        protected virtual void OnEntityRemoved(Entity entity) { }

        protected void ForEachEntity(Action<Entity> action)
        {
            foreach (var entity in entities)
            {
                action(entity);
            }
        }

        protected T GetComponent<T>(Entity entity) where T : YComponent
        {
            return entity.GetComponent<T>();
        }

        public virtual void Update()
        {
            // This will be overridden by the derived classes
        }

        private void Start()
        {
            entities = new List<Entity>();
            systemManager.RegisterSystem(this);
        }
    }
}