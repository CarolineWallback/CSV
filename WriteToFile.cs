using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

public static class WriteToFile
{
    static CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";",
    };

    public static void WriteToCSVFile(List<Skola>skolor)
    {
        try
        {
            using(var sw = new StreamWriter("skoldata.csv"))
            {
                using (var csvWriter = new CsvWriter(sw, configuration))
                {
                    csvWriter.Context.RegisterClassMap<SkolMap>();
                    csvWriter.WriteRecords(skolor);
                }
            }
        }
        catch{
            Console.WriteLine("Could not save new file.");
        }
    }
}