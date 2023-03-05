using Assets.Scripts.DataTypes.Properties;
using DataTypes;

namespace Assets.Scripts.DataTypes
{
    public class StatsData : DataObject<StatsProperties>
    {
        public StatsData()
        {
            Properties = new StatsProperties();
        }
    }
}