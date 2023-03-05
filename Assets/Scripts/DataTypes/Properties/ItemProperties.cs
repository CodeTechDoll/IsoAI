using System.Collections;
using UnityEngine;

namespace Assets.Scripts.DataTypes.Properties
{
    public class ItemProperties
    {
        public Property<string> Name;
        public Property<StatsData> Stats;
        public Property<TileData> Tile;
        public ItemProperties()
        {//...//}
        }
    }