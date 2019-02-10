using UnityEngine;
using System;
using System.Collections;

namespace BuildBased
{
    public class WorldController : MonoBehaviour
    {

        public Sprite floorSprite;

        World world;

        // Use this for initialization
        private void Start()
        {
            //Create a world with Empty tiles
            world = new World();

            // Create a GameOBject for each of our  tiles. so they show visually.
            for (int x = 0; x < world.Width; x++)
            {
                for (int y = 0; y < world.Height; y++)
                {
                    Tile tile_data = world.GetTileAt(x, y);

                    GameObject tile_go = new GameObject();
                    tile_go.transform.parent = this.transform;
                    tile_go.name = "Tile_" + x + "_" + y;
                    tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);

                    // Add a sprite renderer, but don't bother setting a sprite
                    // because all the tiles are empty righ now
                    tile_go.AddComponent<SpriteRenderer>();

                    tile_data.RegisterTileTypeChangedCallback((tile) => { OnTileTypeChanged(tile, tile_go);});
                    /*
                     * ด้านบนคือการใช้ lampda เนื่องจากต้องส่ง OnTileTypeChange ให้แอคชั่น รีจีสไทต์เชน แต่
                     * แอคชั่นไม่รองรับ พารามิเตอร์เลย ทำงานผ่าน แลมดร้าอโนนี้มัส 
                     * 
                     * 
                     * 
                     * */
                }

            }

            world.RandomizeTiles();

        }

       

        private void Update()
        {
           


        }

        void OnTileTypeChanged(Tile tile_data,GameObject tile_go)
        {

            if (tile_data.Type == Tile.TileType.Floor)
            {
                tile_go.GetComponent<SpriteRenderer>().sprite = floorSprite;
            }
            else if (tile_data.Type == Tile.TileType.Empty)
            {
                tile_go.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                Debug.LogError("OnTileTypeChanged - Unrecognized tile type.");
            }
        }
    }
}