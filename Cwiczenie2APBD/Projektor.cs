namespace Cwiczenie2APBD;

public class Projektor : Sprzet
{
    private int jasnoscANSI;
    private string technologiaWyswietlania;

    public Projektor(string nazwa, string producent, int jasnoscAnsi, string technologiaWyswietlania) : base(nazwa, producent)
    {
        this.jasnoscANSI = jasnoscAnsi;
        this.technologiaWyswietlania = technologiaWyswietlania;
    }
}