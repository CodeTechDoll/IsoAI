using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using Assets.Scripts.Events;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class TurnSystem : BaseSystem
    {
        protected override bool MatchesEntity(Entity entity)
        {
            return entity.GetComponent<TurnComponent>() != null;
        }

         
        protected override void OnEntityAdded(Entity entity)
        {
            EventManager.Instance.Subscribe<ChangeTurnEvent>(OnChangeTurnEvent);
        }

        protected override void OnEntityRemoved(Entity entity)
        {
            EventManager.Instance.Unsubscribe<ChangeTurnEvent>(OnChangeTurnEvent);
        }

        private void OnChangeTurnEvent(ChangeTurnEvent changeTurnEvent)
        {
            var entity = changeTurnEvent.Data.Entity;
            var newValue = changeTurnEvent.Data.NewValue;

            var turnComponent = GetComponent<TurnComponent>(entity);
            turnComponent.TurnOrder = newValue;
        }
    }
}