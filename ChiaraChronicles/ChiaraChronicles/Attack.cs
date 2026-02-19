using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class Attack : Entity
    {
        readonly Player p = GameScreen.gs.player;
        public int extraRange = 0;
        public int frame;

        public static List<Attack> AttacksList = new List<Attack>();

        internal Attack(string direction)
        {
            Direction = direction;
            AttacksList.Add(this);
                Task.Run(async () =>
                {
                    await Task.Delay(200);
                    AttacksList.Remove(this);
                });
        }

        /// <summary>
        /// Defines a bounding box for the attack. Attack is an entity;
        /// </summary>
        public override Rectangle BoundingBox 
        {
            get
            {
                int verticalSize;
                int horizontalSize;

                switch (p.Direction)
                {
                    case "up":
                        verticalSize = 2 * p.Height / 3 + extraRange * 16; 
                        horizontalSize = p.Width;
                        return new Rectangle(p.BoundingBox.Left - horizontalSize / 3, p.BoundingBox.Top - verticalSize + 2* p.BoundingBox.Height / 3, horizontalSize, verticalSize);
                    case "down":
                        verticalSize = 2 * p.Height / 3 + extraRange * 16;
                        horizontalSize = p.Width;
                        return new Rectangle(p.BoundingBox.Left - horizontalSize / 3, p.BoundingBox.Bottom - 2 * p.BoundingBox.Height / 3, horizontalSize, verticalSize);
                    case "left":
                        verticalSize = p.Height;
                        horizontalSize = 2 * p.Width / 3 + extraRange * 16;
                        return new Rectangle(p.BoundingBox.Left - horizontalSize + p.BoundingBox.Width / 3, p.BoundingBox.Top - (verticalSize - p.BoundingBox.Height)/2 , horizontalSize, verticalSize);
                    case "right":
                        verticalSize = p.Height;
                        horizontalSize = 2 * p.Width / 3 + extraRange * 16;
                        return new Rectangle(p.BoundingBox.Right - p.BoundingBox.Width / 3, p.BoundingBox.Top - (verticalSize - p.BoundingBox.Height) / 2, horizontalSize, verticalSize);
                    default:
                        return new Rectangle();
                }
            }
        }

        public override void Move(int x, int y, int z)
        {
            // Implement projectile attacks here
        }
    }
}
