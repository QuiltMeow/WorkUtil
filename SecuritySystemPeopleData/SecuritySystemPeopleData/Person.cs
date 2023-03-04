using System;

namespace SecuritySystemPeopleData
{
    public class Person
    {
        private static readonly DateTime yesterday = DateTime.Now.AddDays(-1);
        private static readonly DateTime oneHundredYear = yesterday.AddYears(100);

        private static readonly string yesterdayString = yesterday.ToString("yyyyMMdd");
        private static readonly string oneHundredYearString = oneHundredYear.ToString("yyyyMMdd");

        // 員工編號
        public string account
        {
            get;
            set;
        }

        // 姓名
        public string name
        {
            get;
            set;
        }

        // 部門代碼
        public string unitId
        {
            get;
            set;
        }

        // 職稱代碼
        public string jobId
        {
            get;
            set;
        }

        // 性別
        public string gender
        {
            get;
            set;
        }

        // 到職日
        public string arriveDate
        {
            get;
            set;
        }

        // 聯絡電話
        public string fullPhone
        {
            get;
            set;
        }

        // 電子郵件
        public string mail
        {
            get;
            set;
        }

        // 員工卡號
        public string cardId
        {
            get;
            set;
        }

        public Person()
        {
        }

        public Person(Contact contact)
        {
            name = contact.name;
            account = contact.account;
            mail = contact.mail;

            string phone = contact.phone.Replace(")", ") ");
            string extension = contact.extension;
            if (extension != string.Empty)
            {
                phone += $"#{extension}";
            }
            fullPhone = phone;
        }

        public string getGenderId()
        {
            switch (gender)
            {
                case "男":
                    {
                        return "M";
                    }
                case "女":
                    {
                        return "F";
                    }
                default:
                    {
                        return gender;
                    }
            }
        }

        public string getOutputROI()
        {
            return $"{account},{name},{unitId},{jobId},{getGenderId()},{arriveDate},,{fullPhone},,{mail},新北,,,{cardId},{yesterdayString},{oneHundredYearString},Y,1,,,,,,,,";
        }
    }
}