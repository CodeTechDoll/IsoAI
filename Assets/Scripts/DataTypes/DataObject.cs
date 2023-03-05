using Assets.Scripts.DataFlow;
using Assets.Scripts.DataTypes.Properties;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace DataTypes
{
    public abstract class DataObject<T> : ScriptableObject where T : class
    {
        [SerializeField] private ID id = new();
        [SerializeField] private T properties;
        public UnityEvent<DataObject<T>> Changed; // Event that triggers when this object is updated

        public DataObject(ID id)
        {
            Id = id;
            Properties = Activator.CreateInstance<T>();
        }

        public T Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public ID Id
        {
            get { return id; }
            set { id = value; }
        }

        protected void NotifyObjectChanged()
        {
            Changed.Invoke(this);
        }

        public virtual U GetProperty<U>(Expression<Func<T, Property<U>>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo != null)
                {
                    return ((Property<U>)propertyInfo.GetValue(Properties)).Value;
                }
            }
            return default;
        }

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
                    NotifyObjectChanged();
                }
            }
        }


        public virtual string Serialize()
        {
            return JsonUtility.ToJson(this);
        }

        public virtual void Deserialize(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}