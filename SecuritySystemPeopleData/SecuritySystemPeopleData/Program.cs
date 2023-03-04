using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecuritySystemPeopleData
{
    public static class Program
    {
        public const string INPUT_PATH = "Input";
        public const string OUTPUT_PATH = "Output";

        private static readonly UTF8Encoding bom = new UTF8Encoding(true);
        private static readonly IList<Person> people = new List<Person>();

        private static readonly IList<Contact> contactData;
        private static readonly IList<Regular> regularData;
        private static readonly IList<Security> securityData;
        private static readonly IList<Temporary> temporaryData;
        private static readonly IDictionary<string, string> unitMap = new Dictionary<string, string>();
        private static readonly IDictionary<string, string> jobMap = new Dictionary<string, string>();

        private static int automaticUnit = 20;
        private static int automaticJob = 10000;
        private static int automaticCardId = 1000000000;
        private static string lastMonth = DateTime.Now.AddMonths(-1).ToString("yyyyMMdd");
        private static readonly ISet<string> cardSet = new HashSet<string>();

        static Program()
        {
            Console.WriteLine("讀取輸入檔案 ...");
            try
            {
                contactData = CSVReader.readContactCSV(Path.Combine(INPUT_PATH, "Contact.csv"));
                regularData = CSVReader.readRegularCSV(Path.Combine(INPUT_PATH, "Regular.csv"));
                securityData = CSVReader.readSecurityCSV(Path.Combine(INPUT_PATH, "Security.csv"));
                temporaryData = CSVReader.readTemporaryCSV(Path.Combine(INPUT_PATH, "Temporary.csv"));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"處理輸入檔案時發生例外狀況 : {ex.Message}");
            }
        }

        public static bool containValue<K, V>(IDictionary<K, V> map, V value)
        {
            foreach (KeyValuePair<K, V> pair in map)
            {
                if (pair.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        private static string getUnitId(string unit)
        {
            if (unit == "所本部")
            {
                unit = "本機關";
            }

            if (unitMap.ContainsKey(unit))
            {
                return unitMap[unit];
            }

            bool assign = false;
            while (!assign)
            {
                if (containValue(unitMap, automaticUnit.ToString()))
                {
                    ++automaticUnit;
                    continue;
                }
                assign = true;
            }

            string ret = automaticUnit.ToString();
            unitMap[unit] = ret;
            Console.Error.WriteLine($"找不到 {unit} 的單位 ID，以 ID {ret} 進行指派");
            return ret;
        }

        private static string getJobId(string job)
        {
            if (jobMap.ContainsKey(job))
            {
                return jobMap[job];
            }

            bool assign = false;
            while (!assign)
            {
                if (containValue(jobMap, automaticJob.ToString()))
                {
                    ++automaticJob;
                    continue;
                }
                assign = true;
            }

            string ret = automaticJob.ToString();
            jobMap[job] = ret;
            Console.Error.WriteLine($"找不到 {job} 的職稱 ID，以 ID {ret} 進行指派");
            return ret;
        }

        private static string toADDate(string twDate)
        {
            string twYear = twDate.Substring(0, twDate.Length - 4);
            int length = twYear.Length;
            if (twYear[0] == '0')
            {
                twYear = twYear.Substring(1);
            }
            int ADYear = 1911 + int.Parse(twYear);
            return ADYear + twDate.Substring(length);
        }

        private static bool fillPersonalData(Person person)
        {
            string name = person.name;
            string account = person.account;
            foreach (Regular regular in regularData)
            {
                if (name == regular.name)
                {
                    person.gender = regular.gender;
                    person.arriveDate = toADDate(regular.arriveDate);
                    return true;
                }
            }
            foreach (Temporary temporary in temporaryData)
            {
                if (name == temporary.name)
                {
                    person.gender = temporary.gender;
                    person.arriveDate = toADDate(temporary.arriveDate);
                    return true;
                }
            }

            if (person.gender == null)
            {
                person.gender = "M";
                Console.Error.WriteLine($"找不到 {name} ({account}) 的性別資料，以 M 進行資料填充");
            }

            if (person.arriveDate == null)
            {
                person.arriveDate = lastMonth;
                Console.Error.WriteLine($"找不到 {name} ({account}) 的到職日期，以上個月進行資料填充");
            }
            return false;
        }

        // 廢棄，因表單要求 10 碼
        public static bool fillCardId(Person person)
        {
            string name = person.name;
            string account = person.account;
            foreach (Security security in securityData)
            {
                if (account == security.account)
                {
                    string cardId = security.cardId;
                    if (!cardSet.Add(cardId))
                    {
                        Console.Error.WriteLine($"{name} ({account}) 重複卡片 ID : {cardId}，重新指派");
                        break;
                    }
                    person.cardId = cardId;
                    return true;
                }
            }

            if (person.cardId == null)
            {
                bool assign = false;
                while (!assign)
                {
                    string assignCardId = automaticCardId.ToString();
                    if (cardSet.Contains(assignCardId))
                    {
                        ++automaticCardId;
                        continue;
                    }
                    cardSet.Add(assignCardId);
                    assign = true;
                }

                string cardId = automaticCardId.ToString();
                person.cardId = cardId;
                Console.Error.WriteLine($"找不到 {name} ({account}) 的原指紋機卡片 ID，以 ID {cardId} 進行指派");
            }
            return false;
        }

        private static void outputUnitTable(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, bom))
                {
                    sw.WriteLine("單位 ID,單位名稱");
                    foreach (KeyValuePair<string, string> pair in unitMap)
                    {
                        sw.WriteLine($"{pair.Value},{pair.Key}");
                    }
                }
            }
        }

        private static void outputJobTable(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, bom))
                {
                    sw.WriteLine("職稱 ID,職稱");
                    foreach (KeyValuePair<string, string> pair in jobMap)
                    {
                        sw.WriteLine($"{pair.Value},{pair.Key}");
                    }
                }
            }
        }

        private static void outputPeople(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, bom))
                {
                    sw.WriteLine("   員工編號   ,   姓    名   ,   部門代碼   ,   職稱代碼   ,   性別 (M/F)   ,   到職日 (YYYYMMDD)   ,   離職日 (YYYYMMDD)   ,   聯絡電話   ,   手機號碼   ,                        E-MAIL                        ,   區域名稱   ,   卡片密碼   ,   系統碼   ,   員工卡號   ,   卡片有效 起始日期 (YYYYMMDD)   ,   卡片有效 結束日期 (YYYYMMDD)   ,\"   記錄出勤 (Y/空白為是,N為否)   \",\"   班表種類 (1:固定,2/空白:計時,3:輪班)   \",   班表名稱   ,   輪班參照班表   ,   假日加班設定   ,   依勞基法特別休假 (填 N 為否，空白為是。)   ,   特休時數 (HH:mm)   ,   特休起迄 開始日期 (YYYYMMDD)   ,   特休起迄 結束日期 (YYYYMMDD)   ,           備                             註           ");
                    foreach (Person person in people)
                    {
                        sw.WriteLine(person.getOutputROI());
                    }
                }
            }
        }

        public static void Main()
        {
            Console.WriteLine("建置 ID 對照表 ...");
            foreach (Regular data in regularData)
            {
                unitMap[data.unit] = data.unitId;
                jobMap[data.job] = data.jobId;
            }

            Console.WriteLine("合併輸入資料 ...");
            foreach (Contact contact in contactData)
            {
                people.Add(new Person(contact)
                {
                    unitId = getUnitId(contact.unit),
                    jobId = getJobId(contact.job)
                });
            }

            foreach (Person person in people)
            {
                fillPersonalData(person);
                // fillCardId(person);
                person.cardId = (automaticCardId++).ToString();
            }

            Console.WriteLine("輸出檔案 ...");
            try
            {
                outputUnitTable(Path.Combine(OUTPUT_PATH, "Unit.csv"));
                outputJobTable(Path.Combine(OUTPUT_PATH, "Job.csv"));
                outputPeople(Path.Combine(OUTPUT_PATH, "Output.csv"));
                Console.WriteLine("檔案輸出完成");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"輸出檔案時發生例外狀況 : {ex.Message}");
            }

            Console.Write("請按任意鍵繼續 ... ");
            Console.ReadKey(true);
        }
    }
}