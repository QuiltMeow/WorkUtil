using CsvHelper.Configuration.Attributes;

namespace ITMoney
{
    public class Movable : RealBase
    {
        [Name("原始價值")]
        public string originValue
        {
            get;
            set;
        }

        [Name("取得價值")]
        public string obtainValue
        {
            get;
            set;
        }

        [Name("帳面價值")]
        public string accountValue
        {
            get;
            set;
        }

        [Name("累計折舊月數")]
        public string accumulateDepreciationMonth
        {
            get;
            set;
        }

        [Name("累計折舊金額")]
        public string accumulateDepreciationMoney
        {
            get;
            set;
        }

        [Name("來源已折舊月數")]
        public string depreciationMonthFrom
        {
            get;
            set;
        }

        [Name("來源已折舊金額")]
        public string depreciationMoneyFrom
        {
            get;
            set;
        }
    }
}