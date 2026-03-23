namespace Cwiczenie2APBD;


public class Sprzet
{
    public static int liczbaSprzetow;
    private static List<Sprzet> lista = new List<Sprzet>();
    private int id;
    protected string nazwa;
    private bool czyDostepny = true;
    protected string producent;
    
    public Sprzet(string nazwa, string producent)
    {
        this.nazwa = nazwa;
        this.producent = producent;
        id = liczbaSprzetow + 1;
        liczbaSprzetow++;
        lista.Add(this);
    }


    public static List<Sprzet> getListaSprzetow()
    {
        List<Sprzet> listaSprzetow = new List<Sprzet>();
        foreach (Sprzet s in lista)
        {
            Console.WriteLine($"{s} | Dostępny: {s.czyDostepny}"); 
            listaSprzetow.Add(s);
        }
        return listaSprzetow;
    }

    public static List<Sprzet> getDostepnySprzet()
    {
        List<Sprzet> listaSprzetow = new List<Sprzet>();
        foreach (Sprzet s in lista)
        {
            if (s.czyDostepny == true)
            {
                Console.WriteLine($"{s} | Dostępny: {s.czyDostepny}");
                listaSprzetow.Add(s);
            }

        }
        return listaSprzetow;
    }

    public void ustawCzyDostepny(bool b) { this.czyDostepny = b; }

    public bool getDostepnosc() { return this.czyDostepny; }
    
    public override string ToString() { return nazwa + " " + producent; }
    
}