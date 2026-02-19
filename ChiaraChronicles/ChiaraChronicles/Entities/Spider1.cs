using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class Spider1 : Monster
    {

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(ScreenX + Width / 3, ScreenY + Height / 3 , Width / 3, 2* Height / 3);
            }
        }
        public Spider1() {
            Name = "Spider";
            MaxHealthPoints = 8;
            CurrentHealthPoints = MaxHealthPoints;
            ExperiencePoints = 3;
            Attack = 1;
            Defense = 0;
            Speed = 5;
            WorldX = 1000;
            WorldY = 1000;
            PosZ = 1;
            Direction = "down";
            Carrots = 1;
            FrameCounter = 0;
            Width = 63 * GameScreen.GlobalScale;
            Height = 40 * GameScreen.GlobalScale;

            Counter++;

            Bitmap up1 = Properties.Resources.spider1_1;
            Bitmap up2 = Properties.Resources.spider1_2;
            Bitmap up3 = Properties.Resources.spider1_3;
            Bitmap up4 = Properties.Resources.spider1_4;
            Bitmap down1 = Properties.Resources.spider1_1;
            Bitmap down2 = Properties.Resources.spider1_2;
            Bitmap down3 = Properties.Resources.spider1_3;
            Bitmap down4 = Properties.Resources.spider1_4;
            Bitmap left1 = Properties.Resources.spider1_1;
            Bitmap left2 = Properties.Resources.spider1_2;
            Bitmap left3 = Properties.Resources.spider1_3;
            Bitmap left4 = Properties.Resources.spider1_4;
            Bitmap right1 = Properties.Resources.spider1_1;
            right1.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right2 = Properties.Resources.spider1_2;
            right2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right3 = Properties.Resources.spider1_3;
            right3.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Bitmap right4 = Properties.Resources.spider1_4;
            right4.RotateFlip(RotateFlipType.RotateNoneFlipX);


            CurrentSprite = Properties.Resources.spider1_1;
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
