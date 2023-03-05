using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DataTypes.Properties
{
    public class UnitProperties 
    {
        [SerializeField] public Property<StatsData> StatsData;
        [SerializeField] public Property<string> Name;
    }
}