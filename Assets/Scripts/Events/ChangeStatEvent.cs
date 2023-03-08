using Assets.Scripts.Entities;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class ChangeStatEvent<T> : GameEvent<(Entity Entity, string PropertyName, T NewValue)>
    {
        public ChangeStatEvent(Entity entity, string propertyName, T newValue) : base((entity, propertyName, newValue))
        {
        }
    }
}