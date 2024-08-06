using System;
using System.Drawing;
using System.IO;

namespace EmptyFileGenerator
{
    public static class Program
    {
        private static readonly Random random = new Random();

        public static Color randomColor()
        {
            const int RANGE = 256;
            return Color.FromArgb(random.Next(RANGE), random.Next(RANGE), random.Next(RANGE), random.Next(RANGE));
        }

        public static void generateGarbageImage(int count, int width, int height, string prefix)
        {
            for (int i = 1; i <= count; ++i)
            {
                DirectBitmap image = new DirectBitmap(width, height);
                for (int x = 0; x < image.width; ++x)
                {
                    for (int y = 0; y < image.height; ++y)
                    {
                        image.setPixel(x, y, randomColor());
                    }
                }
                image.bitmap.Save($"{prefix}_{i}.png");
            }
        }

        public static void generateEmptyFile(string fileName, int size)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.SetLength(size);
            }
        }

        public static void Main()
        {
            const string fileName = "Output.bin";
            const int size = 10 * 1024 * 1024;
            generateEmptyFile(fileName, size);
        }
    }
}