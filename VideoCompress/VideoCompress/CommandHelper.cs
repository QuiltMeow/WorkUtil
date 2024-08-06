using System.Diagnostics;

namespace VideoCompress
{
    public static class CommandHelper
    {
        public const string EMPTY_STRING = "";

        public static void runProcess(string target, string argument = EMPTY_STRING, DataReceivedEventHandler? standardOutput = null, DataReceivedEventHandler? standardError = null)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = $"{argument}",
                CreateNoWindow = true,
                FileName = target,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            using (Process process = new Process()
            {
                StartInfo = startInfo
            })
            {
                if (standardOutput != null)
                {
                    process.EnableRaisingEvents = true;
                    process.OutputDataReceived += standardOutput;
                    process.ErrorDataReceived += standardError;
                }

                try
                {
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();
                }
                catch
                {
                }
                finally
                {
                    try
                    {
                        process.CancelOutputRead();
                        process.CancelErrorRead();
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}