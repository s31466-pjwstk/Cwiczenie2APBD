namespace Cwiczenie2APBD;

public class Kamera : Sprzet
{
    private int maxFPS;
    private string maxRozdzielczosc;

    public Kamera(string nazwa, string producent, int maxFPS, string maxRozdzielczosc) : base(nazwa, producent)
    { 
        this.maxFPS = maxFPS;
        this.maxRozdzielczosc = maxRozdzielczosc;
    }
}