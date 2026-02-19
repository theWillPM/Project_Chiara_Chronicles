using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class CollisionChecker
    {
    public GameScreen gs;

        public CollisionChecker(GameScreen gs)
        {
            this.gs = gs;
        }
        public void CheckTileCollision(Entity e)
        {
            // Identify the player's surrounding tiles:
            int leftTileColumn =    (e.WorldX - e.ScreenX + e.BoundingBox.Left)     / MapTile.tileSize;
            int rightTileColumn =   (e.WorldX - e.ScreenX + e.BoundingBox.Right)    / MapTile.tileSize;
            int topTileRow =        (e.WorldY - e.ScreenY + e.BoundingBox.Top)      / MapTile.tileSize;
            int downTileRow =       (e.WorldY - e.ScreenY + e.BoundingBox.Bottom)   / MapTile.tileSize;

            int entityTop =     e.WorldY - e.ScreenY + e.BoundingBox.Top;
            int entityBottom =  e.WorldY - e.ScreenY + e.BoundingBox.Bottom;
            int entityRight =   e.WorldX - e.ScreenX + e.BoundingBox.Right;
            int entityLeft =    e.WorldX - e.ScreenX + e.BoundingBox.Left;

            int tile1, tile2;

            // Check the two tiles closest to the player's bounding box edges. (Basically check if the shoulders can fit through)
            switch(e.Direction)
            {
                case "up":
                    topTileRow = (entityTop - e.Speed) / MapTile.tileSize;
                    tile1 = gs.gameMap.mapData[topTileRow,leftTileColumn];
                    tile2 = gs.gameMap.mapData[topTileRow,rightTileColumn];
                    if (MapTile.TileSet[tile1].collision == true || MapTile.TileSet[tile2].collision == true)
                        e.isColliding = true;
                    break;
                case "down":
                    downTileRow = (entityBottom + e.Speed) / MapTile.tileSize;
                    tile1 = gs.gameMap.mapData[downTileRow, leftTileColumn];
                    tile2 = gs.gameMap.mapData[downTileRow, rightTileColumn];
                    if (MapTile.TileSet[tile1].collision == true || MapTile.TileSet[tile2].collision == true)
                        e.isColliding = true;
                    break;
                case "left":
                    leftTileColumn = (entityLeft - e.Speed) / MapTile.tileSize;
                    tile1 = gs.gameMap.mapData[topTileRow, leftTileColumn];
                    tile2 = gs.gameMap.mapData[downTileRow, leftTileColumn];
                    if (MapTile.TileSet[tile1].collision == true || MapTile.TileSet[tile2].collision == true)
                        e.isColliding = true;
                    break;
                case "right":
                    rightTileColumn = (entityRight + e.Speed) / MapTile.tileSize;
                    tile1 = gs.gameMap.mapData[topTileRow, rightTileColumn];
                    tile2 = gs.gameMap.mapData[downTileRow, rightTileColumn];
                    if (MapTile.TileSet[tile1].collision == true || MapTile.TileSet[tile2].collision == true)
                        e.isColliding = true;
                    break;
            }
        }
 
    }
}
