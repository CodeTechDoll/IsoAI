using Assets.Scripts.DataTypes.Events;
using Assets.Scripts.Managers;
using DataTypes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{

    public abstract class BaseManager<T, U> : IManager<T, U> where T : DataObject<U> where U : class
    {
        protected Dictionary<int, T> objects;

        public BaseManager()
        {
            objects = new Dictionary<int, T>();
        }
        public virtual void Add(T obj)
        {
            objects[obj.Id] = obj;
            obj.Changed.AddListener(HandleObjectChanged);
            ObjectAdded?.Invoke(obj);
        }
        public virtual void Remove(T obj)
        {
            objects.Remove(obj.Id);
            obj.Changed.RemoveListener(HandleObjectChanged);
            ObjectRemoved?.Invoke(obj);
        }
        public virtual void HandleObjectChanged(DataObject<U> obj)
        {
            ObjectChanged?.Invoke(obj as T);
        }

        public event UnityAction<T> ObjectAdded;
        public event UnityAction<T> ObjectRemoved;
        public event UnityAction<T> ObjectChanged;
    }
}


