using System.Collections.Generic;

namespace ITMoney
{
    public static class Constant
    {
        public const int EXIT_FAILURE = 1;

        private static readonly IList<KeyValuePair<MoneyType, string>> movableNameROI = new List<KeyValuePair<MoneyType, string>>() {
            new KeyValuePair<MoneyType, string>(MoneyType.個人電腦, "個人電腦"),
            new KeyValuePair<MoneyType, string>(MoneyType.伺服器, "伺服器"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "複合機"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "影印機"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "印表機"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "數據機"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "A3彩色雷射印表機"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "網路交換器"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "防火牆"),
            new KeyValuePair<MoneyType, string>(MoneyType.不斷電系統, "不中斷電源設備"),
            new KeyValuePair<MoneyType, string>(MoneyType.個人電腦, "個人電腦網路"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "掃描器"),
            new KeyValuePair<MoneyType, string>(MoneyType.儲存設備, "硬式磁碟機"),
            new KeyValuePair<MoneyType, string>(MoneyType.電腦硬體零件, "主記憶體"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "48埠網路交換器"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "掃瞄器")
        };

        private static readonly IList<KeyValuePair<MoneyType, string>> nonexpendableNameROI = new List<KeyValuePair<MoneyType, string>>()
        {
            new KeyValuePair<MoneyType, string>(MoneyType.顯示器, "什項用具-顯示器(螢幕)"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "什項用具-數據機"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "複印用具-印表機"),
            new KeyValuePair<MoneyType, string>(MoneyType.不斷電系統, "什項用具-不斷電系統"),
            new KeyValuePair<MoneyType, string>(MoneyType.儲存設備, "什項用具-外接式磁碟"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "文書用具-事務機"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "複印用具-掃描器"),
            new KeyValuePair<MoneyType, string>(MoneyType.顯示器, "液晶螢幕"),
            new KeyValuePair<MoneyType, string>(MoneyType.儲存設備, "文書用品-磁碟機"),
            new KeyValuePair<MoneyType, string>(MoneyType.個人電腦, "文書用具-電腦主機"),
            new KeyValuePair<MoneyType, string>(MoneyType.影印設備, "A3彩色噴墨印表機"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "什項用具-基地台"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "什項用具-路由器"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "文書用具-網路卡"),
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "什項用具-集線器")
        };

        private static readonly IList<KeyValuePair<MoneyType, string>> movableAddFeature = new List<KeyValuePair<MoneyType, string>>()
        {
        };

        private static readonly IList<KeyValuePair<MoneyType, string>> nonexpendableAddFeature = new List<KeyValuePair<MoneyType, string>>()
        {
            new KeyValuePair<MoneyType, string>(MoneyType.網路設備, "網路轉換器Zyxel GS900-16"),
            new KeyValuePair<MoneyType, string>(MoneyType.儲存設備, "6TB硬碟")
        };

        public static MoneyType? getMoneyTypeByMovableNameROI(Movable movable)
        {
            foreach (KeyValuePair<MoneyType, string> pair in movableAddFeature)
            {
                if (movable.feature == pair.Value)
                {
                    return pair.Key;
                }
            }

            foreach (KeyValuePair<MoneyType, string> pair in movableNameROI)
            {
                if (movable.name == pair.Value)
                {
                    return pair.Key;
                }
            }
            return null;
        }

        public static MoneyType? getMoneyTypeByNonexpendableNameROI(Nonexpendable nonexpendable)
        {
            foreach (KeyValuePair<MoneyType, string> pair in nonexpendableAddFeature)
            {
                if (nonexpendable.feature == pair.Value)
                {
                    return pair.Key;
                }
            }

            foreach (KeyValuePair<MoneyType, string> pair in nonexpendableNameROI)
            {
                if (nonexpendable.name == pair.Value)
                {
                    return pair.Key;
                }
            }
            return null;
        }
    }
}