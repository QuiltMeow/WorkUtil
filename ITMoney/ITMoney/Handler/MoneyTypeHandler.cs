using System;
using System.Collections.Generic;

namespace ITMoney
{
    public enum MoneyType
    {
        伺服器,
        網路設備,
        個人電腦,
        筆記型電腦,
        平板電腦,
        影印設備,
        顯示器,
        不斷電系統,
        儲存設備,
        電腦硬體零件
    }

    public enum ExtendType
    {
        筆記型電腦,
        平板電腦
    }

    public static class MoneyTypeHandler
    {
        private static readonly IDictionary<MoneyType, Func<RealBase, bool>> filterDictionary = new Dictionary<MoneyType, Func<RealBase, bool>>()
        {
            { MoneyType.伺服器, property => property.keepUnit == "秘書室" },
            { MoneyType.網路設備, property => property.keepUnit == "秘書室" && property.propertyId != "6011420-000011" },
            { MoneyType.個人電腦,
                property => {
                    string source = property.obtainFrom;
                    return !(source.Contains("租賃") || source.Contains("撥入"));
                }
            },
            { MoneyType.影印設備,
                property => {
                    string feature = property.feature;
                    string source = property.obtainFrom;
                    return !(feature.Contains("監聽") || feature.Contains("一維") || feature.Contains("手持") || feature.Contains("標籤") || source.Contains("租賃") || source.Contains("撥入"));
                }
            },
            { MoneyType.顯示器,
                property => {
                    const string MONITOR = "監視";
                    string feature = property.feature;
                    string storePlace = property.storePlace1;
                    return !(feature.Contains(MONITOR) || feature.Contains("導引") || feature.Contains("櫃台") || feature.Contains("櫃檯") || feature.Contains("觸控") || property.obtainFrom.Contains("撥入") || storePlace.Contains(MONITOR) || storePlace.Contains("暫管")) && property.propertyId != "6011409-000438";
                }
            },
            { MoneyType.不斷電系統, property => property.keepUnit == "秘書室" },
            { MoneyType.儲存設備, property => property.keepUnit == "秘書室" && !property.obtainFrom.Contains("撥入") }
        };

        public static bool isFilterKeep(MoneyType type, RealBase property)
        {
            if (!filterDictionary.ContainsKey(type))
            {
                return true;
            }

            if (isOutfield(property))
            {
                return false;
            }
            return filterDictionary[type](property);
        }

        public static bool isOutfield(RealBase property)
        {
            string place = property.storePlace1;
            return place.Contains("國館") || place.Contains("國父紀念館") || place.Contains("活動中心") || place.Contains("公園") || place.Contains("崗亭") || place.Contains("辦公處") || place.Contains("里辦公室") || place.Contains("里長聯誼會") || place.Contains("調查站") || place.Contains("暫管") || place.Contains("帳務中心") || place.Contains("苗圃");
        }

        public static ExtendType? getExtendType(PropertyBase property)
        {
            string feature = property.feature;
            string lower = feature.ToLower();
            if (lower.Contains("iPad".ToLower()) || feature.Contains("平板"))
            {
                return ExtendType.平板電腦;
            }

            if (feature.Contains("筆電") || lower.Contains("Book".ToLower()) || feature.Contains("筆記型"))
            {
                return ExtendType.筆記型電腦;
            }
            return null;
        }
    }
}