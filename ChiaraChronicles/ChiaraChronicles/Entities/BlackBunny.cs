using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class BlackBunny : Monster
    {

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(ScreenX + Width / 4, ScreenY + Height / 2, 2 * Width / 3, Height / 2);
            }
        }
        public BlackBunny() {
            Name = "Black Bunny";
            MaxHealthPoints = 10;
            CurrentHealthPoints = MaxHealthPoints;
            ExperiencePoints = 10;
            Attack = 2;
            Defense = 0;
            Speed = 2; 
            WorldX = 1000;
            WorldY = 1000;
            PosZ = 1;
            Direction = "down";
            Carrots = 1;
            FrameCounter = 0;
            Width = 57 * GameScreen.GlobalScale;
            Height = 39 * GameScreen.GlobalScale;

            Counter++;
            Bitmap up1 = Properties.Resources.BlackBunny1;
            Bitmap up2 = Properties.Resources.BlackBunny2;
            Bitmap up3 = Properties.Resources.BlackBunny3;
            Bitmap up4 = Properties.Resources.BlackBunny4;
            Bitmap down1 = Properties.Resources.BlackBunny1;
            Bitmap down2 = Properties.Resources.BlackBunny2;
            Bitmap down3 = Properties.Resources.BlackBunny3;
            Bitmap down4 = Properties.Resources.BlackBunny4;
            Bitmap left1 = Properties.Resources.BlackBunny1;
            Bitmap left2 = Properties.Resources.BlackBunny2;
            Bitmap left3 = Properties.Resources.BlackBunny3;
            Bitmap left4 = Properties.Resources.BlackBunny4;
            Bitmap right1 = Properties.Resources.BlackBunny1;
            right1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right2 = Properties.Resources.BlackBunny2;
            right2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right3 = Properties.Resources.BlackBunny3;
            right3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right4 = Properties.Resources.BlackBunny4;
            right4.RotateFlip(RotateFlipType.RotateNoneFlipX);


            CurrentSprite = Properties.Resources.BlackBunny1;
            SpriteImages = new Bitmap[,] {
                { up1, up2, up3, up4 },
                { down1, down2, down3, down4 },
                { left1, left2, left3, left4 },
                { right1, right2, right3, right4 }
            };
            SpawnedMonsters.Add(this);
        }
    }
}
