using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.DataTypes.Properties
{
    [Serializable]
    public class StatsProperties
    {
        public Property<int> Health;
        public Property<int> Mana;
        public Property<int> Lewdness;

        public StatsProperties() {
            Health = new Property<int>();
            Mana = new Property<int>();
            Lewdness = new Property<int>();
        }
    }
}