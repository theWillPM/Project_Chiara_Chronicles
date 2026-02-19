using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace ChiaraChronicles
{
    public partial class IntroForm : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private VideoView _videoView;

        public IntroForm()
        {
            InitializeComponent();

            // These override any leftover designer settings
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            PlayIntro();
        }

        private void MediaPlayer_EndReached(object sender, EventArgs e)
        {
            // Prevent late callbacks from firing into a disposed form
            _mediaPlayer.EndReached -= MediaPlayer_EndReached;

            if (!IsDisposed && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    SafeClose();
                }));
            }
        }

        private void SafeClose()
        {
            if (!IsDisposed)
                Close();
        }
        private void PlayIntro()
        {
            Core.Initialize();

            _videoView = new VideoView();
            _videoView.Dock = DockStyle.Fill;
            Controls.Add(_videoView);

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            _videoView.MediaPlayer = _mediaPlayer;

            string videoPath = Path.Combine("Resources", "introVideo.mp4");
            var media = new Media(_libVLC, videoPath, FromType.FromPath);

            _mediaPlayer.Play(media);

            // SAFE EndReached handler
            _mediaPlayer.EndReached += MediaPlayer_EndReached;
        }

        // Allow skipping with any key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            SafeClose();
            return true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Stop VLC audio immediately
            try
            {
                _mediaPlayer?.Stop();
            }
            catch { }

            // Dispose VLC components BEFORE MainMenu starts
            _mediaPlayer?.Dispose();
            _libVLC?.Dispose();
            _videoView?.Dispose();

            base.OnFormClosed(e);

        }
    }
}