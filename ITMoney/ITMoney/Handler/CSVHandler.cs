using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ITMoney
{
    public static class CSVHandler
    {
        public const int BIG_5_CODE_PAGE = 950;

        public static void simpleBadDataOutputHandler(BadDataFoundArgs argument)
        {
            Console.Error.WriteLine($"無效資料：{argument.RawRecord}");
        }

        public static IList<T> parseCSV<T>(string csv, Type nameMapType = null, BadDataFound badDataHandler = null)
        {
            using (StringReader sr = new StringReader(csv))
            {
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
                if (badDataHandler != null)
                {
                    config.BadDataFound = badDataHandler;
                }

                using (CsvReader reader = new CsvReader(sr, config))
                {
                    if (nameMapType != null)
                    {
                        reader.Context.RegisterClassMap(nameMapType);
                    }
                    return reader.GetRecords<T>().ToList();
                }
            }
        }

        public static IList<Movable> parseMovableCSV(string fileName, int codePage = BIG_5_CODE_PAGE, BadDataFound badDataHandler = null)
        {
            string csv = File.ReadAllText(fileName, Encoding.GetEncoding(codePage));
            return parseCSV<Movable>(csv, null, badDataHandler);
        }

        public static IList<Nonexpendable> parseNonexpendableCSV(string fileName, int codePage = BIG_5_CODE_PAGE, BadDataFound badDataHandler = null)
        {
            string csv = File.ReadAllText(fileName, Encoding.GetEncoding(codePage));
            return parseCSV<Nonexpendable>(csv, null, badDataHandler);
        }

        public static IList<Software> parseSoftwareCSV(string fileName, int codePage = BIG_5_CODE_PAGE, BadDataFound badDataHandler = null)
        {
            string csv = File.ReadAllText(fileName, Encoding.GetEncoding(codePage));
            return parseCSV<Software>(csv, null, badDataHandler);
        }
    }
}