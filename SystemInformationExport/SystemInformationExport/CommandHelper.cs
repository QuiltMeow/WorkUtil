using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SystemInformationExport
{
    public static class CommandHelper
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void exportSystemInformation(string path, bool hideGUI = false)
        {
            const string PROGRAM = "msinfo32";
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = $"/nfo {path}",
                FileName = PROGRAM,
                UseShellExecute = false
            };

            using (Process process = new Process()
            {
                StartInfo = startInfo
            })
            {
                try
                {
                    process.Start();
                    if (hideGUI)
                    {
                        const int SLEEP_TIME = 500;
                        const string TITLE = "系統資訊";
                        Thread.Sleep(SLEEP_TIME);
                        IntPtr hWnd = FindWindow(null, TITLE);
                        if (hWnd != null)
                        {
                            const int SW_HIDE = 0;
                            _ = ShowWindow(hWnd, SW_HIDE);
                        }
                    }
                    process.WaitForExit();
                }
                catch
                {
                }
            }
        }
    }
}