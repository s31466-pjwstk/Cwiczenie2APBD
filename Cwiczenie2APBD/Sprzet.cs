namespace Cwiczenie2APBD;


public class Sprzet
{
    public static int liczbaSprzetow;
    private static List<Sprzet> lista = new List<Sprzet>();
    private int id;
    protected string nazwa;
    protected bool czyDostepny = true;
    protected string producent;
    
    public Sprzet(string nazwa, string producent)
    {
        this.nazwa = nazwa;
        this.producent = producent;
        id = liczbaSprzetow + 1;
        liczbaSprzetow++;
        lista.Add(this);
    }

    
    public static void getListaSprzetow()
    {
        foreach(Sprzet s in lista)
            Console.WriteLine($"{s} | Dostępny: {s.czyDostepny}");
    }

    public static void getDostepnySprzet()
    {
        foreach (Sprzet s in lista)
        {
            if (s.czyDostepny == true)
                Console.WriteLine($"{s} | Dostępny: {s.czyDostepny}");
            
        }
    }

    public void ustawNieDostepny()
    {
        this.czyDostepny = false;
    }
    
    public override string ToString()
    {
        return nazwa + " " + producent;
    }
    
}