using Assets.Scripts.DataFlow;
using Assets.Scripts.DataTypes;
using Assets.Scripts.DataTypes.Properties;
using DataTypes;
using Managers;

using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private TileManager _tileManager;
        private UnitManager _unitManager;
        private ItemManager _itemManager;

        private void Start()
        {
            _tileManager = new TileManager();
            _unitManager = new UnitManager();

            // Create a new TileData object
            TileData tile = ScriptableObject.CreateInstance<TileData>();
            tile.Properties = new TileProperties
            {
                Position = new Property<Vector3>(new Vector3(1, 2, 3)),
                Height = new Property<int>(10),
                Visible = new Property<bool>(true),
                Passable = new Property<bool>(false),
                TileSprite = new Property<Sprite>(null)
            };

            // Serialize the TileData object to JSON
            var serializer = new JsonDataSerializer<TileData, TileProperties>();
            string json = serializer.Serialize(tile);

            // Deserialize the JSON back into a TileData object
            TileData deserializedTile = serializer.Deserialize(json);
            // Verify that the deserialized TileData object is equal to the original
            bool isEqual = tile.Equals(deserializedTile); // should be true
        }
    }
}