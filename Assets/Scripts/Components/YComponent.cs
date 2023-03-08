using Assets.Scripts.Entities;
using Assets.Scripts.Systems;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public abstract class YComponent : MonoBehaviour
    {
        public Entity Entity { get; private set; }

        public virtual void OnAddedToEntity()
        {
        }

        public virtual void OnRemovedFromEntity()
        {
        }

        internal void SetEntity(Entity entity)
        {
            Entity = entity;
            OnAddedToEntity();
        }

        internal void ClearEntity()
        {
            OnRemovedFromEntity();
            Entity = null;
        }
    }
}