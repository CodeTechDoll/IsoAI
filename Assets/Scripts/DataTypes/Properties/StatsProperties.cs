using System;

namespace Assets.Scripts.DataTypes.Properties
{
    [Serializable]
    public class StatsProperties
    {
        public Property<int> Health;
        public Property<int> Mana;
        public Property<int> Lewdness;
        public Property<int> Strength;

        public StatsProperties() {
            Health = new Property<int>();
            Mana = new Property<int>();
            Lewdness = new Property<int>();
            Strength = new Property<int>(10);
        }
    }
}