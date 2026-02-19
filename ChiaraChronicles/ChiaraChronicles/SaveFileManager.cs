using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    internal class SaveFileManager
    {
        public static void SavePlayerToFile(Player player, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Type type = typeof(Player);
                PropertyInfo[] properties = type.GetProperties();
                FieldInfo[] fields = type.GetFields();

                foreach (var property in properties)
                {
                    // Skip some properties
                    if (property.Name == "CurrentSprite" || property.Name == "SpriteImages" || property.Name == "currentPlayer")
                    {
                        continue;
                    }

                    object value = property.GetValue(player);
                    SaveValue(writer, property.Name, value);
                }

                foreach (var field in fields)
                {
                    // Skip some fields
                    if (field.Name == "CurrentSprite" || field.Name == "SpriteImages" || field.Name == "currentPlayer")
                    {
                        continue;
                    }

                    object value = field.GetValue(player);
                    SaveValue(writer, field.Name, value);
                }
            }
        }

        private static void SaveValue(StreamWriter writer, string name, object value)
        {
            if (value is IList list)
            {
                // Handle List<T> types that were causing conflict:
                writer.WriteLine($"{name}=[{string.Join(",", list.Cast<object>())}]");
            }
            else if (value != null && value.GetType().IsArray)
            {
                // Handle arrays
                Array array = (Array)value;
                writer.WriteLine($"{name}=[{string.Join(",", array.Cast<object>())}]");
            }
            else
            {
                // Handle other types
                writer.WriteLine($"{name}={value}");
            }
        }

        // I hard-coded the switch cases because looping was causing multiple errors when converting from String to Int32[] or Lists.
        public static Player LoadPlayerFromFile(string filePath)
        {
            Player player = new Player();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string propertyName = parts[0].Trim();
                        string propertyValue = parts[1].Trim();

                        switch (propertyName)
                        {
                            case "Name":
                                player.Name = propertyValue;
                                break;

                            case "MaxHealthPoints":
                                player.MaxHealthPoints = int.Parse(propertyValue);
                                break;

                            case "CurrentHealthPoints":
                                player.CurrentHealthPoints = int.Parse(propertyValue);
                                break;

                            case "ExperiencePoints":
                                player.ExperiencePoints = int.Parse(propertyValue);
                                break;

                            case "Attack":
                                player.Attack = int.Parse(propertyValue);
                                break;

                            case "Speed":
                                player.Speed = int.Parse(propertyValue);
                                break;

                            case "Defense":
                                player.Defense = int.Parse(propertyValue);
                                break;

                            case "WorldX":
                                player.WorldX = int.Parse(propertyValue);
                                break;

                            case "WorldY":
                                player.WorldY = int.Parse(propertyValue);
                                break;

                            case "ScreenX":
                                player.ScreenX = int.Parse(propertyValue);
                                break;

                            case "ScreenY":
                                player.ScreenY = int.Parse(propertyValue);
                                break;

                            case "PosZ":
                                player.PosZ = int.Parse(propertyValue);
                                break;

                            case "Direction":
                                player.Direction = propertyValue;
                                break;

                            case "Carrots":
                                player.Carrots = int.Parse(propertyValue);
                                break;

                            case "Width":
                                player.Width = int.Parse(propertyValue);
                                break;

                            case "Height":
                                player.Height = int.Parse(propertyValue);
                                break;

                            case "Sprite":
                                player.Sprite = int.Parse(propertyValue);
                                break;

                            case "originalSpeed":
                                player.originalSpeed = int.Parse(propertyValue);
                                break;

                            case "isColliding":
                                player.isColliding = bool.Parse(propertyValue);
                                break;

                            case "CanMoveUp":
                                player.CanMoveUp = bool.Parse(propertyValue);
                                break;

                            case "CanMoveDown":
                                player.CanMoveDown = bool.Parse(propertyValue);
                                break;

                            case "CanMoveLeft":
                                player.CanMoveLeft = bool.Parse(propertyValue);
                                break;

                            case "CanMoveRight":
                                player.CanMoveRight = bool.Parse(propertyValue);
                                break;

                            case "UpPressed":
                                player.UpPressed = bool.Parse(propertyValue);
                                break;

                            case "DownPressed":
                                player.DownPressed = bool.Parse(propertyValue);
                                break;

                            case "LeftPressed":
                                player.LeftPressed = bool.Parse(propertyValue);
                                break;

                            case "RightPressed":
                                player.RightPressed = bool.Parse(propertyValue);
                                break;

                            case "ExpToNextLevel":
                                player.ExpToNextLevel = int.Parse(propertyValue);
                                break;

                            case "Level":
                                player.Level = int.Parse(propertyValue);
                                break;

                            case "ImgPack":
                                player.ImgPack = propertyValue;
                                break;

                            case "CurrentSprite":
                                break;

                            case "damageNumbers":
                                break;

                            case "attacks":
                                break;

                            case "IsAttacking":
                                player.IsAttacking = bool.Parse(propertyValue);
                                break;

                            case "attackFrame":
                                player.attackFrame = int.Parse(propertyValue);
                                break;

                            case "Weapon":
                                player.Weapon = propertyValue;
                                if (propertyValue.ToString() == "Stick")
                                {
                                    Item stick = new Item(150 + MapTile.tileSize * 13, MapTile.tileSize * 6, Properties.Resources.big_stick);
                                    stick.Name = "Stick";
                                    player.EquipWeapon(stick);
                                }
                                break;
                        }
                    }
                }
            }

            return player;
        }

    }
}
