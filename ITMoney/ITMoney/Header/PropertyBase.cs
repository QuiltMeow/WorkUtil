using CsvHelper.Configuration.Attributes;
using System.Reflection;

namespace ITMoney
{
    public abstract class PropertyBase
    {
        [Name("機關名稱")]
        public string organize
        {
            get;
            set;
        }

        [Name("特徵及說明")]
        public string feature
        {
            get;
            set;
        }

        [Name("購置日期")]
        public string buyDate
        {
            get;
            set;
        }

        [Name("使用年限")]
        public int ageLimit
        {
            get;
            set;
        }

        [Name("保管單位")]
        public string keepUnit
        {
            get;
            set;
        }

        [Name("保管人")]
        public string keeper
        {
            get;
            set;
        }

        [Name("使用人")]
        public string user
        {
            get;
            set;
        }

        [Name("備註一")]
        public string memo1
        {
            get;
            set;
        }

        [Name("備註二")]
        public string memo2
        {
            get;
            set;
        }

        [Name("取得來源")]
        public string obtainFrom
        {
            get;
            set;
        }

        [Name("經費來源")]
        public string fundFrom
        {
            get;
            set;
        }

        [Name("使用狀態")]
        public string useState
        {
            get;
            set;
        }

        [Name("用途")]
        public string purpose
        {
            get;
            set;
        }

        [Name("單位")]
        public string unit
        {
            get;
            set;
        }

        [Name("廠商")]
        public string manufacturer
        {
            get;
            set;
        }

        [Name("入帳日期")]
        public string postDate
        {
            get;
            set;
        }

        public decimal getUseYear()
        {
            return Util.getUseYear(buyDate);
        }

        public void trimAll()
        {
            PropertyInfo[] property = GetType().GetProperties();
            foreach (PropertyInfo info in property)
            {
                string data = info.GetValue(this).ToString().Trim();
                info.SetValue(this, data);
            }
        }
    }
}