using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class Bat : Monster
    {

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(ScreenX + 3 * Width / 8, ScreenY + 2* Height / 3, Width / 4, Height / 3);
            }
        }
        public Bat() {
            Name = "Bat";
            MaxHealthPoints = 3;
            CurrentHealthPoints = MaxHealthPoints;
            ExperiencePoints = 5;
            Attack = 1;
            Defense = 0;
            Speed = 5;
            WorldX = 1000;
            WorldY = 1000;
            PosZ = 1;
            Direction = "down";
            Carrots = 1;
            FrameCounter = 0;
            Width = 36 * GameScreen.GlobalScale;
            Height = 16 * GameScreen.GlobalScale;

            Counter++;
            Bitmap up1 = Properties.Resources.bat1;
            Bitmap up2 = Properties.Resources.bat2;
            Bitmap up3 = Properties.Resources.bat3;
            Bitmap up4 = Properties.Resources.bat4;
            Bitmap down1 = Properties.Resources.bat1;
            Bitmap down2 = Properties.Resources.bat2;
            Bitmap down3 = Properties.Resources.bat3;
            Bitmap down4 = Properties.Resources.bat4;
            Bitmap left1 = Properties.Resources.bat1;
            Bitmap left2 = Properties.Resources.bat2;
            Bitmap left3 = Properties.Resources.bat3;
            Bitmap left4 = Properties.Resources.bat4;
            Bitmap right1 = Properties.Resources.bat1;
            right1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right2 = Properties.Resources.bat2;
            right2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right3 = Properties.Resources.bat3;
            right3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right4 = Properties.Resources.bat4;
            right4.RotateFlip(RotateFlipType.RotateNoneFlipX);


            CurrentSprite = Properties.Resources.bat1;
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
