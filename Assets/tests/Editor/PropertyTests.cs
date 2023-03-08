using Assets.Scripts.DataTypes.Properties;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Assets.tests.Editor
{
    public class PropertyTests
    {
        [Test]
        public void DefaultValue_Is_Default()
        {
            var property = new Property<int>();
            Assert.AreEqual(default(int), property.Value);
        }

        [Test]
        public void Value_Can_Be_Set_And_Retrieved()
        {
            var property = new Property<int>();
            property.Value = 42;
            Assert.AreEqual(42, property.Value);
        }

        [Test]
        public void Implicit_Conversion_To_Value_Type_Works()
        {
            var property = new Property<int>(42);
            int value = property;
            Assert.AreEqual(42, value);
        }

        [Test]
        public void Implicit_Conversion_From_Value_Type_Works()
        {
            Property<int> property = 42;
            Assert.AreEqual(42, property.Value);
        }
    }
}