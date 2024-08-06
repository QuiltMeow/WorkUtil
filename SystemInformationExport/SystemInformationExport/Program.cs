using System;
using System.IO;
using System.Windows.Forms;

namespace SystemInformationExport
{
    public static class Program
    {
        public static bool isValidPath(string path)
        {
            try
            {
                _ = Path.GetFullPath(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [STAThread]
        public static void Main(string[] argument)
        {
            if (argument.Length > 0)
            {
                string path = argument[0];
                if (!isValidPath(path))
                {
                    MessageBox.Show("指定路徑無效", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool hideGUI = false;
                if (argument.Length > 1)
                {
                    hideGUI = true;
                }
                CommandHelper.exportSystemInformation(argument[0], hideGUI);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}