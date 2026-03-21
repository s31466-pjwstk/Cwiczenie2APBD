namespace Cwiczenie2APBD;

public class Projektor : Sprzet
{
    private int jasnoscAnsi;
    private string technologiaWyswietlania;

    public Projektor(string nazwa, string producent, int jasnoscAnsi, string technologiaWyswietlania) : base(nazwa, producent)
    {
        this.jasnoscAnsi = jasnoscAnsi;
        this.technologiaWyswietlania = technologiaWyswietlania;
    }
}