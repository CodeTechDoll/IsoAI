using Assets.Scripts.DataFlow;
using Assets.Scripts.DataTypes;
using Assets.Scripts.DataTypes.Properties;
using DataTypes;
using Managers;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private TileManager _tileManager;
        private UnitManager _unitManager;
        private ItemManager _itemManager;
        private DataManager<TileData, TileProperties> _tileDataManager;

        private void Start()
        {
            _tileManager = new TileManager();
            _unitManager = new UnitManager();

            TestObject testObject = TestObject.CreateInstance();
            Debug.Log(testObject.ToString());

            // Create a new TileData object
            var tile = DataObject<TileProperties>.CreateInstance<TileData>();
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
            _tileDataManager = new DataManager<TileData, TileProperties>(serializer);
            _tileDataManager.Add(tile);
            _tileDataManager.Save();
            string json = serializer.Serialize(tile);

            // Deserialize the JSON back into a TileData object
            TileData deserializedTile = serializer.Deserialize(json);
            // Verify that the deserialized TileData object is equal to the original
            bool isEqual = tile.Equals(deserializedTile); // should be true
            Debug.Log("-------------------JSON-------------------");

            Debug.Log(json);
            Debug.Log("-------------------DST--------------------");
            Debug.Log(deserializedTile);
            Debug.Log("-------------------------------------------");
            Debug.Log("isEqual: " + isEqual);
        }
    }

    public class TestObject: ScriptableObject
    {
        ID id = new ID();
        public static TestObject CreateInstance()
        {
            return ScriptableObject.CreateInstance<TestObject>();
        }
    }
}