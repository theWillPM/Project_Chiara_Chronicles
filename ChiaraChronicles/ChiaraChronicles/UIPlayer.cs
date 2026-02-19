using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ChiaraChronicles
{
    /// <summary>
    /// UI Player - 
    /// </summary>
    internal class UIPlayer : Control
    {
        private readonly int  _maximum = 100;
        private readonly int _minimum = 0;
        private readonly int _linearProgressBarHeight = 30;

        readonly Screen screen;
        Rectangle workingArea;

        // Properties Carrot
        public Image carrot = Properties.Resources.carrot;

        // -----------------------------
        // XP CIRCULAR BAR PROPERTIES
        // -----------------------------

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Point CircularProgressBarLocation { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Size CircularProgressBarSize { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int xpCurrentValue { get; set; } = 0;

        // -----------------------------
        // HP LINEAR BAR PROPERTIES
        // -----------------------------

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Point LinearProgressBarLocation { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Size LinearProgressBarSize { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int hpCurrentValue { get; set; } = 100;

        public UIPlayer()
        {
            screen = Screen.FromControl(this);
            workingArea = screen.WorkingArea;

            CircularProgressBarSize = new Size(200, 200);
            CircularProgressBarLocation = new Point(
                workingArea.X + 40,
                workingArea.Y + workingArea.Height - CircularProgressBarSize.Height - 190
            );

            LinearProgressBarLocation = new Point(workingArea.X + 40, workingArea.Y + 40);
            LinearProgressBarSize = new Size(300, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawExperienceBar(e.Graphics);
            DrawHealthBar(e.Graphics);
            DrawCarrot(e.Graphics);
        }

        public void DrawExperienceBar(Graphics g)
        {
            Pen backgroundPen = new Pen(Color.Wheat, 19);
            
            Pen fillPen = new Pen(Color.Green, 15);

            float angle = 360f * (Player.currentPlayer.ExperiencePoints) / (Player.currentPlayer.ExpToNextLevel);

            // CircularProgressBarLocation and CircularProgressBarSize properties
            g.DrawArc(backgroundPen, CircularProgressBarLocation.X, CircularProgressBarLocation.Y, CircularProgressBarSize.Width, CircularProgressBarSize.Height, 0, 360);
            g.DrawArc(fillPen, CircularProgressBarLocation.X, CircularProgressBarLocation.Y, CircularProgressBarSize.Width, CircularProgressBarSize.Height, -90, angle);

            // Draw the level label
            string levelText = "LVL " + Player.currentPlayer.Level.ToString();
            Font levelFont = new Font("Arial", 24, FontStyle.Bold);
            Brush levelBrush = new SolidBrush(Color.White);
            SizeF levelSize = g.MeasureString(levelText, levelFont);
            PointF levelLocation = new PointF(CircularProgressBarLocation.X + (CircularProgressBarSize.Width - levelSize.Width) / 2, CircularProgressBarLocation.Y + (CircularProgressBarSize.Height - levelSize.Height) / 2);
            g.DrawString(levelText, levelFont, levelBrush, levelLocation);
        }

        // This linear progress bar represents the Health Points:
        public void DrawHealthBar(Graphics g)
        {
            Brush backgroundBrush = new SolidBrush(Color.Gray);
            Brush fillBrush = new SolidBrush(Color.FromArgb(255, 255, 100, 100));

            int fillWidth = (int)((float)(Player.currentPlayer.CurrentHealthPoints) / (Player.currentPlayer.MaxHealthPoints) * LinearProgressBarSize.Width);

            // Draw the HP label
            Font labelFont = new Font("Arial", 18, FontStyle.Bold);
            Brush labelBrush = new SolidBrush(Color.Black);
            g.DrawString("HP:", labelFont, labelBrush, LinearProgressBarLocation.X, LinearProgressBarLocation.Y);

            g.FillRectangle(backgroundBrush, LinearProgressBarLocation.X + labelFont.SizeInPoints * 3, LinearProgressBarLocation.Y, LinearProgressBarSize.Width, LinearProgressBarSize.Height);
            g.FillRectangle(fillBrush, LinearProgressBarLocation.X + labelFont.SizeInPoints * 3, LinearProgressBarLocation.Y + LinearProgressBarSize.Height - _linearProgressBarHeight, fillWidth, _linearProgressBarHeight);

            // Draw vertical lines
            int numSegments = Player.currentPlayer.MaxHealthPoints;
            int segmentWidth = LinearProgressBarSize.Width / numSegments;

            using (Pen linePen = new Pen(Color.Black, 1))
            {
                for (int i = 1; i < numSegments; i++)
                {
                    int xPosition = (int)(LinearProgressBarLocation.X + labelFont.SizeInPoints * 3 + i * segmentWidth);
                    g.DrawLine(linePen, xPosition, LinearProgressBarLocation.Y, xPosition, LinearProgressBarLocation.Y + LinearProgressBarSize.Height);
                }
            }
        }

        public void DrawCarrot(Graphics g)
        {
            // Calculate carrot position based on LinearProgressBarLocation and LinearProgressBarSize
            int carrotX = LinearProgressBarLocation.X + 380;
            int carrotY = LinearProgressBarLocation.Y + (LinearProgressBarSize.Height - 80) / 2;

            int carrotWidth = 43;
            int carrotHeight = 64;

            g.DrawImage(carrot, new Rectangle(carrotX, carrotY, carrotWidth, carrotHeight));

            // Draw the carrot label
            string label = "x " + Player.currentPlayer.Carrots.ToString();
            Font labelFont = new Font("Arial", 14, FontStyle.Bold);
            Brush labelBrush = new SolidBrush(Color.Black);
            SizeF labelSize = g.MeasureString(label, labelFont);

            // Adjust the label location
            PointF labelLocation = new PointF(carrotX + carrotWidth - 5, carrotY + (carrotHeight - labelSize.Height) / 2 + 5);

            g.DrawString(label, labelFont, labelBrush, labelLocation);
        }



    }
}
