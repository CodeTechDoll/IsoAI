using NUnit.Framework;
using Assets.Scripts.Components;
using System;


namespace Assets.tests.Editor
{
   
    public class ComponentTypeHelperTests
    {
        [Test]
        public void GetComponentIndex_ReturnsCorrectIndex()
        {
            // Arrange
            var componentType1 = typeof(Component1);
            var componentType2 = typeof(Component2);

            // Act
            var index1 = ComponentTypeHelper.GetComponentIndex<Component1>();
            var index2 = ComponentTypeHelper.GetComponentIndex<Component2>();

            // Assert
            Assert.AreEqual(0, index1);
            Assert.AreEqual(1, index2);
        }

        [Test]
        public void GetComponentIndex_ReturnsSameIndexForSameComponentType()
        {
            // Arrange
            var componentType = typeof(Component1);

            // Act
            var index1 = ComponentTypeHelper.GetComponentIndex<Component1>();
            var index2 = ComponentTypeHelper.GetComponentIndex<Component1>();

            // Assert
            Assert.AreEqual(index1, index2);
        }

        [Test]
        public void GetComponentIndex_AddsNewComponentType()
        {
            // Arrange
            var componentType1 = typeof(Component1);
            var componentType2 = typeof(Component2);

            // Act
            var index1 = ComponentTypeHelper.GetComponentIndex<Component1>();
            var index2 = ComponentTypeHelper.GetComponentIndex<Component2>();
            var index3 = ComponentTypeHelper.GetComponentIndex<Component3>();

            // Assert
            Assert.AreEqual(0, index1);
            Assert.AreEqual(1, index2);
            Assert.AreEqual(2, index3);
        }

        [Test]
        public void GetComponentIndex_NullComponentType_ThrowsException()
        {
            // Arrange
            Type componentType = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ComponentTypeHelper.GetComponentIndex(componentType));
        }

        private class Component1 : YComponent { }
        private class Component2 : YComponent { }
        private class Component3 : YComponent { }
    }
}