using Assets.Scripts.DataTypes.Properties;
using DataTypes;
using UnityEngine.Events;

namespace Managers
{
    public interface IManager<T, U> where T : DataObject<U> where U : class
    {
        event UnityAction<T> ObjectAdded;
        event UnityAction<T> ObjectRemoved;
        event UnityAction<T> ObjectChanged;

        void Add(T obj);
        void Remove(T obj);
        void HandleObjectChanged(DataObject<U> obj);
    }
}