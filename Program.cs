using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace IndianStateCesusAnalyzer
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            ImportDataFromCsv obj = new ImportDataFromCsv("C:/Users/AKASH/source/repos/Cesus Analyzer/IndianStateCesusAnalyzer/IndianStateCesusAnalyzer/CensusData.csv");
            obj.ImportData();
        }
    }
}
