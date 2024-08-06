using CsvHelper.Configuration.Attributes;

namespace ITMoney
{
    public class Software : PropertyBase
    {
        [Name("軟體編號")]
        public string softwareId
        {
            get;
            set;
        }

        [Name("軟體名稱")]
        public string softwareName
        {
            get;
            set;
        }

        [Name("版本")]
        public string version
        {
            get;
            set;
        }

        [Name("使用期限")]
        public string useExpirationDate
        {
            get;
            set;
        }

        [Name("原始金額")]
        public string originMoney
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

        [Name("存放地點")]
        public string storePlace
        {
            get;
            set;
        }

        [Name("啟用日期")]
        public string activateDate
        {
            get;
            set;
        }

        [Name("軟體存放媒體")]
        public string softwareStoreMedia
        {
            get;
            set;
        }

        [Name("授權人數")]
        public string licenseUserCount
        {
            get;
            set;
        }

        [Name("授權序號S/N")]
        public string serialNumber
        {
            get;
            set;
        }

        [Name("授權日期起")]
        public string licenseDateFrom
        {
            get;
            set;
        }

        [Name("授權日期訖")]
        public string licenseDateTo
        {
            get;
            set;
        }

        [Name("是否入帳")]
        public string shouldPost
        {
            get;
            set;
        }

        [Name("攤銷方式")]
        public string revokeMethod
        {
            get;
            set;
        }
    }
}