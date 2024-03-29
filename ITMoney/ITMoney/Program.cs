﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITMoney
{
    public static class Program
    {
        private const string inputFolder = "Input";
        private const string outputFolder = "Output";

        private static IList<Movable> movable;
        private static IList<Nonexpendable> nonexpendable;

        private static readonly Array moneyType = Enum.GetValues(typeof(MoneyType));
        private static readonly IDictionary<MoneyType, int> totalMoney = new Dictionary<MoneyType, int>();
        private static readonly IDictionary<MoneyType, IList<PropertyBase>> totalItem = new Dictionary<MoneyType, IList<PropertyBase>>();

        static Program()
        {
            foreach (MoneyType type in moneyType)
            {
                totalMoney[type] = 0;
            }

            foreach (MoneyType type in moneyType)
            {
                totalItem[type] = new List<PropertyBase>();
            }

            Console.WriteLine("正在讀取檔案 ...");
            try
            {
                movable = CSVReader.readMovableCSV(Path.Combine(inputFolder, "動產.csv"));
                nonexpendable = CSVReader.readNonexpendableCSV(Path.Combine(inputFolder, "非消耗品.csv"));
                Console.WriteLine("檔案讀取完成");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"讀取檔案時發生例外狀況 : {ex.Message}");
                pause();
                Environment.Exit(Constant.EXIT_FAILURE);
            }
        }

        public static void Main()
        {
            Console.WriteLine("正在處理原始檔案 ...");
            foreach (Movable data in movable)
            {
                MoneyType? type = Constant.getMoneyTypeByMovableNameROI(data);
                if (type.HasValue && data.getUseYear() >= 1)
                {
                    MoneyType typeValue = type.Value;
                    if (!MoneyTypeHandler.isFilterKeep(typeValue, data))
                    {
                        continue;
                    }

                    ExtendType? extend = MoneyTypeHandler.getExtendType(data);
                    if (extend.HasValue)
                    {
                        typeValue = (MoneyType)Enum.Parse(typeof(MoneyType), extend.Value.ToString());
                    }

                    if (typeValue == MoneyType.網路設備 && data.name == "防火牆")
                    {
                        data.feature = data.feature.Split('(')[0];
                    }
                    totalMoney[typeValue] += data.originValue;
                    totalItem[typeValue].Add(data);
                }
            }

            foreach (Nonexpendable data in nonexpendable)
            {
                MoneyType? type = Constant.getMoneyTypeByNonexpendableNameROI(data);
                if (type.HasValue && data.getUseYear() >= 1)
                {
                    MoneyType typeValue = type.Value;
                    if (!MoneyTypeHandler.isFilterKeep(typeValue, data))
                    {
                        continue;
                    }

                    ExtendType? extend = MoneyTypeHandler.getExtendType(data);
                    if (extend.HasValue)
                    {
                        typeValue = (MoneyType)Enum.Parse(typeof(MoneyType), extend.Value.ToString());
                    }
                    totalMoney[typeValue] += data.nowValue;
                    totalItem[typeValue].Add(data);
                }
            }
            Console.WriteLine("原始檔案處理完成");

            Console.WriteLine("正在輸出檔案 ...");
            try
            {
                using (FileStream fs = new FileStream(Path.Combine(outputFolder, "Total", "購置總價金項目.csv"), FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true)))
                    {
                        sw.WriteLine($"{Util.now.Year - 1911 + 1} 年編列硬體維護費用設備明細與金額");
                        sw.WriteLine("購置總價金項目");
                        sw.WriteLine("項目,購置總數,購置總價金");

                        int totalCountOutput = 0, totalMoneyOutput = 0;
                        foreach (MoneyType type in moneyType)
                        {
                            int count = totalItem[type].Count;
                            int money = totalMoney[type];
                            totalCountOutput += count;
                            totalMoneyOutput += money;
                            sw.WriteLine($"{type},{count},\"{Util.getReadableMoney(money)}\"");
                        }
                        sw.WriteLine($"合計,{totalCountOutput},\"{Util.getReadableMoney(totalMoneyOutput)}\"");

                        decimal maintenance = Math.Ceiling(totalMoneyOutput * 0.01M);
                        sw.WriteLine($"編列維護費用 (1 %),,\"{Util.getReadableMoney(maintenance)}\"");
                        sw.WriteLine($"進位至千元,,\"{Util.getReadableMoney(Math.Ceiling(maintenance / 1000) * 1000)}\"");
                    }
                }

                int index = 0;
                foreach (MoneyType type in moneyType)
                {
                    string fileName = (index + 1).ToString();
                    if (fileName.Length < 2)
                    {
                        fileName = "0" + fileName;
                    }
                    fileName += $"、{type}.csv";

                    using (FileStream fs = new FileStream(Path.Combine(outputFolder, "Item", fileName), FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true)))
                        {
                            sw.WriteLine($"{getNumberByIndex(index++)}{type}");
                            sw.WriteLine("財產編號,財產名稱,特徵及說明,購置日期,使用年限,原始價值,保管單位,已使用年數");

                            IList<PropertyBase> item = totalItem[type];
                            foreach (PropertyBase output in item)
                            {
                                sw.WriteLine(output.getOutputROI());
                            }
                            sw.WriteLine($"購置總價金{delimiter(5)}\"{Util.getReadableMoney(totalMoney[type])}\"{delimiter(2)}");
                        }
                    }
                }

                Console.WriteLine("檔案輸出完成");
                pause();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"輸出檔案時發生例外狀況 : {ex.Message}");
                pause();
                Environment.Exit(Constant.EXIT_FAILURE);
            }
        }

        private static string getNumberByIndex(int index)
        {
            const string number = "一二三四五六七八九十";
            return $"{number[index]}、";
        }

        private static void pause()
        {
            Console.WriteLine("請按任意鍵繼續 ... ");
            Console.ReadKey(true);
        }

        private static string delimiter(int count)
        {
            return new string(',', count);
        }
    }
}