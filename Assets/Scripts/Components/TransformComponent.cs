using Assets.Scripts.DataTypes.Properties;
using System;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class TransformComponent : YComponent
    {
        private Property<Transform> Transform;

        public override void OnAddedToEntity()
        {
            Transform = new Property<Transform>(null);
            base.OnAddedToEntity();
        }

        public Action<Transform> OnPositionChanged { get; internal set; }
    }
}