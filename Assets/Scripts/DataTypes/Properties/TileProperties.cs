using System;
using UnityEngine;

namespace Assets.Scripts.DataTypes.Properties
{
    [Serializable]
    public class TileProperties
    {
        public Property<Vector3> Position;
        public Property<int> Height;
        public Property<Boolean> Visible;
        public Property<Boolean> Passable;
        public Property<Sprite> TileSprite;

        public TileProperties() { 
            Position = new Property<Vector3>();
            Height = new Property<int>();
            Visible = new Property<Boolean>();
            Passable = new Property<Boolean>();
            TileSprite = new Property<Sprite>();
        }
    }
}