using DataTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class TileManager : ScriptableObject, IManager<TileData>
    {
        [SerializeField] private List<TileData> tiles;

        public void Add(TileData tile)
        {
            tiles.Add(tile);
            tile.Changed += HandleObjectChanged;
        }

        public void Remove(TileData tile)
        {
            tiles.Remove(tile);
            tile.Changed -= HandleObjectChanged;
        }

        public void HandleObjectChanged(TileData tile)
        {
            // Handle changes to the tile's state
        }

        public TileData GetTileById(string id)
        {
            return tiles.FirstOrDefault(tile => tile.Id.Value == id);
        }
    }
}