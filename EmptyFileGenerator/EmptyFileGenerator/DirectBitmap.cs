using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace EmptyFileGenerator
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap bitmap
        {
            get;
            private set;
        }

        public int[] bitArray
        {
            get;
            private set;
        }

        public bool dispose
        {
            get;
            private set;
        }

        public int height
        {
            get;
            private set;
        }

        public int width
        {
            get;
            private set;
        }

        protected GCHandle bitArrayHandle
        {
            get;
            private set;
        }

        public DirectBitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
            bitArray = new int[width * height];
            bitArrayHandle = GCHandle.Alloc(bitArray, GCHandleType.Pinned);

            int stride = width * 4;
            bitmap = new Bitmap(width, height, stride, PixelFormat.Format32bppPArgb, bitArrayHandle.AddrOfPinnedObject());
        }

        public void setPixel(int x, int y, Color color)
        {
            int index = x + y * width;
            int colorValue = color.ToArgb();
            bitArray[index] = colorValue;
        }

        public Color getPixel(int x, int y)
        {
            int index = x + y * width;
            int colorValue = bitArray[index];
            return Color.FromArgb(colorValue);
        }

        public void Dispose()
        {
            if (dispose)
            {
                return;
            }
            dispose = true;
            bitmap.Dispose();
            bitArrayHandle.Free();
        }
    }
}