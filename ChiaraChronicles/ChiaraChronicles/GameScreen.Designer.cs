using ChiaraChronicles.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace ChiaraChronicles
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::ChiaraChronicles.Properties.Resources.skyfull;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ActualGameScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameScreen_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameScreen_FormClosed);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.ResumeLayout(false);

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            CreatePauseMenuUI();
        }

        private void CreatePauseMenuUI()
        {
            // Dimmed overlay
            pauseOverlay = new DoubleBufferedPanel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };

            this.Controls.Add(pauseOverlay);
            pauseOverlay.BringToFront();


            // Pause menu panel
            pausePanel = new Panel
            {
                Size = new Size(300, 200),
                BackColor = Color.FromArgb(200, 50, 50, 50),
                Visible = false
            };

            pauseOverlay.Controls.Add(pausePanel);

            // Resume button
            Button btnResume = new Button
            {
                Text = "Resume",
                Width = 200,
                Height = 40,
                Top = 20,
                Left = 50
            };
            btnResume.Click += (s, e) => ResumeGame();
            pausePanel.Controls.Add(btnResume);

            // Quit button
            Button btnQuit = new Button
            {
                Text = "Quit to Menu",
                Width = 200,
                Height = 40,
                Top = 80,
                Left = 50
            };
            btnQuit.Click += (s, e) =>
            {
                AudioInstance.StopAudioBackground();
                MainMenu.instance.Show();
                MainMenu.instance.ShowMenuUI();   // ⭐ restore menu buttons
                var save = new SaveState
                {
                    PlayerName = player.Name,
                    //LastSceneId = currentScene,
                    PlayerX = player.WorldX,
                    PlayerY = player.WorldY
                };

                SaveSystem.Save(save);
                this.Hide();

                // Dispose AFTER hiding, on a short delay
                Task.Delay(50).ContinueWith(_ =>
                {
                    this.Invoke(new Action(() => this.Dispose()));
                });
            };
            pausePanel.Controls.Add(btnQuit);
        }
        #endregion
        internal System.Windows.Forms.Timer timer1;
    }
}