using Assets.Scripts.Components;
using Assets.Scripts.Entities;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace Assets.Editor.Tests
{
    public class ExampleComponent : YComponent
    {
    }

    public class EntityTests
    {
        private Entity entity;
        private IDGenerator idGenerator;

        [SetUp]
        public void SetUp()
        {
            idGenerator = new IDGenerator();
            entity = new Entity(idGenerator);
        }

        [Test]
        public void AddComponent_ComponentIsAdded()
        {
            var exampleComponent = new ExampleComponent();
            entity.AddComponent(exampleComponent);

            Assert.IsTrue(entity.HasComponent<ExampleComponent>());
        }

        [Test]
        public void GetComponent_ComponentIsReturned()
        {
            var exampleComponent = new ExampleComponent();
            entity.AddComponent(exampleComponent);

            var retrievedComponent = entity.GetComponent<ExampleComponent>();

            Assert.AreEqual(exampleComponent, retrievedComponent);
        }

        [Test]
        public void GetComponent_NonexistentComponentReturnsNull()
        {
            var retrievedComponent = entity.GetComponent<ExampleComponent>();

            Assert.IsNull(retrievedComponent);
        }

        [Test]
        public void HasComponent_ComponentExists()
        {
            var exampleComponent = new ExampleComponent();
            entity.AddComponent(exampleComponent);

            var hasComponent = entity.HasComponent<ExampleComponent>();

            Assert.IsTrue(hasComponent);
        }

        [Test]
        public void HasComponent_NonexistentComponentReturnsFalse()
        {
            var hasComponent = entity.HasComponent<ExampleComponent>();

            Assert.IsFalse(hasComponent);
        }

        [Test]
        public void RemoveComponent_ComponentIsRemoved()
        {
            var exampleComponent = new ExampleComponent();
            entity.AddComponent(exampleComponent);

            entity.RemoveComponent<ExampleComponent>();

            Assert.IsFalse(entity.HasComponent<ExampleComponent>());
        }

        [Test]
        public void GetComponents_ReturnsAllComponentsOfType()
        {
            var component1 = new ExampleComponent();
            entity.AddComponent(component1);

            var component2 = new ExampleComponent();
            entity.AddComponent(component2);

            var retrievedComponents = entity.GetComponents<ExampleComponent>().ToList();
            var list = new System.Collections.Generic.List<ExampleComponent>() { component2 };
            CollectionAssert.AreEqual(list, retrievedComponents);

        }

        [Test]
        public void GetComponents_ReturnsEmptyListWhenNoComponentsOfType()
        {
            var retrievedComponents = entity.GetComponents<ExampleComponent>();

            Assert.IsEmpty(retrievedComponents);
        }
    }

}