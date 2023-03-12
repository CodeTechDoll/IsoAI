using Assets.Scripts.DataTypes.Properties;
using Unity.VisualScripting;

namespace Assets.Scripts.Components
{
    public class StatsComponent : MessageableComponent
    {
        public Property<int> Health { get; set; }
        public Property<int> MaxHealth { get; set; }
        public Property<int> Strength { get; set; }
        public Property<int> Dexterity { get; set; }
        public Property<int> Constitution { get; set; }
        public Property<int> Intelligence { get; set; }
        public Property<int> Willpower { get; set; }
        public Property<int> Charisma { get; set; } 
        

        public override void OnAddedToEntity()
        {
            Health = new Property<int>(20);
            MaxHealth = new Property<int>(20);
            Strength = new Property<int>(10);
            Dexterity = new Property<int>(10);
            Constitution = new Property<int>(10);
            Intelligence = new Property<int>(10);
            Willpower = new Property<int>(10);
            Charisma = new Property<int>(10);
            base.OnAddedToEntity();
        }

        public override void OnRemovedFromEntity()
        {
            base.OnRemovedFromEntity();
        }   
    }
}