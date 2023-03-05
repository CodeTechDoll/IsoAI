using Assets.Scripts.DataTypes.Properties;
using DataTypes;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DataTypes
{
    public class ItemData : DataObject<ItemProperties>
    {
        public ItemData(ID id) : base(id)
        {
        }
    }
}