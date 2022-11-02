public class Skola
{
    public int Kod {get; set;}
    public string Kommun {get; set;}
    public string Skolenhetsnamn {get; set;}
    public string Grundskola {get; set;}
    public string Förskola {get; set;}
    public string Fritidshem {get; set;}

    public Skola()
    {

    }
    
    public Skola(int kod, string kommun, string skolenhetsnamn, string grundskola, string förskola, string fritidshem)
    {
        Kod = kod;
        Kommun = kommun;
        Skolenhetsnamn = skolenhetsnamn;
        Grundskola = grundskola;
        Förskola = förskola;
        Fritidshem = fritidshem;
    }
}