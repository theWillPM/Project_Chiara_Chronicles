using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiaraChronicles
{
    /// <summary>
    /// Handles keyboard inputs. Arrows and ASWD are used to move the caracter. E is used to interact. Spacebar is used to attack. Holding shift while walking makes the character run.
    /// </summary>
    static class KeyHandler
    {

        // Use this method to assign actions or behaviours when a key is pressed down.
        public static void HandleKeyDown(KeyEventArgs e, Player p, GameScreen g)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                p.UpPressed = true;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                p.DownPressed = true;
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                p.LeftPressed = true;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                p.RightPressed = true;
            }
            if (e.KeyCode == Keys.F)
            {
                p.IsAttacking = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (Program.CurrentScreen == "Game Screen")
                {
                    g.TogglePauseMenu();
                }

            }
        }

        // Use this method to assign actions or behaviours when a key is pressed down.
        public static void HandleKeyRelease(KeyEventArgs e, Player p, GameScreen g)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                p.UpPressed = false;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                p.DownPressed = false;
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                p.LeftPressed = false;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                p.RightPressed = false;
            }
        }

    }
}
