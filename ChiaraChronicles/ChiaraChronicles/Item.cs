using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ChiaraChronicles
{
    /// <summary>
    /// Item - 
    /// </summary>
    class Item
    {
        Audio ItemSoundEffect = new Audio();

        public int ScreenX { 
            get {
                return WorldX - GameScreen.gs.player.WorldX + GameScreen.gs.player.ScreenX;
            }
            set {
                ScreenX = value;
            } 
        }
        public int ScreenY
        {
            get
            {
                return WorldY - GameScreen.gs.player.WorldY + GameScreen.gs.player.ScreenY;
            }
            set
            {
                ScreenY = value;
            }
        }
        public int WorldX;
        public int WorldY;
        public string Name = "Item";
        public int Width { get; set; } = 64;
        public int Height { get; set; } = 64;
        public bool IsCollected { get; set; }
        public bool isCollectible = true;
        public Image img;

        public Item()
        {

        }
        public Item(int x, int y, Image img)
        {
            WorldX = x;
            WorldY = y;
            IsCollected = false;
            this.img = img;
        }

        public Item(int x, int y, Image img, int height, int width)
        {
            WorldX = x;
            WorldY = y;
            IsCollected = false;
            this.img = img;
            Height = height;
            Width = width;
        }

        public static Item SpawnCarrot(Map map)
        {
            Random _r = new Random();
            int row = 0;
            int col = 0;

            while (GameScreen.gs.gameMap.mapArray[row,col].collision != false)
            {
                row = _r.Next(3, GameScreen.gs.gameMap.mapData.GetLength(0)-11);
                col = _r.Next(14, GameScreen.gs.gameMap.mapData.GetLength(1)-15);
            }

            return new Item(col * MapTile.tileSize + 22, row * MapTile.tileSize + 32, Properties.Resources.carrot);
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(ScreenX, ScreenY, Width, Height);
            }
        }

        public void ItemCarrotCollected()
        {
            ItemSoundEffect.PlayItemCarrotCollectedSoundEffect();

        }
    }
}
