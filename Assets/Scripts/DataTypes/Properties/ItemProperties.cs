namespace Assets.Scripts.DataTypes.Properties
{
    public class ItemProperties
    {
        public Property<string> Name;
        public Property<StatsData> Stats;
        public ItemProperties()
        {
            Name = new Property<string>();
            Stats = new Property<StatsData>();
        }
    }
}