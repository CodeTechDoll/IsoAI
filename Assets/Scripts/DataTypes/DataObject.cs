using Assets.Scripts.DataFlow;
using Assets.Scripts.DataTypes.Properties;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace DataTypes
{
    [CreateAssetMenu(fileName = "NewDataObject", menuName = "Data Object")]
    public class DataObject<TProperties> : ScriptableObject where TProperties : class
    {
        [SerializeField] private ID id = new();
        [SerializeField] private TProperties properties;
        public UnityEvent<DataObject<TProperties>> Changed; // Event that triggers when this object is updated
        public static new T CreateInstance<T>() where T : DataObject<TProperties>, new()
        {
            var obj = ScriptableObject.CreateInstance<T>();
            obj.Initialize();
            return obj;
        }

        public void Initialize()
        {
            Properties = Activator.CreateInstance<TProperties>();
            Changed = new UnityEvent<DataObject<TProperties>>();
        }


        public TProperties Properties
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

        public virtual U GetProperty<U>(Expression<Func<TProperties, Property<U>>> propertyExpression)
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

        public virtual void SetProperty<U>(Expression<Func<TProperties, Property<U>>> propertyExpression, U value)
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

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}