using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiaraChronicles
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
            KeyDown += GameOver_KeyDown;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MainMenu.instance.btnNewGame_Click(sender, e);
        }

        private void GameOver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnStart_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                btnStart_Click(sender, e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GameScreen.gs.Close();
        }
    }
}

