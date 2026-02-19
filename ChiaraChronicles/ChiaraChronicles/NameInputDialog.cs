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
    public partial class NameInputDialog : UserControl
    {
        public NameInputDialog()
        {
            InitializeComponent();
            nameInput.KeyDown += NameInput_KeyDown;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (nameInput.Text.Length > 1)
            {
                Form game = new GameScreen(nameInput.Text);
                game.Show();

                // Remove the name picker from the menu
                MainMenu.instance.Controls.Remove(this);
                this.Dispose();

                // Hide the menu while the game runs
                MainMenu.instance.Hide();
            }
        }

        private void NameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnStart_Click(sender, e);
            }
        }
    }
}

