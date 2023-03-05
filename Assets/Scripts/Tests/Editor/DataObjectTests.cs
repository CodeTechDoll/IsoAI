using NUnit.Framework;
using UnityEngine;

namespace Assets.Scripts.Tests.Editor
{

    public class DataObjectTests
    {

        [Test]
        public void Properties_SetAndGet_Success()
        {
            // Arrange
            var dataObject = ScriptableObject.CreateInstance<DataObject<TestProperties>>();
            dataObject.Properties = new TestProperties();

            // Act
            dataObject.SetProperty(x => x.MyProperty, 42);
            var value = dataObject.GetProperty(x => x.MyProperty);

            // Assert
            Assert.AreEqual(42, value);
        }

        [Test]
        public void Serialize_Deserialize_Success()
        {
            // Arrange
            var dataObject = ScriptableObject.CreateInstance<DataObject<TestProperties>>();
            dataObject.Properties = new TestProperties();
            dataObject.SetProperty(x => x.MyProperty, 42);

            // Act
            var json = dataObject.Serialize();
            var deserializedObject = ScriptableObject.CreateInstance<DataObject<TestProperties>>();
            deserializedObject.Deserialize(json);

            // Assert
            Assert.AreEqual(42, deserializedObject.GetProperty(x => x.MyProperty));
        }

        public class TestProperties
        {
            public Property<int> MyProperty = new Property<int>();
        }
    }
}