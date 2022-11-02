using CsvHelper.Configuration;

public class KommunMap : ClassMap<KommunData>
{
    public KommunMap()
    {
        Map(p => p.Kod).Index(0).Name("Kod"); 
        Map(p => p.Kommun).Index(1).Name("Kommun");
     
    }
}




