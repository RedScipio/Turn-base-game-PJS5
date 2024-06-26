using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UGUI
{
    internal class MusicSoundPlayer
    {


        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        public static void Play(string FileName, string TrackName, bool Loop)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Ensure the track is closed before opening again
                mciSendString("close " + TrackName, sb, 0, IntPtr.Zero);

                // Open the audio file with an alias
                mciSendString("open \"" + FileName + "\" alias " + TrackName, sb, 0, IntPtr.Zero);

                // Play the audio file, with optional looping
                if (Loop)
                {
                    mciSendString("play " + TrackName + " repeat", sb, 0, IntPtr.Zero);
                }
                else
                {
                    mciSendString("play " + TrackName, sb, 0, IntPtr.Zero);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while playing the sound: " + ex.Message);
            }
        }
    }
}

