using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiaraChronicles
{
    /// <summary>
    /// A monster is a computer-controlled entity that damages the player when they collide.
    /// </summary>
    class Monster : Entity, ICollision
    {
        internal static int Counter = 0;
        private int _moveDelay = -1;

        public static Random Random = new Random();

        public static StringFormat sf = new StringFormat();
        private readonly Font MonsterDamageTag = new Font("Georgia", 7 + 4 * GameScreen.GlobalScale, FontStyle.Bold, GraphicsUnit.Point);


        public static List<Monster> SpawnedMonsters = new List<Monster>();

        // This is the list that stores the damage values the monster received and their relative position on top of them. [dmg, pos].
        // Damage values are added by ResolveAttack and removed after their position reaches a treshold.
        public List<int[]> damageNumbers = new List<int[]>();

        private int _moveCounter = 0;

        //Player sounds
        Audio MonsterSoundEffect = new Audio();

        public bool isSpawned = false;

        // A list of all monster types. Whenever a new monster class is created, it should be added to this list.
        // This is used to spawn monsters at random. We can later implement different difficulties monster lists or even environment-specific lists. Ex.: Cave monsters, Grass monsters, water, etc.
        public static List<Type> MonsterList = new List<Type>() {
            typeof(WhiteBunny),
            typeof(BlackBunny),
            typeof(Spider1),
            typeof(Bat)};

        // A placeholder to receive extra outfits.
        public string ImgPack { get; set; } = "";
        public Bitmap CurrentSprite;

        // Control attack animation
        private int _attackFrame = 0;

        // seconds between attacks
        private double _attackSpeed = 2;

        /// Adjust this according to the Monster's geometry.
        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(ScreenX, ScreenY, Width, Height);
            }
        }

        static Monster()
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }
        // Move the character on X, Y and Z axis.
        public override void Move(int x, int y, int z)
        {
            WorldX += x;
            WorldY += y;
            PosZ += z;
        }

        // This makes monsters follow the player.
        public void FollowPlayer(Player p)
        {
            if (_moveDelay > GameScreen.fps * 2)
            {
                LeftPressed = false;
                RightPressed = false;
                UpPressed = false;
                DownPressed = false;
            } 
            // This makes movement "in turns", to avoid movement being "too smooth". 
            // Remove the _moveCounter if blocks to make movement smooth.
            if (Math.Abs(p.WorldX - this.WorldX) < MapTile.tileSize * 5 && Math.Abs(p.WorldY - this.WorldY) < MapTile.tileSize * 5)
            {
                if (_moveCounter > GameScreen.fps/(Speed + 1))
                {
                    // If player is to the left of the monster 
                    if (BoundingBox.Left > p.BoundingBox.Right)
                    {
                        RightPressed = false;
                        LeftPressed = true;
                    }
                    if(BoundingBox.Left <= p.BoundingBox.Right) 
                    {
                        LeftPressed = false;
                    }
                    // If player is to the right of the monster
                    if (BoundingBox.Right < p.BoundingBox.Left)
                    {
                        RightPressed = true;
                        LeftPressed = false;
                    }
                    if (BoundingBox.Right >= p.BoundingBox.Left)
                    {
                        RightPressed = false;
                    }

                    // If player is to the top of the monster
                    if (BoundingBox.Top > p.BoundingBox.Bottom)
                    {
                        DownPressed = false;
                        UpPressed = true;
                    }
                    if (BoundingBox.Top <= p.BoundingBox.Bottom)
                    {
                        UpPressed = false;
                    }

                    // If player is to the bottom of the monster
                    if (BoundingBox.Bottom < p.BoundingBox.Top)
                    {
                        DownPressed = true;
                        UpPressed = false;
                    }
                    if (BoundingBox.Bottom >= p.BoundingBox.Top)
                    {
                        DownPressed = false;
                    }
                    if (_moveCounter > GameScreen.fps)
                        _moveCounter = 0;
                }
            }

            else
            {
                Task.Run(() =>
                {
                    if (_moveDelay == -1)
                        _moveDelay = 0;
                    if (_moveDelay == 0)
                    {
                        Random _r = new Random();
                        int direction = _r.Next(0, 3);
                        _moveDelay++;
                        switch (direction)
                        {
                            case 0:
                                UpPressed = true;
                                DownPressed = false;
                                break;
                            case 1:
                                UpPressed = false;
                                DownPressed = true;
                                break;
                            case 2:
                                RightPressed = true;
                                LeftPressed = false;
                                break;
                            case 3:
                                RightPressed = false;
                                LeftPressed = true;
                                break;
                            default:
                                RightPressed = LeftPressed = UpPressed = DownPressed = false;
                                break;
                        }
                    }
                    else if (_moveDelay > 0 && _moveDelay <= GameScreen.fps)
                        _moveDelay++;
                    else if (_moveDelay > GameScreen.fps && _moveDelay <= GameScreen.fps * 2)
                    {
                        RightPressed = LeftPressed = UpPressed = DownPressed = false;
                        _moveDelay++;
                    }
                    else if (_moveDelay > GameScreen.fps * 2)
                        _moveDelay = -1;
                });
            }

        }

        // Calculates monster attack damage and adds it to the damage displaying array.
        public void ResolveAttack()
        {
            Player _p = Player.currentPlayer;
            if (_p.IsColliding(this))
            {
                _attackFrame++;
                if (_attackFrame > GameScreen.fps*_attackSpeed)
                {
                    int attackDamage = Math.Max(Attack - _p.Defense, 1);
                    int[] arrayToAdd = { attackDamage, 0 };
                    GameScreen.gs.player.damageNumbers.Add(arrayToAdd);
                    _p.CurrentHealthPoints -= attackDamage;
                    if (_p.CurrentHealthPoints <= 0 )
                    {
                        _p.Die();
                    }
                    _attackFrame = 0;


                    // Monster Sounds Attack based on the monster type
                    var monsterType = GetType();
                    if (monsterType == typeof(Bat))
                    {
                        MonsterSoundEffect.PlayMonsterBatAttackSoundEffect();
                    }
                    else if (monsterType == typeof(Spider1))
                    {
                        MonsterSoundEffect.PlayMonsterSpiderAttackSoundEffect();
                    }
                    else if (monsterType == typeof(WhiteBunny))
                    {
                        MonsterSoundEffect.PlayMonsterBunnyAttackSoundEffect();
                    }
                    else if (monsterType == typeof(BlackBunny))
                    {
                        MonsterSoundEffect.PlayMonsterBlackBunnyAttackSoundEffect();
                    }
                }
            }
        }

        // updates the monster's position, direction, sprite, and attacks if possible.
        public void Update()
        {
            _moveCounter++;

            if (Player.currentPlayer.IsColliding(this))
                ResolveAttack();

            if (UpPressed || DownPressed || LeftPressed || RightPressed)
            {
                if (UpPressed)
                {
                    Direction = "up";
                }
                if (DownPressed)
                {
                    Direction = "down";
                }
                if (LeftPressed)
                {
                    Direction = "left";
                }
                if (RightPressed)
                {
                    Direction = "right";
                }

                // Checking for any tile collision
                isColliding = false;
                GameScreen.gs.cChecker.CheckTileCollision(this);

                // Allow movement if no collision:
                if (!isColliding)
                {
                    if (LeftPressed)
                        Move(-Speed, 0, 0);
                    if (RightPressed)
                        Move(Speed, 0, 0);
                    if (UpPressed)
                        Move(0, -Speed, 0);
                    if (DownPressed)
                        Move(0, Speed, 0);
                }
                // adds a counter to our movement frame counter
                FrameCounter++;


                // once we reach this threshold, we change the image to the next available in the array.
                if (FrameCounter > 9)
                {
                    if (Sprite == 0)
                    {
                        Sprite = 1;
                    }
                    else if (Sprite == 1)
                    {
                        Sprite = 2;
                    }
                    else if (Sprite == 2)
                    {
                        Sprite = 3;
                    }
                    else if (Sprite == 3)
                    {
                        Sprite = 0;
                    }
                    FrameCounter = 0;
                }

                // this defines the image to be displayed
                switch (Direction)
                {
                    case "up":
                        CurrentSprite = SpriteImages[0, Sprite];
                        break;
                    case "down":
                        CurrentSprite = SpriteImages[1, Sprite];
                        break;
                    case "left":
                        CurrentSprite = SpriteImages[2, Sprite];
                        break;
                    case "right":
                        CurrentSprite = SpriteImages[3, Sprite];
                        break;
                }
            }
        }

        internal void DrawDamage(Graphics g)
        {
            //TODO - add this condition to the whole function
            //if (showDamageNumbers == true)

            // We create a copy of the original list, because we will both iterate through and modify it:
            List<int[]> _d = new List<int[]>(damageNumbers);

            // This is the displacement value when we remove items from the list, to avoid out of bounds exception.
            int _indxtra = 0;

            // To avoid wasting processing power when we don't have any damage to display:
            if (damageNumbers.Count > 0)
                foreach (var dmg in _d)
                {
                    int _ind = _d.IndexOf(dmg) + _indxtra;
                    Rectangle _dmgBox = new Rectangle(ScreenX - 5, ScreenY - dmg[1], Width + 10, 25);

                    g.DrawString(dmg[0].ToString(), MonsterDamageTag, Brushes.OrangeRed, _dmgBox, sf);

                    damageNumbers[_ind][1]++;

                    if (damageNumbers[_ind][1] > GameScreen.fps * 4)
                    {
                        damageNumbers.Remove(dmg);
                        _indxtra--;
                    }
                }
        }

        // Check if the monster is colliding with the player.
        public bool IsColliding(Entity player)
        {
            return  ScreenX < player.ScreenX + player.Width   &&
                    ScreenX + Width > player.ScreenX          &&
                    ScreenY < player.ScreenY + player.Height  &&
                    ScreenY + Height > player.ScreenY;
        }

        public void Die()
        {
            Task.Run(() =>
            {
                GameScreen.monsterSpawnTimer = 1000;
                SpawnedMonsters.Remove(this);
                Counter--;

                Random _r = new Random();
                int _timer = _r.Next(GameScreen.fps, GameScreen.fps * 10);
                
                GameScreen.monsterSpawnTimer = _timer;
                Player.currentPlayer.GainExperience(ExperiencePoints);
            });
            // Earn experience points based on monster type
        }
    }
}
