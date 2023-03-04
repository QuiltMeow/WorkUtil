using System;
using System.Drawing;
using System.IO;

namespace EmptyFileGenerator
{
    public static class Program
    {
        public const int BYTE_RANGE = 256;
        private static readonly Random random = new Random();

        public static Color randomColor()
        {
            return Color.FromArgb(random.Next(BYTE_RANGE), random.Next(BYTE_RANGE), random.Next(BYTE_RANGE), random.Next(BYTE_RANGE));
        }

        public static byte randomByte()
        {
            return (byte)random.Next(BYTE_RANGE);
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

        public static void generateGarbageFile(string fileName, int size)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    for (int i = 1; i <= size; ++i)
                    {
                        bw.Write(randomByte());
                    }
                }
            }
        }

        private static void pause()
        {
            Console.Write("請按任意鍵繼續 ... ");
            Console.ReadKey(true);
        }

        public static void Main()
        {
            const string fileName = "Output.bin";
            const int size = 10 * 1024 * 1024;

            try
            {
                generateGarbageFile(fileName, size);
                Console.WriteLine("執行完畢");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"產生檔案時發生例外狀況 : {ex.Message}");
            }
            pause();
        }
    }
}