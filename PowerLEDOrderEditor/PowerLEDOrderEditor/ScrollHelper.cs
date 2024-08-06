using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PowerLEDOrderEditor
{
    public static class ScrollHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void scroll(this Control control)
        {
            Point point = control.PointToClient(Cursor.Position);

            if (point.Y + 20 > control.Height)
            {
                SendMessage(control.Handle, 277, (IntPtr)1, (IntPtr)0);
            }
            else if (point.Y < 20)
            {
                SendMessage(control.Handle, 277, (IntPtr)0, (IntPtr)0);
            }
        }
    }
}