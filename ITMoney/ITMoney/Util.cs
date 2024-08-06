using System;
using System.Collections.Generic;
using System.IO;

namespace ITMoney
{
    public static class Util
    {
        public static readonly DateTime now = DateTime.Now;

        public static int getUseDay(string taiwanDate)
        {
            string[] split = taiwanDate.Split('/');
            int year = 1911 + int.Parse(split[0]);
            DateTime date = new DateTime(year, int.Parse(split[1]), int.Parse(split[2]));
            TimeSpan result = now - date;
            return result.Days;
        }

        public static decimal getUseYear(string taiwanDate)
        {
            string[] split = taiwanDate.Split('/');
            int year = 1911 + int.Parse(split[0]);
            DateTime date = new DateTime(year, int.Parse(split[1]), int.Parse(split[2]));

            decimal ret = 0;
            int nowYear = now.Year;
            for (int i = year; i <= nowYear; ++i)
            {
                if (i == nowYear)
                {
                    DateTime start = new DateTime(i, 1, 1);
                    DateTime end = now;
                    TimeSpan span = end - start;
                    ret += Convert.ToDecimal(span.Days) / getDayYearCount(i);
                    continue;
                }

                if (i == year)
                {
                    DateTime start = date;
                    DateTime end = new DateTime(i, 12, 31);
                    TimeSpan span = end - start;
                    ret += Convert.ToDecimal(span.Days) / getDayYearCount(i);
                    continue;
                }
                ++ret;
            }
            return ret;
        }

        public static string getReadableMoney(decimal money)
        {
            return money.ToString("N0");
        }

        public static int getDayYearCount(int year)
        {
            return DateTime.IsLeapYear(year) ? 366 : 365;
        }

        public static IList<string> loadLineString(string fileName)
        {
            return new List<string>(File.ReadAllText(fileName).removeAll("\r").Split('\n'));
        }

        public static void writeStringList(string fileName, IList<string> data)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (string line in data)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }
    }
}