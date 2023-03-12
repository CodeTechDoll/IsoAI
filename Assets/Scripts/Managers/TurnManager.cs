using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using Assets.Scripts.Events;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class TurnManager : MonoBehaviour
    {
        private int _currentIndex = -1;

        private List<Entity> _entities = new List<Entity>();

        public void RegisterEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        public void UnregisterEntity(Entity entity)
        {
            _entities.Remove(entity);
        }

        public void StartTurns()
        {
            // Determine turn order and start turns
        }

        public void NextTurn()
        {
            if (_entities.Count == 0)
            {
                return;
            }

            _currentIndex++;
            if (_currentIndex >= _entities.Count)
            {
                _currentIndex = 0;
            }

            var currentEntity = _entities[_currentIndex];

            if (!currentEntity.HasComponent<TurnComponent>())
            {
                // Skip entities that don't have a TurnComponent.
                NextTurn();
                return;
            }

            var turnComponent = currentEntity.GetComponent<TurnComponent>();
            turnComponent.StartTurn();

            EventManager.Instance.Notify(new ChangeTurnEvent<int>(currentEntity, "Turn", turnComponent.Turns));
        }
    }

}