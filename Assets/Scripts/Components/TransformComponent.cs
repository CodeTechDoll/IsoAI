using Assets.Scripts.DataTypes.Properties;
using System;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class TransformComponent : YComponent
    {
        readonly Property<Transform> Transform;

        public TransformComponent()
        {
            Transform = new Property<Transform>(null);
        }

        public Action<Vector3> OnPositionChanged { get; internal set; }
    }
}