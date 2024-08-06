using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GroupListHandler
{
    public static class CSVHandler
    {
        public static IList<T> parseCSV<T>(string csv, Type nameMapType = null)
        {
            using (StringReader sr = new StringReader(csv))
            {
                using (CsvReader reader = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    if (nameMapType != null)
                    {
                        reader.Context.RegisterClassMap(nameMapType);
                    }
                    return reader.GetRecords<T>().ToList();
                }
            }
        }

        private static void addCleanUpGroup(this IList<GroupData> list, GroupData element)
        {
            if (element != null)
            {
                element.cleanUp();
                list.Add(element);
            }
        }

        private static void addGroupDataToStringList(IList<string[]> target, IList<GroupData> data)
        {
            target.Add(GroupData.getHeaderArray());
            foreach (GroupData group in data)
            {
                target.Add(group.getDataArray());
            }
        }

        public static IList<string[]> cleanUpNameList(string csv)
        {
            IList<GroupData> output = new List<GroupData>();
            IList<GroupData> record = parseGroupCSV(csv);
            GroupData concat = null;
            foreach (GroupData group in record)
            {
                if (int.TryParse(group.id, out _))
                {
                    output.addCleanUpGroup(concat);
                    concat = group;
                }
                else
                {
                    PropertyInfo[] propertyData = typeof(GroupData).GetProperties();
                    foreach (PropertyInfo property in propertyData)
                    {
                        string last = property.GetValue(concat).ToString();
                        string now = property.GetValue(group).ToString();
                        property.SetValue(concat, last + now);
                    }
                }
            }
            output.addCleanUpGroup(concat);

            IList<string[]> ret = new List<string[]>();
            addGroupDataToStringList(ret, output);
            return ret;
        }

        public static IList<T> compareList<T>(IList<T> left, IList<T> right)
        {
            IList<T> ret = new List<T>();
            foreach (T leftElement in left)
            {
                bool contain = false;
                foreach (T rightElement in right)
                {
                    if (leftElement.Equals(rightElement))
                    {
                        contain = true;
                        break;
                    }
                }

                if (!contain)
                {
                    ret.Add(leftElement);
                }
            }
            return ret;
        }

        public static IList<GroupData> compareGroupDataList(IList<GroupData> left, IList<GroupData> right)
        {
            IList<GroupData> ret = new List<GroupData>();
            foreach (GroupData leftElement in left)
            {
                bool contain = false;
                foreach (GroupData rightElement in right)
                {
                    if (leftElement.equalData(rightElement))
                    {
                        contain = true;
                        break;
                    }
                }

                if (!contain)
                {
                    ret.Add(leftElement);
                }
            }
            return ret;
        }

        private static IList<GroupData> parseGroupCSV(string csv)
        {
            return parseCSV<GroupData>(csv, typeof(GroupMap));
        }

        public static IList<string[]> outputCompareResult(string leftCSV, string rightCSV)
        {
            IList<GroupData> leftData = parseGroupCSV(leftCSV);
            IList<GroupData> rightData = parseGroupCSV(rightCSV);

            IList<GroupData> onlyLeft = compareGroupDataList(leftData, rightData);
            IList<GroupData> onlyRight = compareGroupDataList(rightData, leftData);

            IList<string[]> ret = new List<string[]>()
            {
                new string[] {
                    "僅左邊（移除）"
                }
            };
            addGroupDataToStringList(ret, onlyLeft);
            ret.Add(new string[] {
            });

            ret.Add(new string[] {
                "僅右邊（新增）"
            });
            addGroupDataToStringList(ret, onlyRight);
            return ret;
        }
    }
}