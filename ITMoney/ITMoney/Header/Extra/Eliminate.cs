using CsvHelper.Configuration.Attributes;

namespace ITMoney
{
    public class Eliminate
    {
        [Name("編號")]
        public string id
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

        [Name("財產名稱")]
        public string name
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

        [Name("機關")]
        public string organize
        {
            get;
            set;
        }

        [Name("保管單位/科室")]
        public string keepUnit
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

        public Eliminate()
        {
        }

        public Eliminate(Eliminate copy)
        {
            id = copy.id;
            deviceId = copy.deviceId;
            name = copy.name;
            feature = copy.feature;
            organize = copy.organize;
            keepUnit = copy.keepUnit;
            storePlace = copy.storePlace;
        }
    }
}