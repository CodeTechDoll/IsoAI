using Assets.Scripts.Entities;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Events
{
    public class ChangeTurnEvent : GameEvent<(Entity Entity, int NewValue)>
    {
        public ChangeTurnEvent(Entity entity, int newValue) : base((entity, newValue))
        {
        }
    }
}