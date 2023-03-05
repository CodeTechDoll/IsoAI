using Assets.Scripts.DataTypes.Properties;
using DataTypes;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DataTypes
{
    public class UnitData : DataObject<UnitProperties>
    {
        public UnitData(ID id) : base(id)
        {
        }
    }
}