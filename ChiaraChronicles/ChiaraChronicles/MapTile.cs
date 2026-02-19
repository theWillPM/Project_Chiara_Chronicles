using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class MapTile
    {
        public bool collision = false;
        public static int tileSize = 64;
        public Image img;
        internal static MapTile[] TileSet;

        static MapTile()
        {
            InitializeTileSet();
        }

        public MapTile()
        {
        }
        public MapTile(bool collision, Image img) : this()
        {
            this.collision = collision;
            this.img = img;
        }

        private static void InitializeTileSet()
        {
            TileSet = new MapTile[32]
            {
            new MapTile { img = Properties.Resources.grass2 },  // 0
            new MapTile { img = Properties.Resources.water1 },  // 1
            new MapTile { img = Properties.Resources.water2 },  // 2
            new MapTile { img = Properties.Resources.water3 },  // 3
            new MapTile { img = Properties.Resources.water4 },  // 4
            new MapTile { img = Properties.Resources.water5 },  // 5

            new MapTile { img = Properties.Resources.GrassBottomLeft_WaterTopRight2 },   // 6
            new MapTile { img = Properties.Resources.GrassBottomRight_WaterTopLeft2 },   // 7
            new MapTile { img = Properties.Resources.GrassBottom_WaterAround2 },         // 8
            new MapTile { img = Properties.Resources.GrassBottom_WaterTop2 },            // 9
            new MapTile { img = Properties.Resources.GrassLeft_WaterAround2 },           // 10
            new MapTile { img = Properties.Resources.GrassLeft_WaterRight2 },            // 11
            new MapTile { img = Properties.Resources.GrassRight_WaterAround2 },          // 12
            new MapTile { img = Properties.Resources.GrassRight_WaterLeft2 },            // 13
            new MapTile { img = Properties.Resources.GrassTopLeft_WaterBottomRight2 },   // 14
            new MapTile { img = Properties.Resources.GrassTopRight_WaterBottomLeft2 },   // 15
            new MapTile { img = Properties.Resources.GrassTop_WaterAround2 },            // 16
            new MapTile { img = Properties.Resources.GrassTop_WaterBottom2 },            // 17

            new MapTile { img = Properties.Resources.wall },                            // 18
            new MapTile { img = Properties.Resources.grass2 },                          // 19 grass with collision

            new MapTile { img = Properties.Resources.fence_top2 },                   // 20
            new MapTile { img = Properties.Resources.fence_right2 },                 // 21
            new MapTile { img = Properties.Resources.fence_bottom2 },                // 22
            new MapTile { img = Properties.Resources.fence_left2 },                  // 23
            new MapTile { img = Properties.Resources.fence_top_left2 },              // 24
            new MapTile { img = Properties.Resources.fence_top_right2 },             // 25
            new MapTile { img = Properties.Resources.fence_bottom_right2 },          // 26
            new MapTile { img = Properties.Resources.fence_bottom_left2 },           // 27

            new MapTile { img = Properties.Resources.Tree_02 },             // 28

            new MapTile { img = Properties.Resources.mountain1 },           // 29
            new MapTile { img = Properties.Resources.mountain2 },           // 30
            new MapTile { img = Properties.Resources.mountain3 },           // 31


            };

            for (int i = 0; i < TileSet.Length; i++)
            {
                TileSet[i].collision = CheckCollision(i);
            }
        }

            public static bool CheckCollision(int i)
        {
            switch (i)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                    return true;
                default: return false;
            }
        }
    }
}
