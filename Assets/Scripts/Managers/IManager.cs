using DataTypes;

namespace Managers
{
    public interface IManager<T> where T : DataObject<T>
    {
        void Add(T obj);
        void Remove(T obj);
        public virtual void HandleObjectChanged(T obj)
        {
            // Handle changes to the object's state
        }    
    }
}