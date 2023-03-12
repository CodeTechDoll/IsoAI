using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class MovementSystem : BaseSystem
    {
        protected override bool MatchesEntity(Entity entity)
        {
            // Check if the entity has a TransformComponent and a MovementComponent
            return entity.HasComponent<TransformComponent>() && entity.HasComponent<MovementComponent>();
        }

        protected override void OnEntityAdded(Entity entity)
        {
            // Subscribe to the OnPositionChanged event of the entity's TransformComponent
            GetComponent<TransformComponent>(entity).OnPositionChanged += HandlePositionChanged;
        }

        protected override void OnEntityRemoved(Entity entity)
        {
            // Unsubscribe from the OnPositionChanged event of the entity's TransformComponent
            GetComponent<TransformComponent>(entity).OnPositionChanged -= HandlePositionChanged;
        }

        private void HandlePositionChanged(Transform position)
        {
            // Handle the entity's new position
            // ...
        }
    }
}