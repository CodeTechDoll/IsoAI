using Assets.Scripts.DataTypes.Properties;

namespace DataTypes
{
    using Assets.Scripts.DataFlow;
    using Newtonsoft.Json;
    using UnityEngine;

    [CreateAssetMenu(fileName = "NewTileData", menuName = "TileData")]
    public class TileData : DataObject<TileProperties>
    {

    }
}