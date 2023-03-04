using System.Collections.Generic;
using System.IO;

namespace ITMoney
{
    public static class CSVReader
    {
        public static IList<Movable> readMovableCSV(string fileName)
        {
            IList<Movable> ret = new List<Movable>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split(',');

                        Movable movable = new Movable()
                        {
                            serial = split[0],
                            name = split[1],
                            feature = split[2],
                            buyDate = split[3],
                            useLimitYear = int.Parse(split[4]),
                            originValue = int.Parse(split[5]),
                            getValue = int.Parse(split[6]),
                            bookValue = int.Parse(split[7]),
                            keepUnit = split[8],
                            keepUser = split[9],
                            keepPlace = split[10],
                            memo = split[11],
                            getSource = split[12],
                            getDate = split[13],
                            deviceId = split[14]
                        };
                        ret.Add(movable);
                    }
                }
            }
            return ret;
        }

        public static IList<Nonexpendable> readNonexpendableCSV(string fileName)
        {
            IList<Nonexpendable> ret = new List<Nonexpendable>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split(',');

                        Nonexpendable nonexpendable = new Nonexpendable()
                        {
                            serial = split[0],
                            name = split[1],
                            feature = split[2],
                            buyDate = split[3],
                            useLimitYear = int.Parse(split[4]),
                            originValue = int.Parse(split[5]),
                            keepUnit = split[6],
                            keepUser = split[7],
                            useUser = split[8],
                            keepPlace = split[9],
                            memo = split[10],
                            getSource = split[11],
                            getDate = split[12],
                            deviceId = split[13]
                        };
                        ret.Add(nonexpendable);
                    }
                }
            }
            return ret;
        }
    }
}