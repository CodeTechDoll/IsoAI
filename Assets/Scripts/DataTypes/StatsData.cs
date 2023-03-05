using Assets.Scripts.DataTypes.Properties;
using DataTypes;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DataTypes
{
    public class StatsData : DataObject<StatsProperties>
    {
        public StatsData(ID id) : base(id)
        {
            Properties = new StatsProperties();
        }
    }
}