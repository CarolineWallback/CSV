using CsvHelper.Configuration;

public class SkolverksamhetMap : ClassMap<SkolverksamhetData>
{
    public SkolverksamhetMap()
    {
        Map(p => p.Kod).Index(0).Name("Kod"); 
        Map(p => p.Skolenhetsnamn).Index(1).Name("Skolenhetsnamn");
        Map(p => p.Grundskola).Index(2).Name("Grund-skola");
        Map(p => p.Förskola).Index(3).Name("Förskole-klass");
        Map(p => p.Fritidshem).Index(4).Name("Fritids-hem");
    }
}