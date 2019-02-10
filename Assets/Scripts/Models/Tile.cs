
using System;
using UnityEngine;

namespace BuildBased
{
    public class Tile
    {
        public enum TileType { Empty, Floor };

        TileType type = TileType.Empty;

        Action<Tile> cbTileTypeChanged;
        GameObject myVisualTileGameObject;

        public TileType Type {
            get => type;
            set
            {
                TileType oldType = type;
                type = value;
                // Call the callback and let things know we've changed.

                if(cbTileTypeChanged != null && oldType != type)
                    cbTileTypeChanged(this);
            }
            
        }

       
        public int X { get => x; }
        public int Y { get => y;  }

        LooseObject LooseObject;
        InstalledObject installedObject;

        World world;
        int x;
        int y;

        public Tile(World world,int x,int y)
        {
            this.world = world;
            this.x = x;
            this.y = y;
        }

        public void RegisterTileTypeChangedCallback(Action<Tile> callback)
        {
            cbTileTypeChanged += callback;
        }

        public void UnRegisterTileTypeChagedCallback(Action<Tile> callback)
        {
            cbTileTypeChanged -= callback;
        }
    }
}