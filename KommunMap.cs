using CsvHelper.Configuration;

public class KommunMap : ClassMap<Kommun>
{
    public KommunMap()
    {
        Map(p => p.Kod).Index(0).Name("Kod"); 
        Map(p => p.KommunNamn).Index(1).Name("Kommun");
     
    }
}




