using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Employee
{
    public static class Program
    {
        public class Person
        {
            public string account
            {
                get;
                set;
            }

            public string name
            {
                get;
                set;
            }

            public string unit
            {
                get;
                set;
            }

            public string fingerId
            {
                get;
                set;
            }

            public string job
            {
                get;
                set;
            }

            public string cardId
            {
                get;
                set;
            }

            public bool hasRegister
            {
                get;
                set;
            }

            public string toCSVOutput()
            {
                return $"{account},{name},{fingerId},{unit},{job},{cardId},{(hasRegister ? "是" : "否")}";
            }
        }

        public static string[] readCSVLine(this StreamReader sr)
        {
            return sr.ReadLine().Split(',');
        }

        public static void skipLine(this StreamReader sr, int count)
        {
            for (int i = 1; i <= count; ++i)
            {
                if (sr.EndOfStream)
                {
                    return;
                }
                sr.ReadLine();
            }
        }

        private static void pause()
        {
            Console.Write("請按任意鍵繼續 ... ");
            Console.ReadKey(true);
        }

        public static void Main()
        {
            List<Person> personData = new List<Person>();
            Console.WriteLine("讀取輸入檔案 ...");
            try
            {
                using (FileStream fs = new FileStream("Data.csv", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            Person person = new Person();
                            person.name = sr.readCSVLine()[1];
                            person.account = sr.readCSVLine()[1];

                            string[] jobData = sr.readCSVLine();
                            person.job = jobData[1];
                            person.unit = jobData[3];

                            person.cardId = sr.readCSVLine()[1];
                            sr.skipLine(3);
                            person.fingerId = sr.readCSVLine()[1];
                            person.hasRegister = !string.IsNullOrWhiteSpace(sr.readCSVLine()[1]);
                            personData.Add(person);

                            sr.skipLine(4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"讀取輸入檔案時發生例外狀況 : {ex.Message}");
                pause();
                Environment.Exit(1);
            }

            Console.WriteLine("排序資料 ...");
            personData.Sort(delegate (Person left, Person right)
            {
                return left.account.CompareTo(right.account);
            });

            Console.WriteLine("輸出檔案 ...");
            try
            {
                using (FileStream fs = new FileStream("Output.csv", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true)))
                    {
                        sw.WriteLine("員工編號,姓名,指紋 ID,單位,職稱,卡號,已註冊指紋");
                        foreach (Person person in personData)
                        {
                            sw.WriteLine(person.toCSVOutput());
                        }
                    }
                }
                Console.WriteLine("全部處理完成");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"輸出檔案時發生例外狀況 : {ex.Message}");
            }
            pause();
        }
    }
}