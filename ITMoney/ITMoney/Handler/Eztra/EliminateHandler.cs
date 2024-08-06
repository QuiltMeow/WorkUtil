using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ITMoney
{
    public static class EliminateHandler
    {
        public static IList<Eliminate> parseEliminateCSV(string fileName)
        {
            string csv = File.ReadAllText(fileName);
            return CSVHandler.parseCSV<Eliminate>(csv);
        }

        public static void outputEliminateCSV(string inputFile, string outputFile)
        {
            IList<Movable> movableList = CSVHandler.parseMovableCSV("動產.csv");
            IList<Eliminate> eliminateList = parseEliminateCSV(inputFile);

            IList<EliminateOutput> result = new List<EliminateOutput>();
            foreach (Eliminate data in eliminateList)
            {
                EliminateOutput output = new EliminateOutput(data);
                foreach (Movable movable in movableList)
                {
                    if (movable.deviceId == data.deviceId)
                    {
                        output.keepUnit = movable.keepUnit;
                        output.storePlace = movable.storePlace1;
                        output.propertyId = movable.propertyId;
                        output.keeper = movable.keeper;
                    }
                }
                result.Add(output);
            }

            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true)))
                {
                    using (CsvWriter writer = new CsvWriter(sw, CultureInfo.InvariantCulture))
                    {
                        writer.WriteRecords(result);
                    }
                }
            }
        }
    }
}