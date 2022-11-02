using System;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;

namespace SchoolDatas
{
    class Program
    {
        static List<KommunData> kommuner = new List<KommunData>();
        static List<SkolverksamhetData> skolverksamhet = new List<SkolverksamhetData>();
        static List<Skolor> skolor = new List<Skolor>();

        static CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
        };

        static void Main(string[]args)
        {
            using(var sr = new StreamReader("kommuner.csv"))
            {
                using(var csvReader = new CsvReader(sr, configuration))
                {
                    csvReader.Context.RegisterClassMap<KommunMap>();
                    kommuner = csvReader.GetRecords<KommunData>().ToList();
                }
            }

            using(var sr = new StreamReader("skolverksamhet.csv"))
            {
                using(var csvReader = new CsvReader(sr, configuration))
                {
                    csvReader.Context.RegisterClassMap<SkolverksamhetMap>();
                    skolverksamhet = csvReader.GetRecords<SkolverksamhetData>().ToList();
                }
            }

            foreach(var skola in skolverksamhet)
            {
                string kommun = "";
                try{
                    kommun = kommuner.Find(x=>x.Kod == skola.Kod).Kommun;
                    skolor.Add(new Skolor(skola.Kod, kommun, skola.Skolenhetsnamn, skola.Grundskola, skola.Förskola, skola.Fritidshem));
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine($"Kunde inte hitta kommun med kod: {skola.Kod}. (Skolenhetsnamn: {skola.Skolenhetsnamn})");
                }
                
            }

            using(var sw = new StreamWriter("skoldata.csv"))
            {
                using (var csvWriter = new CsvWriter(sw, configuration))
                {
                    csvWriter.Context.RegisterClassMap<SkolMap>();
                    csvWriter.WriteRecords(skolor);
                }
            }
        }
    }
}









   

    

  




