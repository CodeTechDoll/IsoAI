using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using Assets.Scripts.Events;

namespace Assets.Scripts.Systems
{
    public class StatsSystem : BaseSystem
    {
        protected override bool MatchesEntity(Entity entity)
        {
            return entity.GetComponent<StatsComponent>() != null;
        }

        protected override void OnEntityAdded(Entity entity)
        {
            EventManager.Instance.Subscribe<ChangeStatEvent<int>>(OnChangeStatEvent);
        }

        protected override void OnEntityRemoved(Entity entity)
        {
            EventManager.Instance.Unsubscribe<ChangeStatEvent<int>>(OnChangeStatEvent);
        }

        private void OnChangeStatEvent(ChangeStatEvent<int> changeStatEvent)
        {
            var entity = changeStatEvent.Data.Entity;
            var propertyName = changeStatEvent.Data.PropertyName;
            var newValue = changeStatEvent.Data.NewValue;

            var statsComponent = GetComponent<StatsComponent>(entity);
            var property = statsComponent.GetType().GetProperty(propertyName);
            property.SetValue(statsComponent, newValue);
        }
    }
}