using Assets.Scripts.DataTypes.Properties;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

namespace DataTypes
{
    public abstract class DataObject<T> : ScriptableObject, IEquatable<DataObject<T>> where T : class
    {
        public ID Id { get; private set; } // The unique identifier for this DataObject instance
        public event Action<DataObject<T>> Changed; // Event that triggers when this object is updated
        public T Properties { get; protected set; } // Properties of this object

        public DataObject(ID id) { Initialize(id ?? new ID()); }
        public void Initialize(ID id)
        {
            Id = id; // Set the unique identifier
            Properties = Activator.CreateInstance<T>(); // Initialize the properties object
        }


        // Get the value of a property of this object
        public virtual U GetProperty<U>(Expression<Func<T, Property<U>>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo != null)
                {
                    return (U)((Property<U>)propertyInfo.GetValue(Properties));
                }
            }
            return default;
        }

        // Set a property of this object to a given value
        public virtual void SetProperty<U>(Expression<Func<T, Property<U>>> propertyExpression, U value)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo != null)
                {
                    dynamic propValue = propertyInfo.GetValue(Properties);
                    propValue.value = value;
                    propertyInfo.SetValue(Properties, propValue);
                    NotifyChanged();
                }
            }
        }

        // Notify any subscribers of this object's update
        protected void NotifyChanged()
        {
            Changed?.Invoke(this);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DataObject<T>);
        }

        public bool Equals(DataObject<T> other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   name == other.name &&
                   EqualityComparer<ID>.Default.Equals(Id, other.Id) &&
                   EqualityComparer<T>.Default.Equals(Properties, other.Properties);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), name, Id, Properties);
        }

        public static bool operator ==(DataObject<T> left, DataObject<T> right)
        {
            return EqualityComparer<DataObject<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(DataObject<T> left, DataObject<T> right)
        {
            return !(left == right);
        }
    }
}