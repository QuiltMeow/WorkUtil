using System.Collections.Generic;
using System.IO;

namespace SecuritySystemPeopleData
{
    public static class CSVReader
    {
        public static IList<Regular> readRegularCSV(string fileName)
        {
            IList<Regular> ret = new List<Regular>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split(',');
                        ret.Add(new Regular()
                        {
                            name = split[0],
                            arriveDate = split[1],
                            gender = split[3],
                            unitId = split[4],
                            unit = split[5],
                            jobId = split[6],
                            job = split[7]
                        });
                    }
                }
            }
            return ret;
        }

        public static IList<Security> readSecurityCSV(string fileName)
        {
            IList<Security> ret = new List<Security>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split(',');
                        ret.Add(new Security()
                        {
                            account = split[0],
                            cardId = split[1],
                            name = split[2]
                        });
                    }
                }
            }
            return ret;
        }

        public static IList<Temporary> readTemporaryCSV(string fileName)
        {
            IList<Temporary> ret = new List<Temporary>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split(',');
                        ret.Add(new Temporary()
                        {
                            job = split[2],
                            unit = split[3],
                            name = split[4],
                            gender = split[6],
                            arriveDate = split[7]
                        });
                    }
                }
            }
            return ret;
        }

        public static IList<Contact> readContactCSV(string fileName)
        {
            IList<Contact> ret = new List<Contact>();
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] split = line.Split(',');
                        ret.Add(new Contact()
                        {
                            name = split[0],
                            unit = split[1],
                            job = split[2],
                            account = split[3],
                            mail = split[4],
                            phone = split[5],
                            extension = split[6]
                        });
                    }
                }
            }
            return ret;
        }
    }
}