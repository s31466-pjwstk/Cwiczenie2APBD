namespace Cwiczenie2APBD;

public class Kamera : Sprzet
{
    private int maxFps;
    private string maxRozdzielczosc;

    public Kamera(string nazwa, string producent, int maxFps, string maxRozdzielczosc) : base(nazwa, producent)
    { 
        this.maxFps = maxFps;
        this.maxRozdzielczosc = maxRozdzielczosc;
    }
}