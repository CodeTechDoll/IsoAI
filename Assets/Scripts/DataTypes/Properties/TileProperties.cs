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

    
    /**
  "Changed": null,
  "Properties": {
    "Position": {
      "Value": {
        "x": 1.0,
        "y": 2.0,
        "z": 3.0
      }
    },
    "Height": {
    "Value": 10
    },
    "Visible": {
    "Value": true
    },
    "Passable": {
    "Value": false
    },
    "TileSprite": {
    "Value": null
    }
  },
  "Id": {
    "Value": 2
  },
  "name": "",
  "hideFlags": 0
   
}
    */
}