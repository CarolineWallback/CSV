using CsvHelper.Configuration;

public class SkolMap : ClassMap<Skola>
{
    public SkolMap()
    {
        Map(p => p.Kod).Name("Kod"); 
        Map(p => p.Kommun).Name("Kommun");
        Map(p => p.Skolenhetsnamn).Name("Skolenhetsnamn");
        Map(p => p.Grundskola).Name("Grund-skola");
        Map(p => p.Förskola).Name("Förskole-klass");
        Map(p => p.Fritidshem).Name("Fritids-hem");
    }
}