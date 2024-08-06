using CsvHelper.Configuration.Attributes;

namespace ITMoney
{
    public abstract class RealBase : PropertyBase
    {
        [Name("財產編號")]
        public string propertyId
        {
            get;
            set;
        }

        [Name("財產名稱")]
        public string name
        {
            get;
            set;
        }

        [Name("存放地點一")]
        public string storePlace1
        {
            get;
            set;
        }

        [Name("存放地點二")]
        public string storePlace2
        {
            get;
            set;
        }

        [Name("取得日期")]
        public string obtainDate
        {
            get;
            set;
        }

        [Name("財產類別")]
        public string propertyType
        {
            get;
            set;
        }

        [Name("已使用年數")]
        public string yearUsed
        {
            get;
            set;
        }

        [Name("記帳字號")]
        public string accountId
        {
            get;
            set;
        }

        [Name("設備編號")]
        public string deviceId
        {
            get;
            set;
        }

        [Name("牌照號碼")]
        public string licenseNumber
        {
            get;
            set;
        }

        [Name("盤點結果")]
        public string inventoryResult
        {
            get;
            set;
        }

        [Name("盤點日期")]
        public string inventoryDate
        {
            get;
            set;
        }

        [Name("減損類別")]
        public string scrapType
        {
            get;
            set;
        }

        [Name("減損日期")]
        public string scrapDate
        {
            get;
            set;
        }

        [Name("確認減損日期")]
        public string confirmScrapDate
        {
            get;
            set;
        }

        [Name("更新人員")]
        public string updateStaff
        {
            get;
            set;
        }

        [Name("更新時間")]
        public string updateDate
        {
            get;
            set;
        }
    }
}