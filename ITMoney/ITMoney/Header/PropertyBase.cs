using System;

namespace ITMoney
{
    public abstract class PropertyBase
    {
        public string serial; // 財產編號

        public string name; // 財產名稱

        public string feature; // 特徵及說明

        public string buyDate; // 購置日期

        public int useLimitYear; // 使用年限

        public int originValue; // 原始價值

        public string keepUnit; // 保管單位

        public string keepUser; // 保管人

        public string keepPlace; // 存放地點

        public string memo; // 備註

        public string getSource; // 取得來源

        public string getDate; // 取得日期

        public string deviceId; // 設備編號

        public decimal getUseYear()
        {
            return Util.getUseYear(buyDate);
        }

        public string getOutputROI()
        {
            decimal useYear = Math.Ceiling(getUseYear() * 100) / 100;
            return $"{serial},{name},{feature},{buyDate},{useLimitYear},\"{Util.getReadableMoney(originValue)}\",{keepUnit},{useYear}";
        }
    }
}