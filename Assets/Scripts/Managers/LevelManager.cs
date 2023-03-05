using Assets.Scripts.DataTypes.Properties;
using Assets.Scripts.DataTypes;
using Managers;
using UnityEditor;
using UnityEngine;
using DataTypes;

namespace Assets.Scripts.Managers
{
    public class LevelManager : ScriptableObject
    {
        [SerializeField] private TileManager tileManager;
        [SerializeField] private UnitManager unitManager;

        public void GenerateLevel()
        {
            // Generate and populate tileManager and unitManager as necessary
            // For example:
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var tile = ScriptableObject.CreateInstance<TileData>();
                    tile.Properties = new TileProperties
                    {
                        Position = new Property<Vector3>(new Vector3(i, j)),
                        Height = new Property<int>(0),
                        Visible = new Property<bool>(true),
                        Passable = new Property<bool>(true),
                        TileSprite = new Property<Sprite>(null)
                    };
                    tileManager.Add(tile);
                }
            }

            var player = ScriptableObject.CreateInstance<UnitData>();

            unitManager.Add(player);

            var enemy = ScriptableObject.CreateInstance<UnitData>();
            enemy.Properties = new UnitProperties
            {

                Name = new Property<string>("Enemy")
            };
            unitManager.Add(enemy);
        }

        public void RenderLevel()
        {
            // Render the level by populating UI elements with data from tileManager and unitManager
        }
    }
}