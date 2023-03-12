using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using Assets.Scripts.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using Zenject;
[assembly: InternalsVisibleTo("Tests")]

namespace Assets.Scripts.Systems
{
    public class TurnSystem : BaseSystem
    {
        public List<Entity> turnOrder = new List<Entity>();
        public int currentTurnIndex = 0;
        public Entity currentActor;
        [Inject]
        private readonly EntityManager entityManager;

        protected override bool MatchesEntity(Entity entity)
        {
            return entity.HasComponent<TurnComponent>();
        }

        protected override void OnEntityAdded(Entity entity)
        {
            if (currentActor == null)
            {
                currentActor = entity;
                currentActor.GetComponent<TurnComponent>().StartTurn();
            }
            turnOrder.Add(entity);
        }

        protected override void OnEntityRemoved(Entity entity)
        {
            if (entity == currentActor)
            {
                currentActor = null;
            }
            turnOrder.Remove(entity);
        }

        public void EndTurn()
        {
            var currentTurnComponent = currentActor.GetComponent<TurnComponent>();
            currentTurnComponent.EndTurn();
            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
            currentActor = turnOrder[currentTurnIndex];
            currentActor.GetComponent<TurnComponent>().StartTurn();
        }

        private void SortTurnOrder()
        {
            turnOrder.Sort((entity1, entity2) => {
                var stats1 = entity1.GetComponent<StatsComponent>();
                var stats2 = entity2.GetComponent<StatsComponent>();
                return stats2.Dexterity.Value.CompareTo(stats1.Dexterity.Value);
            });
        }

        private Entity FindNextActor()
        {
            // Find all entities with TurnComponent and StatsComponent
            var entities = entityManager.GetEntitiesWithComponents(typeof(TurnComponent));

            // Sort entities by speed
            entities = entities.OrderByDescending(entity => entity.GetComponent<StatsComponent>().Dexterity.Value);

            // Find the first entity that hasn't taken a turn yet
            foreach (var entity in entities)
            {
                var turnComponent = entity.GetComponent<TurnComponent>();
                if (!turnComponent.HasTakenTurn)
                {
                    return entity;
                }
            }

            // If all entities have taken a turn, reset the turn flag and return the first entity
            foreach (var entity in entities)
            {
                var turnComponent = entity.GetComponent<TurnComponent>();
                turnComponent.ResetTurn();
            }

            return entities.FirstOrDefault();
        }
    }
}