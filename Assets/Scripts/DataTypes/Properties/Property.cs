using System;

namespace Assets.Scripts.DataTypes.Properties
{
    [Serializable]
    public struct Property<T>
    {
        public T Value { get; set; }
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