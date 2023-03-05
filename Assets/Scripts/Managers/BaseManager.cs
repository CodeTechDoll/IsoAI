using Assets.Scripts.DataTypes;
using DataTypes;
using System.Collections.Generic;

namespace Managers
{

    public abstract class BaseManager<T> : IManager<T> where T : DataObject<T>
    {
        protected Dictionary<int, T> objects;

        public BaseManager()
        {
            objects = new Dictionary<int, T>();
            StatsData statsData = new StatsData(new ID());
        }

        public virtual void Add(T obj)
        {
            objects[obj.Id] = obj;
            obj.Changed += HandleObjectChanged;
        }

        public virtual void Remove(T obj)
        {
            objects.Remove(obj.Id);
            obj.Changed -= HandleObjectChanged;
        }

        public virtual void HandleObjectChanged(T obj)
        {
            ObjectChanged?.Invoke(obj);
        }
    }
}


