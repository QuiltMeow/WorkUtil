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
        private static readonly IDictionary<MoneyType, Func<PropertyBase, bool>> filterDictionary = new Dictionary<MoneyType, Func<PropertyBase, bool>>()
        {
            { MoneyType.伺服器, property => property.keepUnit == "秘書室" && !isOutfield(property) },
            { MoneyType.網路設備, property => property.keepUnit == "秘書室" && property.serial != "6011420-000011" },
            { MoneyType.個人電腦,
                property => {
                    string source = property.getSource;
                    return !(source.Contains("租賃") || source.Contains("撥入"));
                }
            },
            { MoneyType.影印設備,
                property => {
                    string feature = property.feature;
                    string source = property.getSource;
                    return !(feature.Contains("監聽") || feature.Contains("一維") || feature.Contains("手持") || feature.Contains("標籤") || isOutfield(property) || source.Contains("租賃") || source.Contains("撥入"));
                }
            },
            { MoneyType.顯示器,
                property => {
                    const string MONITOR = "監視";
                    string feature = property.feature;
                    string keepPlace = property.keepPlace;
                    return !(feature.Contains(MONITOR) || feature.Contains("導引") || feature.Contains("櫃台") || feature.Contains("櫃檯") || feature.Contains("觸控") || property.getSource.Contains("撥入") || keepPlace.Contains(MONITOR) || keepPlace.Contains("暫管")) && property.serial != "6011409-000438";
                }
            },
            { MoneyType.不斷電系統, property => property.keepUnit == "秘書室" && !isOutfield(property) },
            { MoneyType.儲存設備, property => !property.feature.Contains("隨身碟") && property.keepUnit == "秘書室" && !isOutfield(property) && !property.getSource.Contains("撥入") }
        };

        public static bool isFilterKeep(MoneyType type, PropertyBase property)
        {
            if (!filterDictionary.ContainsKey(type))
            {
                return true;
            }
            return filterDictionary[type](property);
        }

        public static bool isOutfield(PropertyBase property)
        {
            string place = property.keepPlace;
            return place.Contains("國館") || place.Contains("國父紀念館") || place.Contains("調解會") || place.Contains("調解委員會") || place.Contains("活動中心") || place.Contains("公園") || place.Contains("里長聯誼會") || place.Contains("調查站") || place.Contains("暫管") || place.Contains("帳務中心") || place.Contains("苗圃");
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