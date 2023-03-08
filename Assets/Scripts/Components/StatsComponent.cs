using Assets.Scripts.DataTypes.Properties;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class StatsComponent : YComponent
    {
        public Property<int> Health { get; set; }
        public Property<int> MaxHealth { get; set; }
        public Property<int> Attack { get; set; }
        public Property<int> Defense { get; set; }

        private void Awake()
        {
            Health = new Property<int>(100);
            MaxHealth = new Property<int>(100);
            Attack = new Property<int>(10);
            Defense = new Property<int>(5);
        }
    }
}