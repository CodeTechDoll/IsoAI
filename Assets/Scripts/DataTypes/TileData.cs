using Assets.Scripts.DataTypes.Properties;

namespace DataTypes
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "NewTileData", menuName = "TileData")]
    public class TileData : DataObject<TileProperties>
    {
        public TileData(ID id) : base(id) {
            Properties = new TileProperties();
        }

        public Sprite Sprite
        {
            get => GetProperty(x => x.TileSprite);

            set => SetProperty(x => x.TileSprite, value);
        }

        public Vector3 Position
        {
            get => GetProperty(x => x.Position);
            set => SetProperty(x => x.Position, value);
        }

        public int Height
        {
            get => GetProperty(x => x.Height);
            set => SetProperty(x => x.Height, value);
        }

        public bool Visible
        {
            get => GetProperty(x => x.Visible);
            set => SetProperty(x => x.Visible, value);
        }

        public bool Passable
        {
            get => GetProperty(x => x.Passable);
            set => SetProperty(x => x.Passable, value);
        }
    }
}