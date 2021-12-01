using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianStateCesusAnalyzer
{
    public class ImportDataFromCsv
    {
        string importPath;
        public ImportDataFromCsv(string path)
        {
            this.importPath = path;
        }

        public int ImportData()
        {
            int count = 0;
            if (!File.Exists(importPath))
            {
                throw new StateCensusFileExcption("wrong File or File not exist");
            }
            if (Path.GetExtension(importPath) != ".csv")
            {
                throw new StateCensusTypeExcption("wrong type");
            }
            
            using (var reader = new StreamReader(importPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                try
                {
                    var records = csv.GetRecords<CesusData>().ToList();
                

                Console.WriteLine("read data succesfully done");
                    foreach (CesusData add in records)
                    {
                        count++;
                        Console.Write(" " + add.State);
                        Console.Write(" " + add.Population);
                        Console.Write(" " + add.Density);
                        Console.Write(" " + add.Literacy);
                        Console.WriteLine("\n");
                    }
                }
                catch (HeaderValidationException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return count;
        }

    }
}
