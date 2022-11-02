using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

public static class ReadFiles
{
    static List<Skola> skolor = new List<Skola>();
    static List<Skolverksamhet> skolverksamheter = new List<Skolverksamhet>();
    static List<Kommun> kommuner = new List<Kommun>();

    static CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";",
    };

    public static List<Skola> CreateNewDataList()
    {
        kommuner = ImportKommunFile();
        skolverksamheter = ImportSkolverksamhetFile();

        foreach(var skola in skolverksamheter)
        {
            string kommun = string.Empty;
            try{
                
                kommun = kommuner.Find(x=>x.Kod == skola.Kod).KommunNamn;
                skolor.Add(new Skola(skola.Kod, kommun, skola.Skolenhetsnamn, skola.Grundskola, skola.Förskola, skola.Fritidshem));
            }
            catch(NullReferenceException)
            {
                Console.WriteLine($"Could not find municipality with code: {skola.Kod}. (School name: {skola.Skolenhetsnamn})");
            }
        }
        return skolor;
    }

    public static List<Kommun> ImportKommunFile()
    {
        List<Kommun> kommuner = new();
        using(var sr = new StreamReader("kommuner.csv"))
        {
            using(var csvReader = new CsvReader(sr, configuration))
            {
                csvReader.Context.RegisterClassMap<KommunMap>();
                kommuner = csvReader.GetRecords<Kommun>().ToList();
            }
        }

        return kommuner;
    }

    public static List<Skolverksamhet> ImportSkolverksamhetFile()
    {
        List<Skolverksamhet>skolverksamheter = new();
        using(var sr = new StreamReader("skolverksamhet.csv"))
        {
            using(var csvReader = new CsvReader(sr, configuration))
            {
                csvReader.Context.RegisterClassMap<SkolverksamhetMap>();
                skolverksamheter = csvReader.GetRecords<Skolverksamhet>().ToList();
            }
        }

        return skolverksamheter;
    }

    



}

