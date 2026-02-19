using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace ChiaraChronicles
{
    /// <summary>
    /// ConversationTextBox - Game conversation
    /// </summary>
    public class ConversationTextBox : TextBox
    {
        private Label hintTextLabel;
        private Timer blinkTimer;

        public ConversationTextBox(int screenWidth, int screenHeight)
        {
            Screen screen = Screen.FromControl(GameScreen.gs);
            Rectangle workingArea = screen.WorkingArea;
            Size = new Size(600, 100);
            Location = new Point(workingArea.X + (workingArea.Width) / 2 - Size.Width/2, workingArea.Y + workingArea.Height - 160);
            Multiline = true;
            ReadOnly = true;
            Enabled = false;
            ScrollBars = ScrollBars.None;
            WordWrap = true;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = SystemColors.Control;
            ForeColor = SystemColors.ControlText;
            Font = new Font("Comic Sans MS", 16, FontStyle.Bold);

            // Subscribe to the HandleCreated event
            HandleCreated += ConversationTextBox_HandleCreated;
        }

        private void ConversationTextBox_HandleCreated(object sender, EventArgs e)
        {
            //Label on the right botton indicating to press the button
            hintTextLabel = new Label();
            hintTextLabel.Text = "Press L";
            hintTextLabel.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            hintTextLabel.Size = new Size(70, 25);
            hintTextLabel.BackColor = SystemColors.Control;
            hintTextLabel.ForeColor = Color.Black;
            hintTextLabel.Location = new Point(Right - hintTextLabel.Width - 2, Bottom - hintTextLabel.Bottom - 2);

            // Add the label to the form and bring to the front
            Parent.Controls.Add(hintTextLabel);
            hintTextLabel.BringToFront();

            // Initialize and start the blinking timer
            blinkTimer = new Timer();
            blinkTimer.Interval = 500; // Set the blinking interval (in milliseconds)
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            // Toggle the visibility of the additional label
            hintTextLabel.Visible = !hintTextLabel.Visible;
        }

        public void AddMessage((string Speaker, string Message) conversation)
        {
            if (string.IsNullOrEmpty(conversation.Speaker))
            {
                AppendText($"{conversation.Message}{Environment.NewLine}");
            }
            else
            {
                AppendText($"{conversation.Speaker}: {conversation.Message}{Environment.NewLine}");
            }
        }

        public void ClearConversation()
        {
            Clear();
        }

        public void HideConversation()
        {
            if (blinkTimer != null)
            {
                blinkTimer.Stop();
            }

            if (hintTextLabel != null)
            {
                if (hintTextLabel.InvokeRequired)
                {
                    hintTextLabel.Invoke(new MethodInvoker(() => hintTextLabel.Visible = false));
                }
                else
                {
                    hintTextLabel.Visible = false;
                }
            }

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => Hide()));
            }
            else
            {
                Hide();
            }
        }

        public void ShowConversation()
        {
            if (blinkTimer != null)
            {
                blinkTimer.Start();
            }

            if (hintTextLabel != null)
            {
                if (hintTextLabel.InvokeRequired)
                {
                    hintTextLabel.Invoke(new MethodInvoker(() => hintTextLabel.Visible = true));
                }
                else
                {
                    hintTextLabel.Visible = true;
                }
            }

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => Show()));
            }
            else
            {
                Show();
            }
        }

        // Get the array of conversations
        public (string Speaker, string Message)[] GetConversations()
        {
            return new[]
            {
                //0
                ("Mom", $"Good morning, {GameScreen.gs.player.Name}...Could you go outside and play? Mom and dad are busy today."),
                
                //1-2
                //("NPC", "Hi there! How can I help you?"),
                ("Player", "I'm exploring the game world."),
                ("Dad", "Watch out for monsters!"),

                //3
                ("Picked up", "Stick. Maybe I can use this as a weapon if I press F..."),

                //4
                ("Picked up", "Carrot. Hmm.. I love carrot cake.")
            };
        }

    }
}
