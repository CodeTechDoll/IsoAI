using System;

namespace Assets.Scripts.DataTypes.Properties
{
    [Serializable]
    public class Property<T>
    {
        public T Value { get; set; }
        public Property()
        {
            Value = default(T);
        }

        public Property(T value)
        {
            Value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.Value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T> { Value = value };
        }
    }
}