using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.IO;
using System.Windows.Forms;

namespace ChiaraChronicles
{
    class Audio : IDisposable
    {
        // Embedded audio readers
        internal byte[] AudioMenuBytes;
        internal byte[] AudioBackgroundPhase1Bytes;
        internal byte[] AudioHeroWalkingInGrassBytes;
        internal byte[] AudioHeroAttackBytes;

        internal byte[] AudioMonsterBatAttackBytes;
        internal byte[] AudioMonsterSpiderAttackBytes;
        internal byte[] AudioMonsterBunnyAttackBytes;
        internal byte[] AudioMonsterBlackBunnyAttackBytes;

        internal byte[] AudioItemCarrotCollectedBytes;
        internal byte[] AudioDoorBytes;

        // Playback devices
        private WaveOutEvent WaveOutBackground = new WaveOutEvent();

        private WaveOutEvent WaveOutHeroWalkingInGrass = new WaveOutEvent();
        private WaveOutEvent WaveOutHeroAttack = new WaveOutEvent();

        private WaveOutEvent WaveOutMonsterBatAttack = new WaveOutEvent();
        private WaveOutEvent WaveOutMonsterSpiderAttack = new WaveOutEvent();
        private WaveOutEvent WaveOutMonsterBunnyAttack = new WaveOutEvent();
        private WaveOutEvent WaveOutMonsterBlackBunnyAttack = new WaveOutEvent();

        private WaveOutEvent WaveOutItemCarrotCollected = new WaveOutEvent();
        private WaveOutEvent WaveOutAudioDoor = new WaveOutEvent();

        private VolumeSampleProvider backgroundVolumeProvider;


        public Audio()
        {
            // Load embedded WAVs from Resources.resx
            AudioMenuBytes = ReadAllBytes(Properties.Resources.menu);
            AudioBackgroundPhase1Bytes = ReadAllBytes(Properties.Resources.up_down);
            AudioHeroWalkingInGrassBytes = ReadAllBytes(Properties.Resources.hero_walking_grass_side);
            AudioHeroAttackBytes = ReadAllBytes(Properties.Resources.mixkit_karate_fighter_hit_2154);

            AudioMonsterBatAttackBytes = ReadAllBytes(Properties.Resources.mixkit_falling_on_undergrowth_390);
            AudioMonsterSpiderAttackBytes = ReadAllBytes(Properties.Resources.mixkit_hard_and_quick_punch_2143);
            AudioMonsterBunnyAttackBytes = ReadAllBytes(Properties.Resources.mixkit_body_punch_quick_hit_2153);
            AudioMonsterBlackBunnyAttackBytes = ReadAllBytes(Properties.Resources.mixkit_martial_arts_fast_punch_2047);

            AudioItemCarrotCollectedBytes = ReadAllBytes(Properties.Resources.mixkit_player_jumping_in_a_video_game_2043);
            AudioDoorBytes = ReadAllBytes(Properties.Resources.mixkit_automatic_door_shut_204);
        }

        private WaveStream CreateStream(byte[] data)
        {
            return new WaveFileReader(new MemoryStream(data));
        }

        private byte[] ReadAllBytes(UnmanagedMemoryStream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private WaveStream LoadEmbedded(UnmanagedMemoryStream resourceStream)
        {
            return new WaveFileReader(resourceStream);
        }

        // Background music
        private bool isBackgroundAudioLooping = true;

        public void PlayAudioBackground(byte[] audioBytes)
        {
            // Stop old playback
            WaveOutBackground.Stop();
            WaveOutBackground.Dispose();
            WaveOutBackground = new WaveOutEvent();

            // Create a fresh stream
            var stream = CreateStream(audioBytes);

            var reader = new WaveFileReader(new MemoryStream(audioBytes));
            backgroundVolumeProvider = new VolumeSampleProvider(reader.ToSampleProvider());
            backgroundVolumeProvider.Volume = 1.0f; // full volume

            WaveOutBackground.Init(backgroundVolumeProvider);

            WaveOutBackground.PlaybackStopped += (s, e) =>
            {
                if (isBackgroundAudioLooping)
                {
                    stream.Dispose();
                    stream = CreateStream(audioBytes);
                    WaveOutBackground.Init(stream);
                    WaveOutBackground.Play();
                }
                else
                {
                    stream.Dispose();
                }
            };

            WaveOutBackground.Play();
        }

        public void StopAudioBackground()
        {
            isBackgroundAudioLooping = false;

            if (WaveOutBackground != null)
            {
                try
                {
                    WaveOutBackground.Stop();
                }
                catch { }

                WaveOutBackground.Dispose();
                WaveOutBackground = new WaveOutEvent(); // reset cleanly
            }
        }

        public async void FadeOutBackground(int milliseconds)
        {
            if (backgroundVolumeProvider == null)
                return;

            float startVolume = backgroundVolumeProvider.Volume;
            int steps = 50;
            float stepAmount = startVolume / steps;
            int stepTime = milliseconds / steps;

            for (int i = 0; i < steps; i++)
            {
                backgroundVolumeProvider.Volume -= stepAmount;
                await Task.Delay(stepTime);
            }

            backgroundVolumeProvider.Volume = 0f;
            StopAudioBackground();
        }

        // Sound effects
        private void PlaySoundEffect(WaveOutEvent waveOut, byte[] audioBytes)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = new WaveOutEvent();
            }

            var stream = CreateStream(audioBytes);
            waveOut.Init(stream);
            waveOut.Play();

            waveOut.PlaybackStopped += (s, e) => stream.Dispose();
        }

        public void PlayHeroWalkingSoundEffect()
            => PlaySoundEffect(WaveOutHeroWalkingInGrass, AudioHeroWalkingInGrassBytes);

        public void PlayHeroAttackSoundEffect()
            => PlaySoundEffect(WaveOutHeroAttack, AudioHeroAttackBytes);

        public void PlayMonsterBatAttackSoundEffect()
            => PlaySoundEffect(WaveOutMonsterBatAttack, AudioMonsterBatAttackBytes);

        public void PlayMonsterSpiderAttackSoundEffect()
            => PlaySoundEffect(WaveOutMonsterSpiderAttack, AudioMonsterSpiderAttackBytes);

        public void PlayMonsterBunnyAttackSoundEffect()
            => PlaySoundEffect(WaveOutMonsterBunnyAttack, AudioMonsterBunnyAttackBytes);

        public void PlayMonsterBlackBunnyAttackSoundEffect()
            => PlaySoundEffect(WaveOutMonsterBlackBunnyAttack, AudioMonsterBlackBunnyAttackBytes);

        public void PlayItemCarrotCollectedSoundEffect()
            => PlaySoundEffect(WaveOutItemCarrotCollected, AudioItemCarrotCollectedBytes);

        public void PlayDoorSoundEffect()
            => PlaySoundEffect(WaveOutAudioDoor, AudioDoorBytes);

        public void Dispose()
        {
            WaveOutBackground?.Dispose();
            WaveOutHeroWalkingInGrass?.Dispose();
            WaveOutHeroAttack?.Dispose();
            WaveOutMonsterBatAttack?.Dispose();
            WaveOutMonsterSpiderAttack?.Dispose();
            WaveOutMonsterBunnyAttack?.Dispose();
            WaveOutMonsterBlackBunnyAttack?.Dispose();
            WaveOutItemCarrotCollected?.Dispose();
            WaveOutAudioDoor?.Dispose();
        }
    }
}