using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ChiaraChronicles
{
    partial class MainMenu
    {
        internal Button btnExit;
        internal Button btnOptions;
        internal Button btnContinue;
        internal Button btnLoadGame;
        internal Button btnNewGame;
        internal Panel  pnlList;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        internal System.ComponentModel.IContainer components = null;
        internal Panel pnlOptions;
        internal Button button1;
        internal Button button2;
        internal Button button3;
        internal Button button4;
        internal Button btnBack;
        internal Button btnMonsterNames;
        internal Button btnPlayerName;
        internal Button btnBoundingBoxes;
        internal Button btnBgm;
        Audio AudioInstance = new Audio();

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

        /// <summary>
        /// Constructor. Initializes audio and video and sets current screen to MainMenu.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();

            // Hide menu UI until intro finishes
            pnlList.Visible = false;
            pnlOptions.Visible = false;
            btnNewGame.Visible = false;
            btnContinue.Visible = false;
            btnLoadGame.Visible = false;
            btnExit.Visible = false;

            Program.CurrentScreen = "Main Menu";
            btnContinue.Enabled = SaveSystem.SaveExists();
        }

        private void SkipIntro()
        {
            ShowMenuUI();
        }
        internal void ShowMenuUI()
        {
            pnlList.Visible = true;
            btnNewGame.Visible = true;
            btnContinue.Visible = true;
            btnLoadGame.Visible = true;
            btnExit.Visible = true;

            // Start background music if enabled
            if (bgmOn)
                AudioInstance.PlayAudioBackground(AudioInstance.AudioMenuBytes);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlList = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnMonsterNames = new System.Windows.Forms.Button();
            this.btnPlayerName = new System.Windows.Forms.Button();
            this.btnBoundingBoxes = new System.Windows.Forms.Button();
            this.btnBgm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.NameInputDialog1 = new ChiaraChronicles.NameInputDialog();
            this.pnlList.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Ink Free", 48F);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnExit.Location = new System.Drawing.Point(0, 339);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(524, 80);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnHover);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnLeaveHover);
            // 
            // pnlList
            // 
            this.pnlList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlList.AutoSize = true;
            this.pnlList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlList.Controls.Add(this.btnNewGame);
            this.pnlList.Controls.Add(this.btnContinue);
            this.pnlList.Controls.Add(this.btnLoadGame);
            this.pnlList.Controls.Add(this.btnOptions);
            this.pnlList.Controls.Add(this.btnExit);
            this.pnlList.Location = new System.Drawing.Point(170, 12);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(527, 447);
            this.pnlList.TabIndex = 2;
            // 
            // btnNewGame
            // 
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Ink Free", 48F);
            this.btnNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnNewGame.Location = new System.Drawing.Point(0, 53);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(524, 80);
            this.btnNewGame.TabIndex = 5;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            this.btnNewGame.MouseEnter += new System.EventHandler(this.btnHover);
            this.btnNewGame.MouseLeave += new System.EventHandler(this.btnLeaveHover);
            // 
            // btnContinue
            // 
            this.btnContinue.FlatAppearance.BorderSize = 0;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Ink Free", 48F);
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnContinue.Location = new System.Drawing.Point(0, 124);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(524, 80);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            this.btnContinue.MouseEnter += new System.EventHandler(this.btnHover);
            this.btnContinue.MouseLeave += new System.EventHandler(this.btnLeaveHover);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.FlatAppearance.BorderSize = 0;
            this.btnLoadGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.btnLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadGame.Font = new System.Drawing.Font("Ink Free", 48F);
            this.btnLoadGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLoadGame.Location = new System.Drawing.Point(0, 193);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(524, 80);
            this.btnLoadGame.TabIndex = 3;
            this.btnLoadGame.Text = "Load Game";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            this.btnLoadGame.MouseEnter += new System.EventHandler(this.btnHover);
            this.btnLoadGame.MouseLeave += new System.EventHandler(this.btnLeaveHover);
            // 
            // btnOptions
            // 
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Ink Free", 48F);
            this.btnOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnOptions.Location = new System.Drawing.Point(0, 260);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(524, 80);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            this.btnOptions.MouseEnter += new System.EventHandler(this.btnHover);
            this.btnOptions.MouseLeave += new System.EventHandler(this.btnLeaveHover);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlOptions.AutoSize = true;
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlOptions.Controls.Add(this.btnMonsterNames);
            this.pnlOptions.Controls.Add(this.btnPlayerName);
            this.pnlOptions.Controls.Add(this.btnBoundingBoxes);
            this.pnlOptions.Controls.Add(this.btnBgm);
            this.pnlOptions.Controls.Add(this.button1);
            this.pnlOptions.Controls.Add(this.button2);
            this.pnlOptions.Controls.Add(this.button3);
            this.pnlOptions.Controls.Add(this.button4);
            this.pnlOptions.Controls.Add(this.btnBack);
            this.pnlOptions.Location = new System.Drawing.Point(86, 9);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(716, 422);
            this.pnlOptions.TabIndex = 6;
            this.pnlOptions.Visible = false;
            // 
            // btnMonsterNames
            // 
            this.btnMonsterNames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMonsterNames.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonsterNames.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMonsterNames.Location = new System.Drawing.Point(543, 281);
            this.btnMonsterNames.Name = "btnMonsterNames";
            this.btnMonsterNames.Size = new System.Drawing.Size(75, 61);
            this.btnMonsterNames.TabIndex = 9;
            this.btnMonsterNames.Text = "ON";
            this.btnMonsterNames.UseVisualStyleBackColor = false;
            this.btnMonsterNames.Click += new System.EventHandler(this.btnMonsterNames_Click);
            // 
            // btnPlayerName
            // 
            this.btnPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPlayerName.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlayerName.Location = new System.Drawing.Point(543, 208);
            this.btnPlayerName.Name = "btnPlayerName";
            this.btnPlayerName.Size = new System.Drawing.Size(75, 61);
            this.btnPlayerName.TabIndex = 8;
            this.btnPlayerName.Text = "ON";
            this.btnPlayerName.UseVisualStyleBackColor = false;
            this.btnPlayerName.Click += new System.EventHandler(this.btnPlayerName_Click);
            // 
            // btnBoundingBoxes
            // 
            this.btnBoundingBoxes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBoundingBoxes.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoundingBoxes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBoundingBoxes.Location = new System.Drawing.Point(543, 136);
            this.btnBoundingBoxes.Name = "btnBoundingBoxes";
            this.btnBoundingBoxes.Size = new System.Drawing.Size(75, 61);
            this.btnBoundingBoxes.TabIndex = 7;
            this.btnBoundingBoxes.Text = "ON";
            this.btnBoundingBoxes.UseVisualStyleBackColor = false;
            this.btnBoundingBoxes.Click += new System.EventHandler(this.btnBoundingBoxes_Click);
            // 
            // btnBgm
            // 
            this.btnBgm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBgm.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBgm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBgm.Location = new System.Drawing.Point(543, 63);
            this.btnBgm.Name = "btnBgm";
            this.btnBgm.Size = new System.Drawing.Size(75, 61);
            this.btnBgm.TabIndex = 6;
            this.btnBgm.Text = "ON";
            this.btnBgm.UseVisualStyleBackColor = false;
            this.btnBgm.Click += new System.EventHandler(this.btnBgm_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Ink Free", 36F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.Location = new System.Drawing.Point(30, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(524, 80);
            this.button1.TabIndex = 5;
            this.button1.Text = "Background Music";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Ink Free", 36F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.Location = new System.Drawing.Point(30, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(524, 80);
            this.button2.TabIndex = 4;
            this.button2.Text = "Show Bounding Boxes";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Ink Free", 36F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button3.Location = new System.Drawing.Point(30, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(524, 80);
            this.button3.TabIndex = 3;
            this.button3.Text = "Show Player Name";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Ink Free", 36F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button4.Location = new System.Drawing.Point(30, 271);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(524, 80);
            this.button4.TabIndex = 2;
            this.button4.Text = "Show Monster Names";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(20)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Ink Free", 48F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBack.Location = new System.Drawing.Point(30, 339);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(524, 80);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // NameInputDialog1
            // 
            this.NameInputDialog1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NameInputDialog1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NameInputDialog1.BackgroundImage")));
            this.NameInputDialog1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NameInputDialog1.Location = new System.Drawing.Point(616, 414);
            this.NameInputDialog1.Name = "NameInputDialog1";
            this.NameInputDialog1.Size = new System.Drawing.Size(344, 206);
            this.NameInputDialog1.TabIndex = 10;
            this.NameInputDialog1.Visible = false;
            // 
            // MainMenu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImage = global::ChiaraChronicles.Properties.Resources.Main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(852, 480);
            this.Controls.Add(this.NameInputDialog1);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Carrot-Game";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.pnlList.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private NameInputDialog NameInputDialog1;
    }
}
