using Assets.Scripts.DataTypes.Properties;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class TurnComponent : YComponent
    {
        public Property<int> TurnOrder { get; set; }

        private void Awake()
        {
            TurnOrder = new Property<int>(0);
        }
    }
}